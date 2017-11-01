using Common;
using Model.Auth;
using Model.Domain;
using NLog;
using Persistence.DbContextScope;
using Persistence.DbContextScope.Extensions;
using Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IDealerService
    {
        ResponseHelper InsertOrUpdate(BPMConfig_Dealer model);
        int GetDealerCount();
        List<BPMConfig_Dealer> GetDealers(int Index, int PageSize, string sorting);
        BPMConfig_Dealer GetObjById(int id);


    }

    public class DealerService : IDealerService
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IRepository<BPMConfig_Dealer> _dealerRepo;

        public DealerService(
            IDbContextScopeFactory dbContextScopeFactory,
            IRepository<BPMConfig_Dealer> dealerRepo
            )
        {
            _dbContextScopeFactory = dbContextScopeFactory;
            _dealerRepo = dealerRepo;
        }

        public ResponseHelper InsertOrUpdate(BPMConfig_Dealer model)
        {
            var rh = new ResponseHelper();
            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    List<BPM_DealerContactType> queryF = new List<BPM_DealerContactType>();
                    IEnumerable<ApplicationUser> users = ctx.GetEntity<ApplicationUser>();

                    if (model.Id > 0)
                    {
                        var originalRegist = _dealerRepo.Single(x => x.Id == model.Id);
                        originalRegist.DealerCode = model.DealerCode;
                        originalRegist.DealerName = model.DealerName;
                        originalRegist.ProvinceId = model.ProvinceId;
                        originalRegist.DealerPresident = model.DealerPresident;
                        originalRegist.Address = model.Address;
                        originalRegist.Status = model.Status;
                        originalRegist.CreatorUser = users.Where(w => w.Id == originalRegist.CreatorUserId).FirstOrDefault();
                        if (model.LastModifierUserId != null && model.LastModifierUserId != string.Empty)
                        {
                            originalRegist.LastModifierUser= users.Where(w => w.Id == model.LastModifierUserId).FirstOrDefault();
                            originalRegist.LastModifierUserId = model.LastModifierUserId;
                            originalRegist.LastModificationTime = DateTime.Now;
                        }
                        _dealerRepo.Update(originalRegist);
                    }
                    else
                    {
                        model.CreationTime = DateTime.Now;
                        model.CreatorUser = users.Where(w => w.Id == model.CreatorUserId).FirstOrDefault();
                        _dealerRepo.Insert(model);
                    }

                    ctx.SaveChanges();
                    rh.SetResponse(true);

                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                rh.SetResponse(false, e.Message);
                throw;
            }

            return rh;
        }

        public List<BPMConfig_Dealer> GetDealers(int Index, int PageSize, string sorting)
        {
            using (var ctx = _dbContextScopeFactory.CreateReadOnly())
            {
                IEnumerable<BPMConfig_Dealer> query = ctx.GetEntity<BPMConfig_Dealer>();

                List<BPMConfig_Dealer> queryF = new List<BPMConfig_Dealer>();
                IEnumerable<ApplicationUser> users = ctx.GetEntity<ApplicationUser>();

                var UserEmty = new ApplicationUser() { UserName = "" };
                //buscando usuario creador
                queryF = query.Select(s => new BPMConfig_Dealer()
                {
                    Id = s.Id,
                    DealerCode = s.DealerCode,
                    DealerName = s.DealerName,
                    ProvinceId = s.ProvinceId,
                    DealerPresident = s.DealerPresident,
                    Address = s.Address,
                    Status = s.Status,
                    CreatorUser = users.Where(w => w.Id == s.CreatorUserId).Select(t => new ApplicationUser { UserName = t.UserName }).FirstOrDefault(),
                    CreationTime = s.CreationTime,
                    LastModifierUser = s.LastModifierUserId != null ? users.Where(w => w.Id == s.LastModifierUserId).Select(t => new ApplicationUser { UserName = t.UserName }).FirstOrDefault() : UserEmty,
                    LastModificationTime = s.LastModificationTime
                }).ToList();
                //buscando usuario actualizador

                if (string.IsNullOrEmpty(sorting) || sorting.Equals("Id ASC"))
                {
                    queryF = queryF.OrderBy(p => p.Id).ToList();
                }
                else if (string.IsNullOrEmpty(sorting) || sorting.Equals("Id DESC"))
                {
                    queryF = queryF.OrderByDescending(p => p.Id).ToList();
                }

                else if (string.IsNullOrEmpty(sorting) || sorting.Equals("Description DealerCode"))
                {
                    queryF = queryF.OrderByDescending(p => p.DealerCode).ToList();
                }
                else if (string.IsNullOrEmpty(sorting) || sorting.Equals("Description DealerCode"))
                {
                    queryF = queryF.OrderByDescending(p => p.DealerCode).ToList();
                }
                else
                {
                    queryF = queryF.OrderBy(p => p.Id).ToList();
                }

                return PageSize > 0
                    ? queryF.Skip(Index).Take(PageSize).ToList()
                    : queryF.ToList();
            }
        }

        public int GetDealerCount()
        {
            var r = 0;

            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    var cons = ctx.GetEntity<BPMConfig_Dealer>();

                    r = cons.Count();
                }
            }
            catch (Exception)
            {

                r = 0;
            }
            return r;
        }

        //public ResponseHelper Update(BPMConfig_Dealer model)
        //{
        //    var rh = new ResponseHelper();
        //    try
        //    {
        //        using (var ctx = _dbContextScopeFactory.Create())
        //        {
        //            IEnumerable<ApplicationUser> users = ctx.GetEntity<ApplicationUser>();
        //            var originalModel = _dealerContactTypeRepo.Single(x => x.Id == model.Id);

        //            originalModel.CreatorUser = users.Where(w => w.Id == originalModel.CreatorUserId).FirstOrDefault();
        //            originalModel.Description = model.Description;
        //            // originalModel.LastModifierUserId = model.LastModifierUserId;
        //            originalModel.LastModificationTime = DateTime.Now;
        //            originalModel.LastModifierUserId = model.LastModifierUserId;
        //            _dealerContactTypeRepo.Update(originalModel);
        //            ctx.SaveChanges();
        //            rh.SetResponse(true);
        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //        logger.Error(ex.Message);
        //        rh.SetResponse(false, ex.Message);
        //    }

        //    return rh;
        //}

        public BPMConfig_Dealer GetObjById(int id)
        {
            using (var ctx = _dbContextScopeFactory.CreateReadOnly())
            {
                IEnumerable<BPMConfig_Dealer> query = ctx.GetEntity<BPMConfig_Dealer>();

                BPMConfig_Dealer queryF = new BPMConfig_Dealer();
                IEnumerable<ApplicationUser> users = ctx.GetEntity<ApplicationUser>();

                //buscando usuario creador
                var data = query.Where(w => w.Id == id).Select(s => new BPMConfig_Dealer()
                {
                    Id = s.Id,
                    DealerCode = s.DealerCode,
                    DealerName = s.DealerName,
                    ProvinceId = s.ProvinceId,
                    DealerPresident = s.DealerPresident,
                    Address = s.Address,
                    Status = s.Status,
                    CreatorUser = users.Where(w => w.Id == s.CreatorUserId).Select(t => new ApplicationUser { UserName = t.UserName }).FirstOrDefault(),
                    CreationTime = s.CreationTime,
                    LastModifierUser = users.Where(w => w.Id == s.LastModifierUserId).Select(t => new ApplicationUser { UserName = t.UserName }).FirstOrDefault(),
                    LastModificationTime = s.LastModificationTime
                }).FirstOrDefault();
                //buscando usuario actualizador

                if (data != null)
                {
                    queryF = data;
                }
                return queryF;
            }
        }

    }
}

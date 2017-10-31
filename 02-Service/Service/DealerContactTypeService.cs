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
    public interface IDealerContactTypeService
    {
        ResponseHelper InsertOrUpdate(BPM_DealerContactType model);
        int GetDealerContactTypeCount();
        List<BPM_DealerContactType> GetContactType(int Index, int PageSize, string sorting);
        BPM_DealerContactType GetObjById(int id);
        ResponseHelper Update(BPM_DealerContactType model);

    }

    public class DealerContactTypeService : IDealerContactTypeService
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IRepository<BPM_DealerContactType> _dealerContactTypeRepo;

        public DealerContactTypeService(
            IDbContextScopeFactory dbContextScopeFactory,
            IRepository<BPM_DealerContactType> dealerContactTypeRepo
            )
        {
            _dbContextScopeFactory = dbContextScopeFactory;
            _dealerContactTypeRepo = dealerContactTypeRepo;
        }

        public ResponseHelper InsertOrUpdate(BPM_DealerContactType model)
        {
            var rh = new ResponseHelper();
            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    if (model.Id > 0)
                    {
                        var originalRegist = _dealerContactTypeRepo.Single(x => x.Id == model.Id);
                        originalRegist.Description = model.Description;

                        _dealerContactTypeRepo.Insert(model);
                    }
                    else
                    {
                        _dealerContactTypeRepo.Insert(model);
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

        public List<BPM_DealerContactType> GetContactType(int Index, int PageSize, string sorting)
        {
            using (var ctx = _dbContextScopeFactory.CreateReadOnly())
            {
                IEnumerable<BPM_DealerContactType> query = ctx.GetEntity<BPM_DealerContactType>();

                List<BPM_DealerContactType> queryF = new List<BPM_DealerContactType>();
                IEnumerable<ApplicationUser> users = ctx.GetEntity<ApplicationUser>();


                //buscando usuario creador
                queryF = query.Select(s => new BPM_DealerContactType()
                {
                    Id = s.Id,
                    Description = s.Description,
                    EnumName = s.EnumName,
                    CreatorUser = users.Where(w => w.Id == s.CreatorUserId).Select(t => new ApplicationUser { UserName = t.UserName }).FirstOrDefault(),
                    CreationTime = s.CreationTime,
                    LastModifierUser = users.Where(w => w.Id == s.LastModifierUserId).Select(t => new ApplicationUser { UserName = t.UserName }).FirstOrDefault(),
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

                else if (string.IsNullOrEmpty(sorting) || sorting.Equals("Description ASC"))
                {
                    queryF = queryF.OrderByDescending(p => p.Description).ToList();
                }
                else if (string.IsNullOrEmpty(sorting) || sorting.Equals("Description DESC"))
                {
                    queryF = queryF.OrderByDescending(p => p.Description).ToList();
                }

                else if (string.IsNullOrEmpty(sorting) || sorting.Equals("EnumName ASC"))
                {
                    queryF = queryF.OrderByDescending(p => p.EnumName).ToList();
                }
                else if (string.IsNullOrEmpty(sorting) || sorting.Equals("EnumName DESC"))
                {
                    queryF = queryF.OrderByDescending(p => p.EnumName).ToList();
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

        public int GetDealerContactTypeCount()
        {
            var r = 0;

            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    var cons = ctx.GetEntity<BPM_DealerContactType>();

                    r = cons.Count();
                }
            }
            catch (Exception)
            {

                r = 0;
            }
            return r;
        }

        public ResponseHelper Update(BPM_DealerContactType model)
        {
            var rh = new ResponseHelper();
            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    IEnumerable<ApplicationUser> users = ctx.GetEntity<ApplicationUser>();
                    var originalModel = _dealerContactTypeRepo.Single(x => x.Id == model.Id);

                    originalModel.CreatorUser = users.Where(w => w.Id == originalModel.CreatorUserId).FirstOrDefault();
                    originalModel.Description = model.Description;
                   // originalModel.LastModifierUserId = model.LastModifierUserId;
                    originalModel.LastModificationTime = DateTime.Now;
                    originalModel.LastModifierUserId = model.LastModifierUserId;
                    _dealerContactTypeRepo.Update(originalModel);
                    ctx.SaveChanges();
                    rh.SetResponse(true);
                }
               
            }
            catch (Exception ex)
            {

                logger.Error(ex.Message);
                rh.SetResponse(false, ex.Message);
            }

            return rh;
        }

        public BPM_DealerContactType GetObjById(int id)
        {
            using (var ctx = _dbContextScopeFactory.CreateReadOnly())
            {
                IEnumerable<BPM_DealerContactType> query = ctx.GetEntity<BPM_DealerContactType>();

                BPM_DealerContactType queryF = new BPM_DealerContactType();
                IEnumerable<ApplicationUser> users = ctx.GetEntity<ApplicationUser>();

                //buscando usuario creador
                var data = query.Where(w => w.Id == id).Select(s => new BPM_DealerContactType()
                {
                    Id = s.Id,
                    Description = s.Description,
                    EnumName = s.EnumName,
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

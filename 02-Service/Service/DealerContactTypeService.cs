using Common;
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
                IEnumerable<BPM_DealerContactType> query = ctx.GetEntity<BPM_DealerContactType>(); ;

                if (string.IsNullOrEmpty(sorting) || sorting.Equals("Id ASC"))
                {
                    query = query.OrderBy(p => p.Id);
                }
                else if (string.IsNullOrEmpty(sorting) || sorting.Equals("Id DESC"))
                {
                    query = query.OrderByDescending(p => p.Id);
                }

                else if (string.IsNullOrEmpty(sorting) || sorting.Equals("Description ASC"))
                {
                    query = query.OrderByDescending(p => p.Description);
                }
                else if (string.IsNullOrEmpty(sorting) || sorting.Equals("Description DESC"))
                {
                    query = query.OrderByDescending(p => p.Description);
                }

                else if (string.IsNullOrEmpty(sorting) || sorting.Equals("EnumName ASC"))
                {
                    query = query.OrderByDescending(p => p.EnumName);
                }
                else if (string.IsNullOrEmpty(sorting) || sorting.Equals("EnumName DESC"))
                {
                    query = query.OrderByDescending(p => p.EnumName);
                }
                else
                {
                    query = query.OrderBy(p => p.Id);
                }

                return PageSize > 0
                    ? query.Skip(Index).Take(PageSize).ToList()
                    : query.ToList();
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
    }
}

using Common;
using Model.Domain;
using NLog;
using Persistence.DbContextScope;
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
    }
}

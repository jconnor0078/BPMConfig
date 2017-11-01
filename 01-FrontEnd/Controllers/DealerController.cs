using Common;
using FrontEnd.App_Start;
using FrontEnd.ViewModels;
using Model.Domain;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using Model.Auth;

namespace FrontEnd.Controllers
{
    public class DealerController : Controller
    {
        private IDealerService _dealerService = DependecyFactory.GetInstance<IDealerService>();

        // GET: Dealer
        public ActionResult Index()
        {
            var user = this.User;
            var infoHeader = new MiniHeaderViewModel
            {
                PrincipalTitle = "Configuraciones",
                SubTitle = "Dealers",
                MiniHeaderRoute = new List<MiniHeaderRoutes>()
                {
                    new MiniHeaderRoutes {RouteTitle="Tabla de Trabajo", Action= "Index", Controller= "Home" },
                    new MiniHeaderRoutes {RouteTitle="Dealers", Action= "Index", Controller= "Dealer" }
                }
            };

            var viewModel = new DealerBasicInfoViewModel { miniHeader = infoHeader };
            return View(viewModel);
        }

        public ActionResult GeneralEdit(int id)
        {
            var infoHeader = new MiniHeaderViewModel
            {
                PrincipalTitle = "Configuraciones",
                SubTitle = "Dealers",
                MiniHeaderRoute = new List<MiniHeaderRoutes>()
                {
                    new MiniHeaderRoutes {RouteTitle="Tabla de Trabajo", Action= "Index", Controller= "Home" },
                    new MiniHeaderRoutes {RouteTitle="Dealers", Action= "Index", Controller= "Dealer" },
                    new MiniHeaderRoutes {RouteTitle="Editar", Action= "GeneralEdit", Controller= "Dealer", id=id.ToString() }
                }
            };
            var user = this.User;

            var data = _dealerService.GetObjById(id);

            var viewModel = new DealerBasicInfoViewModel
            {
                id = data.Id, miniHeader= infoHeader

            };
            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
           
 
            var data = _dealerService.GetObjById(id);

            var viewModel = new DealerBasicInfoViewModel
            {
                id = data.Id,
                DealerCode = data.DealerCode,
                DealerName = data.DealerName,
                ProvinceId = data.ProvinceId,
                DealerPresident = data.DealerPresident,
                Address = data.Address,
                Status = data.Status,
                CreatorUserName = data.CreatorUser.UserName,
                LastModifierUserName = data.LastModifierUser != null ? data.LastModifierUser.UserName : "",
                
            };

            return PartialView("_Edit", viewModel);
        }

        [HttpPost]
        public JsonResult Update(DealerBasicInfoViewModel model)
        {
            var rh = new ResponseHelper();
            if (ModelState.IsValid)
            {
                var userId = this.User.Identity.GetUserId();
                var userName = this.User.Identity.GetUserName();

                rh = _dealerService.InsertOrUpdate(new BPMConfig_Dealer()
                {
                    Id = model.id,
                    DealerCode = model.DealerCode,
                    DealerName= model.DealerName,
                    ProvinceId = model.ProvinceId,
                    DealerPresident = model.DealerPresident,
                    Address = model.Address,
                    Status = model.Status,
                    LastModifierUser = new ApplicationUser { Id = userId, UserName = userName },
                    LastModifierUserId= userId,
                    LastModificationTime = DateTime.Now
               
                });
                if (rh.Response)
                {
                    rh.Href = "self";
                }
            }
            else
            {

                rh.SetValidations(ModelState.GetErrors());

            }

            // If we got this far, something failed, redisplay form
            return Json(rh);
        }

        public ActionResult Create()
        {
            var infoHeader = new MiniHeaderViewModel
            {
                PrincipalTitle = "Configuraciones",
                SubTitle = "Dealers",
                MiniHeaderRoute = new List<MiniHeaderRoutes>()
                {
                    new MiniHeaderRoutes {RouteTitle="Tabla de Trabajo", Action= "Index", Controller= "Home" },
                    new MiniHeaderRoutes {RouteTitle="Dealers", Action= "Index", Controller= "Dealer" },
                    new MiniHeaderRoutes {RouteTitle="Crear", Action= "Create", Controller= "Dealer"}
                }
            };

            var viewModel = new DealerCreateViewModel() { miniHeader= infoHeader };

            return View(viewModel);
        }

        [HttpPost]
        public JsonResult Upsdate(DealerBasicInfoViewModel model)
        {
            var rh = new ResponseHelper();
            if (ModelState.IsValid)
            {
                var userId = this.User.Identity.GetUserId();
                var userName = this.User.Identity.GetUserName();

                rh = _dealerService.InsertOrUpdate(new BPMConfig_Dealer()
                {
                    Id = model.id,
                    DealerCode = model.DealerCode,
                    DealerName = model.DealerName,
                    ProvinceId = model.ProvinceId,
                    DealerPresident = model.DealerPresident,
                    Address = model.Address,
                    Status = model.Status,
                    LastModifierUser = new ApplicationUser { Id = userId, UserName = userName },
                    LastModifierUserId = userId,
                    LastModificationTime = DateTime.Now

                });
                if (rh.Response)
                {
                    rh.Href = "self";
                }
            }
            else
            {

                rh.SetValidations(ModelState.GetErrors());

            }

            // If we got this far, something failed, redisplay form
            return Json(rh);
        }


        public JsonResult Dealer(int id = 0)
        {
            return Json(null);
        }


        [HttpPost]
        public JsonResult DealerList(int jtStartIndex, int jtPageSize, string jtSorting)
        {
            try
            {
                //get data from database
                int Count = _dealerService.GetDealerCount();
                List<BPMConfig_Dealer> dealers = new List<BPMConfig_Dealer>();
                dealers = _dealerService.GetDealers(jtStartIndex, jtPageSize, jtSorting);



                return Json(new { Result = "OK", data = dealers, TotalRecordCount = Count });
            }
            catch (Exception ex)
            {

                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        public JsonResult DealerContactTypeSave(DealerBasicInfoViewModel model)
        {
            var rh = new ResponseHelper();

            if (!ModelState.IsValid)
            {
                var validations = ModelState.GetErrors();
                rh.SetValidations(validations);
            }
            else
            {
                rh = _dealerService.InsertOrUpdate(new BPMConfig_Dealer()
                {
                    Id = model.id
                });
            }

            return Json(rh);
        }

    }
}
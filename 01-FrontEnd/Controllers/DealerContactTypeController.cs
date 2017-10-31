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
    public class DealerContactTypeController : Controller
    {
        private IDealerContactTypeService _dealerContactTypeService = DependecyFactory.GetInstance<IDealerContactTypeService>();
        // GET: DealerContactType
        public ActionResult Index()
        {
            var user = this.User;
            var infoHeader = new MiniHeaderViewModel
            {
                PrincipalTitle = "Configuraciones",
                SubTitle = "Tipo de Contacto",
                MiniHeaderRoute = new List<MiniHeaderRoutes>()
                {
                    new MiniHeaderRoutes {RouteTitle="Tabla de Trabajo", Action= "Index", Controller= "Home" },
                    new MiniHeaderRoutes {RouteTitle="Tipo de Contacto", Action= "Index", Controller= "DealerContactType" }
                }
            };

            var viewModel = new BasicInfoContactTypeViewModel { miniHeader = infoHeader };
            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            var user = this.User;

            var data = _dealerContactTypeService.GetObjById(id);

            var viewModel = new BasicInfoContactTypeViewModel { Description= data.Description, id = id };

            return PartialView("_Edit",viewModel);
        }
        
        [HttpPost]
        public JsonResult Update(BasicInfoContactTypeViewModel model)
        {
            var rh = new ResponseHelper();
            if (ModelState.IsValid)
            {
                var userId = this.User.Identity.GetUserId();
                var userName = this.User.Identity.GetUserName();
 
                rh = _dealerContactTypeService.Update(new BPM_DealerContactType()
                {
                    Id= model.id,
                    Description= model.Description,
                    LastModifierUserId= userId
                });
                if (rh.Response)
                {
                    rh.Href = "self";
                }
            }else
            {
                 
                rh.SetValidations(ModelState.GetErrors());
                
            }

            // If we got this far, something failed, redisplay form
            return Json(rh);
        }

         
     

        public JsonResult DealerContactType(int id = 0)
        {
            return Json(null);
        }

  
        [HttpPost]
        public JsonResult ContactTypeList(int jtStartIndex, int jtPageSize, string jtSorting)
        {
            try
            {
                //get data from database
                int Count = _dealerContactTypeService.GetDealerContactTypeCount();
                List<BPM_DealerContactType> contactTypes = new List<BPM_DealerContactType>();
                contactTypes = _dealerContactTypeService.GetContactType(jtStartIndex, jtPageSize, jtSorting);

                         

                return Json(new {Result="OK", data=contactTypes, TotalRecordCount= 20 });
            }
            catch (Exception ex)
            {

                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        public JsonResult DealerContactTypeSave(BPM_DealerContactType model)
        {
            var rh = new ResponseHelper();

            if (!ModelState.IsValid)
            {
                var validations = ModelState.GetErrors();
                rh.SetValidations(validations);
            }
            else
            {
                rh = _dealerContactTypeService.InsertOrUpdate(model);
            }

            return Json(rh);
        }


    }

    public class Person
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime RecordDate { get; set; }
    }
}
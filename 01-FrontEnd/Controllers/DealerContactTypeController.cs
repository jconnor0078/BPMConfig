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

namespace FrontEnd.Controllers
{
    public class DealerContactTypeController : Controller
    {
        private IDealerContactTypeService _dealerContactTypeService = DependecyFactory.GetInstance<IDealerContactTypeService>();
        // GET: DealerContactType
        public ActionResult Index()
        {
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

            var viewModel = new BasicInfoContactTypeViewModel { miniHeader= infoHeader};
            return View(viewModel);
        }

        public JsonResult DealerContactType(int id = 0)
        {
            return Json(null);
        }

        [HttpPost]
        public JsonResult PersonList()
        {
            try
            {
                List<Person> persons = new List<Person>();
                persons.Add(new Person
                {
                    PersonId=1,
                    Name="Jefferson Connor",
                    Age=25,
                    RecordDate= DateTime.Now
                });

                persons.Add(new Person
                {
                    PersonId = 2,
                    Name = "Miguel Connor",
                    Age = 44,
                    RecordDate = DateTime.Now
                });

                persons.Add(new Person
                {
                    PersonId = 3,
                    Name = "Pedro Connor",
                    Age = 33,
                    RecordDate = DateTime.Now
                });

                persons.Add(new Person
                {
                    PersonId = 22,
                    Name = "Jose Connor",
                    Age = 25,
                    RecordDate = DateTime.Now
                });

                return Json(new { Result = "OK", Records = persons });
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
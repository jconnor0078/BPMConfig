using Common;
using FrontEnd.ViewModels;
using Service;
using System.Collections.Generic;
using System.Web.Mvc;

namespace FrontEnd.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var infoHeader = new MiniHeaderViewModel
            {
                PrincipalTitle = "Tabla de Trabajo",
                SubTitle = "",
       
            };

            var viewModel = new HomeViewModel { miniHeader = infoHeader };
            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
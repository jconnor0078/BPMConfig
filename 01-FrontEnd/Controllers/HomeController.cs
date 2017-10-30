using Common;
using FrontEnd.ViewModels;
using Service;
using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace FrontEnd.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var userId = this.User.Identity.GetUserId();
            var userName = this.User.Identity.GetUserName();
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
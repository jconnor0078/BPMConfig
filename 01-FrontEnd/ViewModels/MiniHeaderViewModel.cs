using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontEnd.ViewModels
{
    public class MiniHeaderViewModel
    {
        public string PrincipalTitle { get; set; }

        public string SubTitle { get; set; }

        public List<MiniHeaderRoutes> MiniHeaderRoute { get; set; }
    }

    public class MiniHeaderRoutes
    {
        public string RouteTitle { get; set; }

        public string Action { get; set; }

        public string Controller { get; set; }
    }
}
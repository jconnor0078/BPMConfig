using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FrontEnd.ViewModels
{
    public class DealerBasicInfoViewModel
    {
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public int id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string DealerCode { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string DealerName { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public int ProvinceId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string DealerPresident { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public bool Status { get; set; }

        public string CreatorUserName { get; set; }

        public string LastModifierUserName { get; set; }


        public MiniHeaderViewModel miniHeader { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FrontEnd.ViewModels
{
    public class BasicInfoContactTypeViewModel
    {
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public int id { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [Display(Name = "Descripción")]
        public string Description { get; set; }

        public MiniHeaderViewModel miniHeader { get; set; }
    }
}
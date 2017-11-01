using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FrontEnd.ViewModels
{
    public class DealerCreateViewModel
    {
        public MiniHeaderViewModel miniHeader { get; set; }

        #region info del header de Dealer
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
        #endregion

        #region info de contactos
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public int ContactId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string ContactName { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public int ContactTypeId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string ContactDesc { get; set; }

        List<DealerContactVM> ContactList { get; set; }
        #endregion

        #region Aosciacion de dealers
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public int DealerAssociationId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string DealerAssociationDesc { get; set; }

        List<DealerAssociationVM> DealerAssociationList { get; set; }
        #endregion


        public string CreatorUserName { get; set; }

        public string LastModifierUserName { get; set; }

    }

    public class DealerContactVM
    {
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public int ContactId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string ContactName { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public int ContactTypeId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string ContactDesc { get; set; }



    }

    public class DealerAssociationVM
    {
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public int DealerAssociationId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string DealerAssociationDesc { get; set; }
    }
}
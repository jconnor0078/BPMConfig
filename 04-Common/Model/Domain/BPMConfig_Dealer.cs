using Model.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    public class BPMConfig_Dealer
    {
        public int Id { get; set; }
        [Required]
        public string DealerCode { get; set; }
        [Required]
        public string DealerName { get; set; }
        [Required]
        public int ProvinceId { get; set; }
        [Required]
        public string DealerPresident { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public bool Status { get; set; }

        public ICollection<BPMConfig_DealerAssociation> DealerAssociations { get; set; }
        public ICollection<BPM_DealerContact> DealerContacts { get; set; }



        [ForeignKey("CreatorUserId"), Required]
        public ApplicationUser CreatorUser { get; set; }
        public string CreatorUserId { get; set; }
        [Required]
        public DateTime CreationTime { get; set; }

        [ForeignKey("LastModifierUserId")]
        public ApplicationUser LastModifierUser { get; set; }
        public string LastModifierUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
    }
}

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
   public class BPMConfig_AssocDealerDealerAssociation
    {
       
        //public BPMConfig_Dealer BPMConfig_Dealer { get; set; }
       // public BPMConfig_Dealer BPMConfig_Dealer { get; set; }
        [Key, Column(Order = 0)]
        public int BPMConfig_DealerId { get; set; }
        public BPMConfig_Dealer BPMConfig_Dealer { get; set; }

        //public BPMConfig_DealerAssociation BPMConfig_DealerAssociation { get; set; }

        //public BPMConfig_DealerAssociation BPMConfig_DealerAssociation { get; set; }
        [Key, Column(Order = 1)]
        public int BPMConfig_DealerAssociationId { get; set; }
        public BPMConfig_DealerAssociation BPMConfig_DealerAssociation { get; set; }



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

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
    public class BPM_DealerContact
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string ContactName { get; set; }

        [Required]
        public string ContactDesc { get; set; }

        public BPMConfig_Dealer BPMConfig_Dealer { get; set; }
        public int BPMConfig_DealerId { get; set; }

        public BPM_DealerContactType BPM_DealerContactType { get; set; }
        public int BPM_DealerContactTypeId { get; set; }

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

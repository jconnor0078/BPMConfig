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
    public class BPM_DealerContactType
    {
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string EnumName { get; set; }



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

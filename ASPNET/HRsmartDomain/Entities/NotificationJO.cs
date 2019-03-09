using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRsmartDomain
{
   public  class NotificationJO
    {


        [Key, Column(Order = 1)]

        public int NotificationJOId { get; set; }

        [Key, Column(Order = 2)]
        [Required]
        public int UserId { get; set; }

        [Key, Column(Order = 3)]
        [Required]
        public int JobId { get; set; }

        public virtual RecruitementManager RecruitementManager { get; set; }
        public virtual JobOffer JobOffer { get; set; }

    }
}

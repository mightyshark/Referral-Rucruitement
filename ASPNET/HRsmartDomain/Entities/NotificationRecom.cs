using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRsmartDomain
{
   public  class NotifcationRecom
    {


        [Key, Column(Order = 1)]

        public int NotifcationRecomId { get; set; }

        [Key, Column(Order = 2)]
        [Required]
        public int UserId { get; set; }

        [Key, Column(Order = 3)]
        [Required]
        public int CandidateId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Candidate Candidate { get; set; }

    }
}

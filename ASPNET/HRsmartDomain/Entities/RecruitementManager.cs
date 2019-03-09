using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRsmartDomain
{
 public    class RecruitementManager

    {
        [Key]
        public int RMId { get; set; }
        private int Experience { get; set; }
        public virtual ChiefHumanRessources ChiefHumanRessources { get; set; }
        public virtual ICollection<JobOffer> JobOffers { get; set; }
        public int EmployeeId { get; set; }
        public int CHROId { get; set; }
        public virtual ICollection<Suggestion> Suggestions { get; set; }

        public RecruitementManager()
        {
            //SSsss
        }


    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRsmartDomain
{
   public  class Employee 
    {

        [Key]
        public int EmployeeId { get; set; }
        public string Direction { get; set; }
        public int Experience { get; set; }
        public string Fonction { get; set; }
        public int RewardPoints { get; set; }
        public int CHROId { get; set; }

        public virtual ChiefHumanRessources ChiefHumanRessources { get; set; }

        public virtual ICollection<JobOffer> JobOffers { get; set; }

        public virtual ICollection<Suggestion> Suggestions { get; set; }

        public virtual ICollection<Candidate> Candidates { get; set; }
        public Employee()
        {

        }



        //nav prop

    }
    
}

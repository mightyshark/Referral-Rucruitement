using HRsmartDomain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRsmartWeb.Models
{
    public class EmployeeModel
    {
        public int EmployeeId { get; set; }
        public string Direction { get; set; }
        public int Experience { get; set; }
        public string Fonction { get; set; }
        public int RewardPoints { get; set; }

        public virtual ChiefHumanRessources ChiefHumanRessources { get; set; }
        public virtual ICollection<JobOffer> JobOffers { get; set; }

        public virtual ICollection<Candidate> Candidates { get; set; }
    }
}
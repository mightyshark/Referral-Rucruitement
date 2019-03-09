using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using HRsmartDomain.Enumerations;

namespace HRsmartDomain
{
    public class Suggestion
    {
        [Key]
       public int SuggestionId { get; set; }
        public string SuggestionTitle { get; set; }
         public string Departement { get; set; }
        public string Mission { get; set; }
        public string DemandedProfile { get; set; }
         public string Raison { get; set; }
       
        public SuggestionState SuggestionStates { get; set; }

        [ForeignKey("RmId")]
        public virtual RecruitementManager RecruitementManager { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }
        public int? EmployeeId { get; set; }
        public int? RmId { get; set; }



        public Suggestion()
        {

        }

    }
}

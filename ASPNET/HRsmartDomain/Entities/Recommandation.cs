using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRsmartDomain.Entities
{
    public class Recommandation
    {
        [Key, Column(Order = 0)]
        public int EmployeeFK { get; set; }
        [Key, Column(Order = 1)]
        [ForeignKey("Candidate")]
        public int CandidatetFK { get; set; }
        [Key, Column(Order = 2)]
        public CandidateState candidatestate { get; set; }
        public DateTime DateRecommandation { get; set; }
        [ForeignKey("EmployeeFK")]
        public virtual Employee Employee { get; set; }
        public virtual Candidate Candidate { get; set; }


    }
}

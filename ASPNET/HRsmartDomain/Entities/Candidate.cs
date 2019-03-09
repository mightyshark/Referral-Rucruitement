using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using HRsmartDomain.Entities;

namespace HRsmartDomain
{
    public class Candidate
    {


        [Key]
        public int CandidateId { get; set; }
        public string Cin { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public string Adresse { get; set; }
        public string Email { get; set; }

        public int ContactNumber { get; set; }
        public string LinkedInProfile { get; set; }
        public string FaceBookProfile { get; set; }
        public string Recommandations { get; set; }
        public CandidateState CandidateState { get; set; }
        public InterviewSteps InterviewSteps { get; set; }
        public string SkypeId { get; set; }


        public int? JobOffreId { get; set; }
        public int? EmployeeId { get; set; }
        //nav
        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }
        [ForeignKey("JobOffreId")]

        public virtual JobOffer JobOffer { get; set; }

        public Candidate()
        {

        }
    }
}

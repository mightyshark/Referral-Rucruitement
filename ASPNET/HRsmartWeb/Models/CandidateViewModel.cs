using HRsmartDomain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRsmartWeb.Models
{
    public class CandidateViewModel
    {
        [Key]
        public int CandidateId { get; set; }
        [Required]

        public string Cin { get; set; }
        [Required]

        public string FirstName { get; set; }
        [Required]

        public string LastName { get; set; }
        [Required]

        public int Age { get; set; }


        [Required]
        public Gender Gender { get; set; }
        public string Adresse { get; set; }
        public string Email { get; set; }

        public int ContactNumber { get; set; }
        public string LinkedInProfile { get; set; }
        public string FaceBookProfile { get; set; }

        public string Recommandations { get; set; }
        public string SkypeId { get; set; }
        public CandidateState CandidateState { get; set; }
        public InterviewSteps InterviewSteps { get; set; }
        public virtual JobOffer JobOffer { get; set; }
        public virtual Employee Employee { get; set; }


    }
}
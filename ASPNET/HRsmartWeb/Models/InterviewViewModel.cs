using HRsmartDomain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRsmartWeb.Models
{
    public class InterviewViewModel
    {


        [Key]
        public int InterviewId { get; set; }

        [Required(ErrorMessage = "The subject is Required")]
        public String Subject { get; set; }


        [Required(ErrorMessage = "The description is Required")]
        [StringLength(60, MinimumLength = 3)]

        public String Description { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        [Required(ErrorMessage = "Start Date of the recommandation is Required")]
        [DataType(DataType.Date, ErrorMessage = "Invalid Date")]
        public DateTime StartDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        [DataType(DataType.Date, ErrorMessage = "Invalid Date")]
        [Required(ErrorMessage = "End Date of the recommandation is Required")]
        public DateTime EndDate { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (EndDate < StartDate)
            {
                yield return
                  new ValidationResult(errorMessage: "EndDate must be greater than StartDate",
                                       memberNames: new[] { "EndDate" });
            }
        }


        [Range(1, 20, ErrorMessage = "Value must be between 1 to 20")]
        public int ResultHRInterview { get; set; }
        [Range(1, 20, ErrorMessage = "Value must be between 1 to 20")]

        public int ResultTechnicalInterview { get; set; }
        [Range(1, 20, ErrorMessage = "Value must be between 1 to 20")]

        public int ResultQIInterview { get; set; }
        [Range(1, 20, ErrorMessage = "Value must be between 1 to 20")]

        public int ResultSoftSkillsInterview { get; set; }
        public int FinalResult { get; set; }

        [Required]
        public IEnumerable<SelectListItem> State { get; set; }

        [Required]
        public CandidateState CandidateStates { get; set; }  // les etats du candidat         Accepted, Refused, Waiting

        public virtual Candidate candidat { get; set; }

        public string FeedBack { get; set; }  //lorsqu'on clique sur le bouton update interview, un fedback sera envoyé a l'employé qui a fait la reference.


    }


}
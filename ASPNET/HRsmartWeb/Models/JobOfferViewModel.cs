using HRsmartDomain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRsmartWeb.Models
{
    public class JobOfferViewModel
    {
        public JobOfferViewModel()
        {
            Types = new List<SelectListItem>();
        }

        [Key]
        public int JobId { get; set; }

        public string JobTitle { get; set; }
        public string Reference { get; set; }
        [Required(ErrorMessage = "Mission is Requirde")]
        public string Mission { get; set; }
        public string DemanderProfile { get; set; }
        [Required(ErrorMessage = "Location is Requirde")]
        public string Location { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ExpirationDate { get; set; }
        public ContractType ContratType { get; set; }
        public IEnumerable<SelectListItem> Types { get; set; }

        public virtual RecruitementManager RecruitementManager { get; set; }
     //   public virtual ICollection<Candidate> Candidates { get; set; }

        public virtual Employee Employee { get; set; }
        public int EmployeeId { get; set; }
        public int RmId { get; set; }

    }
}
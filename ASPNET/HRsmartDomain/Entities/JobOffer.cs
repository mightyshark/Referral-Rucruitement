using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace HRsmartDomain
{
    public class JobOffer
    {

        [Key]
        public int JobId { get; set; }

        public string JobTitle { get; set; }
        [Required(ErrorMessage = "Reference is Requirde")]
        public string Reference { get; set; }
        [Required(ErrorMessage = "Mission is Requirde")]
        public string Mission { get; set; }
        public string DemanderProfile { get; set; }
        [Required(ErrorMessage = "Location is Required")]
        public string Location { get; set; }
        [Display(Name = "Expiration Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:g}", ApplyFormatInEditMode = true)]
        public DateTime ExpirationDate { get; set; }
        public ContractType ContratType { get; set; }
        public virtual RecruitementManager RecruitementManager { get; set; }
      //  public virtual ICollection<Candidate> Candidates { get; set; }

        public virtual Employee Employee { get; set; }
        public int? EmployeeId { get; set; }
        public int? RmId { get; set; }

        public JobOffer()
        {

        }

    }
}

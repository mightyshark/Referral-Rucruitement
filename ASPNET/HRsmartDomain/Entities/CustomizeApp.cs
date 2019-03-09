using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace HRsmartDomain
{
    public class CustomizeApp
    {
        [Key]
        public int IdCustom { get; set; }

        [Display(Name = "Entreprise Logo")]
        public string Logo { get; set; }


        [Required(ErrorMessage = "Entreprise Name is required")]
        [Display(Name = "Entreprise Name")]
        public string WlcText { get; set; }
        public string Url { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public Address address { get; set; }

        [Required(ErrorMessage = "Entreprise Address is required")]
        [Display(Name = "Creation Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:g}", ApplyFormatInEditMode = true)]
        public DateTime CreationDate { get; set; }



        public CompField CompF { get; set; }

        public CompState CompS { get; set; }



        public CustomizeApp()

        {

        }

    }

}

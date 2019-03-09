using HRsmartDomain;
using HRsmartWeb;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRsmartWeb.Models
{
    public class CustomizeAppModel
    {
        [Key]
        public int IdCustom { get; set; }
        public string Logo { get; set; }
        public string WlcText { get; set; }
        public string Url { get; set; }

        public virtual Address address { get; set; }

        [Display(Name = "Creation Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:g}", ApplyFormatInEditMode = true)]
        public DateTime CreationDate { get; set; }

        public CompField CompF { get; set; }

        public CompState CompS { get; set; }


    }
}
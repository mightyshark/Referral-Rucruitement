using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRsmartDomain
{
    public class ReclamationJOffer
    {
        [Key]
        [Column(Order = 0)]
        public int? IdjofferFK { get; set; }

        [ForeignKey("IdjofferFK")]
        [JsonIgnore]
        public virtual JobOffer JobOffer { get; set; }
        [Key]
        [Column(Order = 1)]
        public string IdUserFK { get; set; }

        [ForeignKey("IdUserFK")]
        [JsonIgnore]
        public virtual User User { get; set; }
        [Required]
        public string Objet { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string Contenu { get; set; }
        [Required]
        public string Date { get; set; }
        [Required]
        public bool? Traite { get; set; }
    }
}

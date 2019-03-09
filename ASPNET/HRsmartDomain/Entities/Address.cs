using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRsmartDomain
{
    public class Address
    {
        public Address()
        {
        }

        [Key]
        public int id { get; set; }
        public string city { get; set; }
        public string country { get; set; }

        //public string street { get; set; }
        //public double x { get; set; }
        //  public double y { get; set; }
        //public string zip { get; set; }
        //public string state { get; set; }
        public virtual ICollection<CustomizeApp> customizeapps { get; set; }
    }
}

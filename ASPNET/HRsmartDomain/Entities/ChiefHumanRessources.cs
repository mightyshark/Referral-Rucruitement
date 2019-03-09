﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRsmartDomain
{
   public  class ChiefHumanRessources 
    {


        [Key]
        public int CHROId { get; set; }

      

        public string Grade { get; set; }



        public virtual ICollection<RecruitementManager> RecruitementManagers { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }

    }
}

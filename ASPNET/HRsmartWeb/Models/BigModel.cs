using HRsmartWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRsmartWeb.Models
{
 public   class BigModel
    {
    
       
        public virtual List<RoleMVC> RoleMVC { get; set; }
        public virtual List<UserMVC> UserMVC { get; set; }
       
        public UserRoleMVC UserRole { get; set; }
        
        public BigModel()
        {

        }
    }
    
}
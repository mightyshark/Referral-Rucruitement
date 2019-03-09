
using HRsmartData;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRsmartService
{
  public  class GestionCompte : Services<IUser>
    {
        private static DatabaseFactory dbFactory = new DatabaseFactory();
        private static UnitOfWork utw = new UnitOfWork(dbFactory);

        public GestionCompte(): base(utw)
        {
           
        }

        public HRsmartContext MyContex()
        {
            return utw.MyContext;
        }
    }
}

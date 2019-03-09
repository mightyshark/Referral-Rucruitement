using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using HRsmartDomain;
using HRsmartData;
using Service.Pattern;

namespace HRsmartService
{
  public  class CandidatService : Services<Candidate>, ICandidatService
    {


        private static DatabaseFactory DbFactory = new DatabaseFactory();
        private static UnitOfWork utw = new UnitOfWork(DbFactory);

        public CandidatService(): base(utw)
        {

            
        }
    }
}

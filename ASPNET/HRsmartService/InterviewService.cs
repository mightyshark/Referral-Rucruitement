using HRsmartData;
using HRsmartDomain.Entities;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRsmartService
{
    class InterviewService : Services<Interview>, IInterviewService
    {

        private static DatabaseFactory DbFactory = new DatabaseFactory();
        private static UnitOfWork utw = new UnitOfWork(DbFactory);

        public InterviewService(): base(utw)
        {




        }

        //public IEnumerable<Interview> GetJOBByCategory()
        //{
        //    var res = utw.GetRepository<Interview>().GetMany(x => x.candidat.JobOffreId == );
        //    List<JobOffers> Ls = new List<JobOffers>();
        //    foreach (var r in res)
        //    {
        //        Ls.Add(r);
        //    }

        //    return Ls;
        //}


    }
}

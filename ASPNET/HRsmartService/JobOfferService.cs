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
    public class JobOfferService : Services<JobOffer>, IJobOfferService
    { 
        private static DatabaseFactory DbFactory = new DatabaseFactory();
        private static UnitOfWork utw = new UnitOfWork(DbFactory);

        public JobOfferService() : base(utw)
        {


        }
        public IEnumerable<JobOffer> GetAll(Expression<Func<JobOffer, bool>> condition = null, Expression<Func<JobOffer, bool>> orderBy = null)
        {
            DatabaseFactory dbFactoryy = new DatabaseFactory();
            if (condition != null && orderBy != null)
                return dbFactoryy.MyContext.JobOffers.Where(condition).OrderBy(orderBy);
            else
                if (condition != null)
                return dbFactoryy.MyContext.JobOffers.Where(condition);
            else
                if (orderBy != null)
                return dbFactoryy.MyContext.JobOffers.OrderBy(orderBy);
            else
                return dbFactoryy.MyContext.JobOffers;
        }
    }
}

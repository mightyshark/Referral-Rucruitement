using HRsmartData;
using HRsmartDomain;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HRsmartService
{
   public class GestionReclamationJO : Services<ReclamationJOffer>
    {
        private static DatabaseFactory dbFactory = new DatabaseFactory();
        private static UnitOfWork utw = new UnitOfWork(new DatabaseFactory());
        public GestionReclamationJO(): base(utw)
        {

        }
        public void Edit(ReclamationJOffer t)
        {
            DatabaseFactory dbFactoryy = new DatabaseFactory();
            dbFactoryy.MyContext.ReclamationJOffer.Attach(t);
            dbFactoryy.MyContext.Entry(t).State = EntityState.Modified;
            dbFactoryy.MyContext.SaveChanges();

        }
        public IEnumerable<ReclamationJOffer> GetAll(Expression<Func<ReclamationJOffer, bool>> condition = null, Expression<Func<ReclamationJOffer, bool>> orderBy = null)
        {
            DatabaseFactory dbFactoryy = new DatabaseFactory();
            if (condition != null && orderBy != null)
                return dbFactoryy.MyContext.ReclamationJOffer.Where(condition).OrderBy(orderBy);
            else
                if (condition != null)
                return dbFactoryy.MyContext.ReclamationJOffer.Where(condition);
            else
                if (orderBy != null)
                return dbFactoryy.MyContext.ReclamationJOffer.OrderBy(orderBy);
            else
                return dbFactoryy.MyContext.ReclamationJOffer;
        }
    }
}

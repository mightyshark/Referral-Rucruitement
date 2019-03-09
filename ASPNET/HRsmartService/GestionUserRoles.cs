

using HRsmartData;
using HRsmartDomain;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HRsmartService
{
   public  class GestionUserRoles : Services<UserRole>
    {

        public static DatabaseFactory dbFactoryy = new DatabaseFactory();
        private static UnitOfWork utw = new UnitOfWork(dbFactoryy);

        public GestionUserRoles() : base(utw)
        {

        }
        public UserRole GetOne(Expression<Func<UserRole, bool>> condition = null)
        {


            return dbFactoryy.MyContext.UserRoles.Where(condition).FirstOrDefault();

        }

        public IEnumerable<UserRole> GetAll(Expression<Func<UserRole, bool>> condition = null, Expression<Func<UserRole, bool>> orderBy = null)
        {
            DatabaseFactory dbFactoryy = new DatabaseFactory();
            if (condition != null && orderBy != null)
                return dbFactoryy.MyContext.UserRoles.Where(condition).OrderBy(orderBy);
            else
                if (condition != null)
                return dbFactoryy.MyContext.UserRoles.Where(condition);
            else
                if (orderBy != null)
                return dbFactoryy.MyContext.UserRoles.OrderBy(orderBy);
            else
                return dbFactoryy.MyContext.UserRoles;
        }
    }
}



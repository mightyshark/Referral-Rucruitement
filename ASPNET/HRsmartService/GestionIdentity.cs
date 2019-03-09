
using HRsmartData;
using HRsmartDomain;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HRsmartService
{
    public class GestionIdentity : Services<User>
    {
        public static DatabaseFactory dbFactoryy = new DatabaseFactory();
        private static UnitOfWork utw = new UnitOfWork(dbFactoryy);

        public GestionIdentity() : base(utw)
        {

        }
        public User GetOne(Expression<Func<User, bool>> condition = null)
        {


            return dbFactoryy.MyContext.Users.Where(condition).FirstOrDefault();

        }

        public IEnumerable<User> GetAll(Expression<Func<User, bool>> condition = null, Expression<Func<User, bool>> orderBy = null)
        {
            DatabaseFactory dbFactoryy = new DatabaseFactory();
            if (condition != null && orderBy != null)
                return dbFactoryy.MyContext.Users.Where(condition).OrderBy(orderBy);
            else
                if (condition != null)
                return dbFactoryy.MyContext.Users.Where(condition);
            else
                if (orderBy != null)
                return dbFactoryy.MyContext.Users.OrderBy(orderBy);
            else
                return dbFactoryy.MyContext.Users;
        }
    }
}

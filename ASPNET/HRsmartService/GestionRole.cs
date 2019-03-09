

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
   public class GestionRole : Services<Role>
    {

        public static DatabaseFactory dbFactoryy = new DatabaseFactory();
        private static UnitOfWork utw = new UnitOfWork(dbFactoryy);

        public GestionRole() : base(utw)
        {

        }
        public Role GetOne(Expression<Func<Role, bool>> condition = null)
        {
            

            return dbFactoryy.MyContext.Roles.Where(condition).FirstOrDefault();

        }

        public IEnumerable<Role> GetAll(Expression<Func<Role, bool>> condition = null, Expression<Func<Role, bool>> orderBy = null)
        {
            DatabaseFactory dbFactoryy = new DatabaseFactory();
            if (condition != null && orderBy != null)
                return dbFactoryy.MyContext.Roles.Where(condition).OrderBy(orderBy);
            else
                if (condition != null)
                return dbFactoryy.MyContext.Roles.Where(condition);
            else
                if (orderBy != null)
                return dbFactoryy.MyContext.Roles.OrderBy(orderBy);
            else
                return dbFactoryy.MyContext.Roles;
        }
    }
}


using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HRsmartData
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        
        private DatabaseFactory dbFactory = null;
        private DbSet<T> dbSet;

        public RepositoryBase(DatabaseFactory dbFactory)
        {
            this.dbFactory = dbFactory;
            dbSet = MyContext.Set<T>();
        }
        public HRsmartContext MyContext { get { return dbFactory.MyContext; } }

        public void Commit()
        {
            MyContext.SaveChanges();
        }
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public void Delete(Expression<Func<T, bool>> condition)
        {
            IEnumerable<T> Maliste = dbSet.Where(condition);
            foreach (var item in Maliste)
                dbSet.Remove(item);
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public T FindById(string id)
        {
            return dbSet.Find(id);
        }

        public T FindById(int id)
        {
            return dbSet.Find(id);
        }

        public IEnumerable<T> GetMany(Expression<Func<T, bool>> condition = null, Expression<Func<T, bool>> orderBy = null)
        {
            if (condition != null && orderBy != null)
                return dbSet.Where(condition).OrderBy(orderBy);
            else
                if (condition != null)
                return dbSet.Where(condition);
            else
                if (orderBy != null)
                return dbSet.OrderBy(orderBy);
            else
                return dbSet;
        }

        public void Update(T entity)
        {
            dbSet.Attach(entity); // attacher au dbset afin d'identifier l'objet a modifier
           MyContext.Entry(entity).State = EntityState.Modified; // modifier les informations de l'objet trouvé par celui du paramètre
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }

        public IEnumerable<T> FindByCondition(Expression<Func<T, bool>> condition = null,
                                             Expression<Func<T, bool>> orederby = null)
        {
            if (condition == null && orederby == null)
            {
                return dbSet;
            }
            else
            if (condition != null && orederby == null)
            {
                return dbSet.Where(condition);

            }
            else
            if (condition == null && orederby != null)
            {
                return dbSet.OrderBy(orederby);
            }
            return dbSet.Where(condition).OrderBy(orederby);
        }
    }
}

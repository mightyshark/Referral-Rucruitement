using HRsmartData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Pattern
{
    public class Services<T> : IServices<T> where T : class
    {

        private UnitOfWork utw;
       
        public Services(UnitOfWork utw)
        {
            this.utw = utw;
        }

        public void Commit()
        {
            utw.Commit();
        }

        public virtual void  Create(T entity)
        {
            utw.GetRepository<T>().Add(entity);
        }

        public void Dispose()
        {
            utw.Dispose();
        }

        public IEnumerable<T> GetAll()
        {
            return utw.GetRepository<T>().GetAll();
        }

        public virtual void MettreAJour(T entity)
        {
            utw.GetRepository<T>().Update(entity);
        }

        public virtual T RechercherByString(string id)
        {
            return utw.GetRepository<T>().FindById(id);
        }

        public virtual T RechercherById(int id)
        {
            return utw.GetRepository<T>().FindById(id);
        }

        public virtual IEnumerable<T> Recuperer(Expression<Func<T, bool>> condition = null, Expression<Func<T, bool>> orderBy = null)
        {
            return utw.GetRepository<T>().GetMany(condition, orderBy);
        }
      

        public virtual void Supprimer(Expression<Func<T, bool>> condition)
        {
            utw.GetRepository<T>().Delete(condition);
        }

        public virtual void Supprimer(T entity)
        {
            utw.GetRepository<T>().Delete(entity);
        }
        public T GetById(int id)
        {

            return utw.GetRepository<T>().FindById(id);
        }
        public IEnumerable<T> FindByCondition(Expression<Func<T, bool>> condition = null, Expression<Func<T, bool>> orederby = null)
        {

            return utw.GetRepository<T>().FindByCondition(condition, orederby);
        }
    }
}

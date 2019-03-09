using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq.Expressions;

namespace HRsmartData
{
    public interface IRepositoryBase<T> where T:class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(Expression<Func<T,bool>> condition);
        T FindById(int id);
        T FindById(string id);

        IEnumerable<T> GetAll();
        IEnumerable<T> GetMany(Expression<Func<T, bool>> condition=null, Expression<Func<T,bool>> orderBy=null);
        IEnumerable<T> FindByCondition(
        Expression<Func<T, bool>> condition = null,
        Expression<Func<T, bool>> orederby = null);
    

}
}

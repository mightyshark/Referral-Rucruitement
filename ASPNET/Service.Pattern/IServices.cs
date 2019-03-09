using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Pattern
{
  public  interface IServices<T> where T : class
    {


        void Create(T entity);
        void MettreAJour(T entity);
        void Supprimer(T entity);
        void Supprimer(Expression<Func<T, bool>> condition);
        T RechercherById(int id);
        T RechercherByString(string id);

        IEnumerable<T> GetAll();
        IEnumerable<T> Recuperer(Expression<Func<T, bool>> condition = null, Expression<Func<T, bool>> orderBy = null);
        void Commit();
        void Dispose();
    }
}

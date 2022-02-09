using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryWebApiDataAccess.IRepository
{
   public interface IRepository<T> where T : class
    {
        T Get(int Id);
        //IEnumerable<T> GetAll(
        //    Expression<Func<T, bool>> filter = null,
        //    //Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null,
        //    string includeProperties = null
        //    );
        ////T FirstOrDefault(
        ////    Expression<Func<T, bool>> filter = null,
        ////    string includeProperties = null
        ////    );
        IEnumerable<T> GetAll();
        
        bool Add(T entity);
        
        bool Remove(T entity);
    
        bool Save();
    }
}

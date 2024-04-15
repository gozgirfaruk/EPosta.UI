using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EPosta.DataAccess.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        void Insert(T entity);
        void Update(T entity);  
        void Delete(T entity);
        List<T> GetAll();
        List<T> GetByFilter(Expression<Func<T, bool>> filter);
        T GetByID(int id);
    }
}

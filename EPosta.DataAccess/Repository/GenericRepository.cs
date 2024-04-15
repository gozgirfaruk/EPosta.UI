using EPosta.DataAccess.Abstract;
using EPosta.DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace EPosta.DataAccess.Repository
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        public void Delete(T entity)
        {
            using var db = new EPostaContext();
            db.Remove(entity);
            db.SaveChanges();
        }

        public List<T> GetAll()
        {
            using var db = new EPostaContext();
            return db.Set<T>().ToList();
        }

        public List<T> GetByFilter(Expression<Func<T, bool>> filter)
        {
            using var c = new EPostaContext();
            return c.Set<T>().Where(filter).ToList();
        }

        public T GetByID(int id)
        {
            using var db = new EPostaContext();
            return db.Set<T>().Find(id);
        }

        public void Insert(T entity)
        {
            using var db = new EPostaContext();
            db.Add(entity);
            db.SaveChanges();
        }

        public void Update(T entity)
        {
            using var db = new EPostaContext();
            db.Update(entity);
            db.SaveChanges();
        }
    }
}

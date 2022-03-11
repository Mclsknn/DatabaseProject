using DatabaseProject.DataAccess.Abstract;
using DatabaseProject.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject.DataAccess.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public void Add(T t)
        {
            using var c = new Context();
            c.Add(t);
            c.SaveChanges();
        }

        public void Delete(int id)
        {
            using var c = new Context();
            T t = c.Set<T>().Find(id);
            c.Remove(t);
            c.SaveChanges();
        }

        public void Update(T t)
        {
            using var c = new Context();
            c.Update(t);
            c.SaveChanges();
        }
        
        public ICollection<T> GetAll()
        {
            using var c = new Context();
            c.Countries.ToList();
            return c.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            using var c = new Context();
            return c.Set<T>().Find(id);
        }

     
    }
}

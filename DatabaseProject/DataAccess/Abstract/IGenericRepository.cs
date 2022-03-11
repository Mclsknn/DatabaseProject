using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject.DataAccess.Abstract
{
    public interface IGenericRepository<T>
    {
        void Add(T t);
        void Update(T t);
        void Delete(int id);
        T GetById(int id);
        ICollection<T> GetAll();

    }
}

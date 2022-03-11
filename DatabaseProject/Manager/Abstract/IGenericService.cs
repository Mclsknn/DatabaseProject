using DatabaseProject.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject.Manager.Abstract
{
    public interface IGenericService<T> 
    {
        void Add(T t);
        void Update(T t);
        void Delete(int id);
        ICollection<T> GetAll();
        T GetById(int id);
        T EntityGenerator();
        void DisplayEntityList(ICollection<T> t);
    }
}

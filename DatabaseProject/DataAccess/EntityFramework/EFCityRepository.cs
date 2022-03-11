using DatabaseProject.DataAccess.Repository;
using DatabaseProject.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseProject.Entity.Concrete;

namespace DatabaseProject.DataAccess.EntityFramework
{
    public class EFCityRepository : GenericRepository<City>, ICityDal
    {
    }
}

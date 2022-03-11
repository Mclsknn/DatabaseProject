using DatabaseProject.DataAccess.Repository;
using DatabaseProject.DataAccess.Abstract;
using DatabaseProject.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject.DataAccess.EntityFramework
{
    public class EFCarDetailRepository : GenericRepository<CarDetail>, ICarDetailDal
    {
    
    }
}

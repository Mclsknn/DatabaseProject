using DatabaseProject.DataAccess.Abstract;
using DatabaseProject.DisplayFunctions;
using DatabaseProject.Entity.Concrete;
using DatabaseProject.Manager.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject.Manager.Concrete
{
    public class DriverManager : IDriverService , IManager
    {
        IDriverDal _driverDal;
        public DriverManager(IDriverDal driverDal)
        {
            _driverDal = driverDal;
        }
        public void Add(Driver t)
        {
            _driverDal.Add(t);
        }

        public void Delete(int id)
        {
           _driverDal.Delete(id);
        }

        public ICollection<Driver> GetAll()
        {
           return _driverDal.GetAll();
        }

        public Driver GetById(int id)
        {
            return _driverDal.GetById(id);
        }

        public void Update(Driver driver)
        {
           _driverDal.Update(driver);
        }

        public void Process(int islem)
        {
            ICollection<Driver> drivers = GetAll();
            Driver driver = EntityGenerator();
        
            switch (islem)
            {
                case 1 : try
                         {
                            Add(driver);
                            DisplayFunc.IsSuccess();
                         }
                         catch (Exception)
                         {
                            DisplayFunc.IsError();
                         } break;
                     
                case 2 : DisplayEntityList(drivers);
                         try
                         {
                            Delete(DisplayFunc.DisplayDelete());
                            DisplayFunc.IsSuccess();
                         }
                         catch (Exception)
                         {
                            DisplayFunc.IsError();
                         } break;

                case 3 : DisplayEntityList(drivers);
                         Driver updateDriver = GetById(DisplayFunc.DisplayUpdate());
                         updateDriver.DriverLastName = "Bilir";
                         try
                         {
                            Update(updateDriver);
                            DisplayFunc.IsSuccess();
                         }
                         catch (Exception)
                         {
                            DisplayFunc.IsError();
                         } break;

                default: break;
            };
        }

        public void DisplayEntityList(ICollection<Driver> drivers)
        {
            foreach (var item in drivers)
            Console.WriteLine(item.ID + " - " + item.DriverName + " "+ item.DriverLastName);
        }
        public Driver EntityGenerator()
        {
            Driver driver = new Driver();
            driver.DriverName = "Murat";
            driver.DriverLastName = "Akçay";
            driver.DriverBirthDate = DateTime.Now;
            driver.IdentityNumber = "14593975121";
            return driver;
        }

    }
}

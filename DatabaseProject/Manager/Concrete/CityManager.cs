using DatabaseProject.DataAccess.Abstract;
using DatabaseProject.DisplayFunctions;
using DatabaseProject.Entity.Concrete;
using DatabaseProject.Manager.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject.Manager.Concrete
{
    public class CityManager : ICityService, IManager
    {
        ICityDal _cityDal;

        public CityManager(ICityDal cityDal)
        {
            _cityDal = cityDal;
        }
        public void Add(City t)
        {
            _cityDal.Add(t);
        }

        public void Delete(int id)
        {
            _cityDal.Delete(id);
        }

        public ICollection<City> GetAll()
        {
            return _cityDal.GetAll();
        }

        public City GetById(int id)
        {
            return _cityDal.GetById(id);
        }

        public void Update(City city)
        {
            _cityDal.Update(city);
        }

        public void Process(int islem)
        {
            ICollection<City> cities = GetAll();
            City city = EntityGenerator();

            switch (islem)
            {
                case 1 : Add(city); break;

                case 2 : DisplayEntityList(cities);
                         try
                         {
                            Delete(DisplayFunc.DisplayDelete());
                            DisplayFunc.IsSuccess();
                         }
                         catch (Exception)
                         {
                            DisplayFunc.IsError();
                         } break;

                case 3 : DisplayEntityList(cities);
                         City updateCity = GetById(DisplayFunc.DisplayUpdate());
                         updateCity.CityName = "Bursa";
                         try
                         {
                            Update(updateCity);
                            DisplayFunc.IsSuccess();
                         }
                         catch (Exception)
                         {
                            DisplayFunc.IsError();
                         } break;

                default: break;
            };
        }

        public void DisplayEntityList(ICollection<City> cities)
        {
            foreach (var item in cities)
            Console.WriteLine(item.ID + "-" + item.CityName); 
        }

        public City EntityGenerator()
        {
            City city = new City();
            city.CityName = "Adana";
            city.CountryID = 1;
            return city;
        }

    }
}

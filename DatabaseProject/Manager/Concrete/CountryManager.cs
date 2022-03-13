using DatabaseProject.DataAccess.Abstract;
using DatabaseProject.DisplayFunctions;
using DatabaseProject.Entity.Abstract;
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
    public class CountryManager : ICountryService, IManager
    {
        ICountryDal _countryDal;
        public CountryManager(ICountryDal countryDal)
        {
            _countryDal = countryDal;
        }
        public void Add(Country c )
        {
            _countryDal.Add(c);
        }

        public void Delete(int id)
        {
            _countryDal.Delete(id);
        }

        public ICollection<Country> GetAll()
        {
            return _countryDal.GetAll();
        }

        public Country GetById(int id)
        {
            return _countryDal.GetById(id);
        }

        public void Update(Country country)
        {
            _countryDal.Update(country);
        }

        public void Process(int islem)
        {
            ICollection<Country> countries = GetAll();
            Country country = EntityGenerator();
            switch (islem)
            {
                case 1 : try
                         {
                            Add(country);
                            DisplayFunc.IsSuccess();
                         }
                         catch (Exception)
                         {
                            DisplayFunc.IsError();
                         } break;

                case 2 : DisplayEntityList(countries);
                         try
                         {
                            Delete(DisplayFunc.DisplayDelete());
                            DisplayFunc.IsSuccess();
                         }
                         catch (Exception)
                         {
                            DisplayFunc.IsError();
                         } break;

                case 3 : DisplayEntityList(countries);
                         Country updateCountry = GetById(DisplayFunc.DisplayUpdate());
                         updateCountry.CountryName = "Turkey";
                         try
                         {
                            Update(updateCountry);
                            DisplayFunc.IsSuccess();
                         }
                         catch (Exception)
                         {
                            DisplayFunc.IsError();
                         } break;

                default : break;
            };
        }
       
        public void DisplayEntityList(ICollection<Country> countries)
        {
            foreach (var item in countries)
             Console.WriteLine(item.ID + " - " + item.CountryName);
        }

        public Country EntityGenerator()
        {
            Country country = new Country();
            country.CountryName = "Türkiye";
            return country;
        }


    }
}

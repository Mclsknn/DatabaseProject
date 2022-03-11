using DatabaseProject.DataAccess.EntityFramework;
using DatabaseProject.Manager.Abstract;
using DatabaseProject.Manager.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject.Manager.ManagerFactory
{
    public static class ManagerGenerator
    {
        public static IManager HaveManager(int tabloAdi)
        {
            DefaultManager manager = new DefaultManager();

            switch (tabloAdi)
            {
                case 1: DeliveryDetailManager deliveryManager = new DeliveryDetailManager(new EFDeliveryDetailRepository()); return deliveryManager;
                case 2: CountryManager countryManager = new CountryManager(new EFCountryRepository()); return countryManager;
                case 3: CityManager cityManager = new CityManager(new EFCityRepository()); return cityManager;
                case 4: LoadDetailManager loadDetailManager = new LoadDetailManager(new EFLoadDetailRepository()); return loadDetailManager;
                case 5: DriverManager driverManager = new DriverManager(new EFDriverRepository()); return driverManager;
                case 6: CarDetailManager carDetailManager = new CarDetailManager(new EFCarDetailRepository()); return carDetailManager;
                case 7: TyreDetailManager tyreDetailManager = new TyreDetailManager(new EFTyreDetailRepository()); return tyreDetailManager;
                default: return manager;
            }
        }
    }
}

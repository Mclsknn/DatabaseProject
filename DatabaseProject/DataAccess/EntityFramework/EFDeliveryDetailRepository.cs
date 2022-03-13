using DatabaseProject.DataAccess.Repository;
using DatabaseProject.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseProject.Entity.Concrete;
using DatabaseProject.Database;

namespace DatabaseProject.DataAccess.EntityFramework
{
    public class EFDeliveryDetailRepository : GenericRepository<DeliveryDetail>, IDeliveryDetailDal
    {
        public ICollection<City> GetCitiesByDelivery(DeliveryDetail delivery)
        {
            using var c = new Context();
            ICollection<City> cities = new List<City>();
            City cityDeparture = c.Cities.Where(x => x.ID == delivery.CityDepartureId).FirstOrDefault();
            City cityDestination = c.Cities.Where(x => x.ID == delivery.CityDestinationId).FirstOrDefault();
            cities.Add(cityDeparture);
            cities.Add(cityDestination);

            return cities;
        }
    }
}

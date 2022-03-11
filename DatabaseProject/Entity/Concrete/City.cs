using DatabaseProject.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject.Entity.Concrete
{
    public class City : IEntity
    {
        [Key]
        public int ID { get; set; }
        public string CityName { get; set; }
        public Country Country { get; set; }
        public int? CountryID { get; set; }

        public ICollection<DeliveryDetail> DeliveryDepartureCities{ get; set; }
        public ICollection<DeliveryDetail> DeliveryDestinationCities{ get; set; }
      
    }
}

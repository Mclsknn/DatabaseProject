using DatabaseProject.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject.Entity.Concrete
{
    public class DeliveryDetail : IEntity
    {
        [Key]
        public int DeliveryID { get; set; }
        public DateTime DeliveryStartDate { get; set; }
        public DateTime DeliveryEndDate { get; set; }
        public string AddressDetail { get; set; }

        public ICollection<LoadDetail> LoadDetails { get; set; }
        public ICollection<Driver> Drivers { get; set; }
        public CarDetail CarDetail { get; set; }
        public int? CarDetailID { get; set; }
        public City CityDeparture { get; set; }
        public City CityDestination { get; set; }
        public Country CountryDeparture { get; set; }
        public Country CountryDestination { get; set; }
        public int? CityDepartureId { get; set; }
        public int? CityDestinationId{ get; set; }
        public int? CountryDepartureId { get; set; }
        public int? CountryDestinationId{ get; set; }
       

    }
}

using DatabaseProject.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject.Entity.Concrete
{
    public class Country : IEntity
    {
        [Key]
        public int ID { get; set; }
        public string CountryName { get; set; }
        public ICollection<City> Cities { get; set; }

        public ICollection<DeliveryDetail> DeliveryDepartureCountries { get; set; }
        public ICollection<DeliveryDetail> DeliveryDestinationCountries { get; set; }
    }
}

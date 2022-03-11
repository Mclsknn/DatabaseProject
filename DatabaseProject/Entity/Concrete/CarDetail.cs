using DatabaseProject.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject.Entity.Concrete
{
    public class CarDetail : IEntity
    {
        [Key]
        public int ID { get; set; }
        public string CarType { get; set; }
        public int CarModel { get; set; }
        public DeliveryDetail DeliveryDetail { get; set; }
        public ICollection<TyreDetail> TyreDetails { get; set; }
    }
}

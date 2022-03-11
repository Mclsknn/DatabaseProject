using DatabaseProject.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject.Entity.Concrete
{
    public class Driver : IEntity
    {
        [Key]
        public int ID { get; set; }
        public string DriverName { get; set; }
        public string DriverLastName { get; set; }
        public string IdentityNumber { get; set; }
        public DateTime DriverBirthDate { get; set; }
        public DeliveryDetail DeliveryDetail { get; set; }
        public int? DeliveryDetailID { get; set; }

    }
}

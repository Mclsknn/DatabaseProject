using DatabaseProject.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject.Entity.Concrete
{
    public class LoadDetail : IEntity
    {
        [Key]
        public int ID { get; set; }
        public string LoadType { get; set; }
        public decimal LoadWidth { get; set; }
        public decimal LoadHeight { get; set; }
        public decimal LoadDepth { get; set; }
        public DeliveryDetail DeliveryDetail { get; set; }
        public int? DeliveryDetailID { get; set; }

    }
}

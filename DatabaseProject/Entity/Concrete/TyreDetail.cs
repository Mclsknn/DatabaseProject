using DatabaseProject.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject.Entity.Concrete
{
    public class TyreDetail : IEntity
    {
        [Key]
        public int ID { get; set; }
        public string TyreType { get; set; }
        public DateTime ExpirationDate { get; set; }
        public CarDetail CarDetail { get; set; }
        public int? CarID { get; set; }
    }
}

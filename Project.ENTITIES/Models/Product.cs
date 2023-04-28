using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class Product:BaseEntity
    {
        public string JourneyNo { get; set; }
        public DateTime Departure { get; set; }
        public DateTime Arrival { get; set; }
        public DateTime Hour { get; set; }
        public string Captain { get; set; }
        public decimal UnitPrice { get; set; }


        //Relational Properties

        public virtual List<OrderDetail> OrderDetails { get; set; }


    }
}

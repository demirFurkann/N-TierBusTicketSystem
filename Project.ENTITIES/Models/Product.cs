using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class Product : BaseEntity
    {
        public string JourneyNo { get; set; }
        public string Departure { get; set; }
        public string Arrival { get; set; }
        public string Date { get; set; }
        public string Hour { get; set; }
        public string Captain { get; set; }
        public decimal UnitPrice { get; set; }
        public string Chair { get; set; }



        //Relational Properties

        public virtual List<OrderDetail> OrderDetails { get; set; }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class Order:BaseEntity
    {
        public string TicketNo { get; set; }
        public decimal TotalPrice { get; set; }
        public int? CustomerID { get; set; }



        //Relational Properties

        public virtual Customer Customer { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }


    }
}

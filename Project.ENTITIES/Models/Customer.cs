using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class Customer:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string TckNo { get; set; }
        public string Gender { get; set; }

        public int? EmployeeID { get; set; }

        public Customer()
        {
            Orders = new List<Order> { };
        }

       

        //Relational Properties

        public virtual List<Order> Orders { get; set; }

        public virtual Employee Employee { get; set; }

    }
}

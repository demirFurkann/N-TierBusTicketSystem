using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class Employee:BaseEntity
    {
        public string EmployeeNo { get; set; }
        public string Number { get; set; }
        public string FullName { get; set; }


        public virtual List<Customer> Customers { get; set; }
    }
}

using CRUDTest.Domain.DBContext;
using CRUDTest.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDTest.Data.DBContext
{
    public class MyDBContext : IDBContext
    {
        public List<Customer> Customers { get; set; } = new List<Customer>();

        public MyDBContext()
        {
            Customers.Add(new Customer { Id = 1, FirstName = "Reza", LastName = "Mosallanejad" });
            Customers.Add(new Customer { Id = 2, FirstName = "Ali", LastName = "Ahmadi" });
        }
    }
}

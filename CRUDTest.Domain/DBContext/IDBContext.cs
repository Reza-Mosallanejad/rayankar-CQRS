using CRUDTest.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDTest.Domain.DBContext
{
    public interface IDBContext
    {
        public List<Customer> Customers { get; set; }
    }
}

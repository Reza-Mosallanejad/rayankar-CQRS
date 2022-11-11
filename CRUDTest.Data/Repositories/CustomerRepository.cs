using CRUDTest.Domain.DBContext;
using CRUDTest.Domain.Models;
using CRUDTest.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDTest.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private IDBContext _dBContext;

        public CustomerRepository(IDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task<Customer> Add(Customer model)
        {
            model.Id = _dBContext.Customers.Max(c => c.Id) + 1;
            _dBContext.Customers.Add(model);
            return await Task.FromResult(model);
        }

        public async Task<List<Customer>> GetAll()
        {
            return await Task.FromResult(_dBContext.Customers);
        }
    }
}

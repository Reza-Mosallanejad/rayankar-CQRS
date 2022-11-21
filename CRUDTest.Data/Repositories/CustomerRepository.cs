using CRUDTest.Domain.DBContext;
using CRUDTest.Domain.Models;
using CRUDTest.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDTest.Data.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        private MyDBContext _dBContext;
        private DbSet<Customer> _dBSet;

        public CustomerRepository(MyDBContext dBContext) : base(dBContext)
        {
            _dBContext = dBContext;
            _dBSet = _dBContext.Set<Customer>();
        }

        public async Task<Customer> GetByEmail(string email)
        {
            return await _dBSet.FirstOrDefaultAsync(c => c.Email == email);
        }

    }
}

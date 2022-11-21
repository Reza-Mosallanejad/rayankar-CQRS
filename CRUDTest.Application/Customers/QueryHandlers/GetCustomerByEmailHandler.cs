using CRUDTest.Application.Customers.Queries;
using CRUDTest.Domain.Models;
using CRUDTest.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDTest.Application.Customers.Handlers
{
    public class GetCustomerByEmailHandler : IRequestHandler<GetCustomerByEmailQuery, Customer>
    {
        private ICustomerRepository _repository;

        public GetCustomerByEmailHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<Customer> Handle(GetCustomerByEmailQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetByEmail(request.Email);
        }
    }
}

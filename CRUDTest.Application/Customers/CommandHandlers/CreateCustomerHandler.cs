using CRUDTest.Application.Customers.Commands;
using CRUDTest.Domain.Models;
using CRUDTest.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDTest.Application.Customers.CommandHandlers
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, Customer>
    {
        private ICustomerRepository _customerRepository;

        public CreateCustomerHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Customer> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            await _customerRepository.Create(request.Customer);
            await _customerRepository.Save();
            return request.Customer;
        }
    }
}

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
    public class DeleteCustomerByEmailHandler : IRequestHandler<DeleteCustomerByEmailCommand, bool>
    {
        private ICustomerRepository _customerRepository;

        public DeleteCustomerByEmailHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<bool> Handle(DeleteCustomerByEmailCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetByEmail(request.Email);
            await _customerRepository.Delete(customer);
            await _customerRepository.Save();
            return true;
        }
    }
}

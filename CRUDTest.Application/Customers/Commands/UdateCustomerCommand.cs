using CRUDTest.Domain.DTOs;
using CRUDTest.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDTest.Application.Customers.Commands
{
    public class UpdateCustomerCommand : IRequest<OperationResult<CustomerDTO>>
    {
        public CustomerDTO CustomerDTO { get; }

        public UpdateCustomerCommand(CustomerDTO customerDTO)
        {
            CustomerDTO = customerDTO;
        }
    }
}

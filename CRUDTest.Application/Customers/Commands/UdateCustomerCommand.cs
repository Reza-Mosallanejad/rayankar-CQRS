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
    public record UpdateCustomerCommand(CustomerDTO CustomerDTO) : IRequest<OperationResult<CustomerDTO>>;
}

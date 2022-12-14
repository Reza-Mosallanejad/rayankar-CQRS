using CRUDTest.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDTest.Application.Customers.Commands
{
    public record DeleteCustomerByEmailCommand(string Email) : IRequest<bool>;
}

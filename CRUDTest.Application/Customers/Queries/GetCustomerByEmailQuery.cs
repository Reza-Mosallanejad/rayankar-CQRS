using CRUDTest.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDTest.Application.Customers.Queries
{
    public record GetCustomerByEmailQuery(string Email) : IRequest<Customer>;

}

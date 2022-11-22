using CRUDTest.Domain.DTOs;
using MediatR;

namespace CRUDTest.Application.Customers.Queries
{
    public record GetCustomerByEmailQuery(string Email) : IRequest<CustomerDTO>;
}

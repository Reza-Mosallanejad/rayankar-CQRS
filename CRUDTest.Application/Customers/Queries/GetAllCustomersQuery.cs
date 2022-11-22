using CRUDTest.Domain.DTOs;
using MediatR;

namespace CRUDTest.Application.Customers.Queries
{
    public record GetAllCustomersQuery : IRequest<List<CustomerDTO>>;
}

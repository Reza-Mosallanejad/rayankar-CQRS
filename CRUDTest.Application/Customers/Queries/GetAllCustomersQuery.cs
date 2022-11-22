using CRUDTest.Domain.DTOs;
using MediatR;

namespace CRUDTest.Application.Customers.Queries
{
    public class GetAllCustomersQuery : IRequest<List<CustomerDTO>>
    {
    }
}

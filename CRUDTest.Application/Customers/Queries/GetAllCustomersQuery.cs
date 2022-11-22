using CRUDTest.Domain.DTOs;
using MediatR;

namespace CRUDTest.Application.Customers.Queries
{
    public class GetAllCustomersRequest : IRequest<List<CustomerDTO>>
    {
    }
}

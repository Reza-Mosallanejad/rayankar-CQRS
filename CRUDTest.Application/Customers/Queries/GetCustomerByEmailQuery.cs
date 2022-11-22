using CRUDTest.Domain.DTOs;
using MediatR;

namespace CRUDTest.Application.Customers.Queries
{
    public class GetCustomerByEmailQuery : IRequest<CustomerDTO>
    {
        public string Email { get; set; }

        public GetCustomerByEmailQuery(string email)
        {
            Email = email;
        }
    }
}

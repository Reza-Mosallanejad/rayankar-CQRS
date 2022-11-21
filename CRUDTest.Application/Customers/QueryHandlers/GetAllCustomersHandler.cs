using CRUDTest.Application.Customers.Queries;
using CRUDTest.Domain.Models;
using CRUDTest.Domain.Repositories;
using MediatR;

namespace CRUDTest.Application.Customers.QueryHandlers
{
    public class GetAllCustomersHandler : IRequestHandler<GetAllCustomersQuery, List<Customer>>
    {
        private ICustomerRepository _repository;

        public GetAllCustomersHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Customer>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            return await _repository.All.ToList();
        }
    }
}

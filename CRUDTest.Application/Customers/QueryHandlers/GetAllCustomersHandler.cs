using AutoMapper;
using CRUDTest.Application.Customers.Queries;
using CRUDTest.Domain.DTOs;
using CRUDTest.Domain.Models;
using CRUDTest.Domain.Repositories;
using MediatR;

namespace CRUDTest.Application.Customers.QueryHandlers
{
    public class GetAllCustomersHandler : IRequestHandler<GetAllCustomersQuery, List<CustomerDTO>>
    {
        private ICustomerRepository _repository;
        private readonly IMapper _mapper;

        public GetAllCustomersHandler(ICustomerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<CustomerDTO>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            var customers = _repository.All.ToList();
            return _mapper.Map<List<CustomerDTO>>(customers);
        }
    }
}

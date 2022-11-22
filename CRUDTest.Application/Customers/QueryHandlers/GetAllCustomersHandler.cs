using AutoMapper;
using CRUDTest.Application.Customers.Queries;
using CRUDTest.Domain.DTOs;
using CRUDTest.Domain.Models;
using CRUDTest.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CRUDTest.Application.Customers.QueryHandlers
{
    public class GetAllCustomersHandler : IRequestHandler<GetAllCustomersQuery, List<CustomerDTO>>
    {
        private ICustomerRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetAllCustomersHandler> _logger;

        public GetAllCustomersHandler(ICustomerRepository repository, IMapper mapper, ILogger<GetAllCustomersHandler> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<CustomerDTO>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var customers = _repository.All.ToList();
                return _mapper.Map<List<CustomerDTO>>(customers);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new List<CustomerDTO>();
            }
        }
    }
}

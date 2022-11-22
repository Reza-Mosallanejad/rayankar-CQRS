using AutoMapper;
using CRUDTest.Application.Customers.Queries;
using CRUDTest.Domain.DTOs;
using CRUDTest.Domain.Models;
using CRUDTest.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDTest.Application.Customers.Handlers
{
    public class GetCustomerByEmailHandler : IRequestHandler<GetCustomerByEmailQuery, CustomerDTO>
    {
        private ICustomerRepository _repository;
        private readonly IMapper _mapper;

        public GetCustomerByEmailHandler(ICustomerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CustomerDTO> Handle(GetCustomerByEmailQuery request, CancellationToken cancellationToken)
        {
            var customer = await _repository.GetByEmail(request.Email);
            return _mapper.Map<CustomerDTO>(customer);
        }
    }
}

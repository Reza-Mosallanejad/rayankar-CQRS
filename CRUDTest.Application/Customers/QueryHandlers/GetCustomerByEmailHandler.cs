﻿using AutoMapper;
using CRUDTest.Application.Customers.Queries;
using CRUDTest.Domain.DTOs;
using CRUDTest.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CRUDTest.Application.Customers.Handlers
{
    public class GetCustomerByEmailHandler : IRequestHandler<GetCustomerByEmailQuery, CustomerDTO?>
    {
        private ICustomerRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetCustomerByEmailHandler> _logger;

        public GetCustomerByEmailHandler(ICustomerRepository repository, IMapper mapper, ILogger<GetCustomerByEmailHandler> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<CustomerDTO?> Handle(GetCustomerByEmailQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var customer = await _repository.GetByEmail(request.Email.ToLower());
                if (customer == null)
                    return null;
                else
                    return _mapper.Map<CustomerDTO>(customer);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }
    }
}

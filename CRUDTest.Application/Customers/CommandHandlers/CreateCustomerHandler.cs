using AutoMapper;
using CRUDTest.Application.Customers.Commands;
using CRUDTest.Application.Utilities;
using CRUDTest.Domain.DTOs;
using CRUDTest.Domain.Models;
using CRUDTest.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CRUDTest.Application.Customers.CommandHandlers
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, OperationResult<CustomerDTO>>
    {
        private ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateCustomerHandler> _logger;

        public CreateCustomerHandler(ICustomerRepository customerRepository, IMapper mapper, ILogger<CreateCustomerHandler> logger)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<OperationResult<CustomerDTO>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var opr = new OperationResult<CustomerDTO>
            {
                Result = request.CustomerDTO
            };
            try
            {
                request.CustomerDTO.Email = request.CustomerDTO.Email.Trim().ToLower();

                if (!PhonenumberValidator.Validate(request.CustomerDTO.PhoneNumber))
                {
                    opr.Failed("Phone number is not valid");
                    return opr;
                }

                var customer = _mapper.Map<Customer>(request.CustomerDTO);
                await _customerRepository.Create(customer);
                var customerDTO = _mapper.Map<CustomerDTO>(customer);
                opr.Result = customerDTO;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                opr.Failed();
            }
            return opr;
        }
    }
}

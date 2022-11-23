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
    public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerCommand, OperationResult<CustomerDTO>>
    {
        private ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateCustomerHandler> _logger;

        public UpdateCustomerHandler(ICustomerRepository customerRepository, IMapper mapper, ILogger<UpdateCustomerHandler> logger)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<OperationResult<CustomerDTO>> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
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
                await _customerRepository.Update(customer);
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

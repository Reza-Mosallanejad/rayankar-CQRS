using AutoMapper;
using CRUDTest.Application.Customers.Commands;
using CRUDTest.Domain.DTOs;
using CRUDTest.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CRUDTest.Application.Customers.CommandHandlers
{
    public class DeleteCustomerByEmailHandler : IRequestHandler<DeleteCustomerByEmailCommand, OperationResult<CustomerDTO>>
    {
        private ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteCustomerByEmailHandler> _logger;

        public DeleteCustomerByEmailHandler(ICustomerRepository customerRepository, IMapper mapper, ILogger<DeleteCustomerByEmailHandler> logger)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<OperationResult<CustomerDTO>> Handle(DeleteCustomerByEmailCommand request, CancellationToken cancellationToken)
        {
            var opr = new OperationResult<CustomerDTO>();
            try
            {
                var customer = await _customerRepository.GetByEmail(request.Email.ToLower());
                if (customer != null)
                {
                    var customerDTO = _mapper.Map<CustomerDTO>(customer);
                    opr.Result = customerDTO;
                    await _customerRepository.Delete(customer);
                }
                else
                {
                    opr.Failed("Not Found");
                }
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

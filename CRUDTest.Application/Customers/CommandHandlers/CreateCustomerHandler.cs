using AutoMapper;
using CRUDTest.Application.Customers.Commands;
using CRUDTest.Domain.DTOs;
using CRUDTest.Domain.Models;
using CRUDTest.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDTest.Application.Customers.CommandHandlers
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, OperationResult<CustomerDTO>>
    {
        private ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CreateCustomerHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<OperationResult<CustomerDTO>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var opr = new OperationResult<CustomerDTO>();
            var customer = _mapper.Map<Customer>(request.CustomerDTO);
            await _customerRepository.Create(customer);
            await _customerRepository.Save();
            var customerDTO = _mapper.Map<CustomerDTO>(customer);
            opr.Result = customerDTO;
            return opr;
        }
    }
}

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
    public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerCommand, OperationResult<CustomerDTO>>
    {
        private ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public UpdateCustomerHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<OperationResult<CustomerDTO>> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var opr = new OperationResult<CustomerDTO>();
            var customer = _mapper.Map<Customer>(request.CustomerDTO);
            await _customerRepository.Update(customer);
            await _customerRepository.Save();
            var customerDTO = _mapper.Map<CustomerDTO>(customer);
            opr.Result = customerDTO;
            return opr;
        }
    }
}

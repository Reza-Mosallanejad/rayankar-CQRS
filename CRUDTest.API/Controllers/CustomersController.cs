using CRUDTest.Application.Customers.Commands;
using CRUDTest.Application.Customers.Queries;
using CRUDTest.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CRUDTest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<Customer>> GetAllCustomers()
        {
            var query = new GetAllCustomersQuery();
            var result = await _mediator.Send(query);
            return result;
        }

        [HttpGet]
        public async Task<Customer> GetCustomerByEmail(string email)
        {
            var query = new GetCustomerByEmailQuery(email);
            var result = await _mediator.Send(query);
            return result;
        }

        [HttpPost]
        public async Task<Customer> CreateCustomer(Customer model)
        {
            var command = new CreateCustomerCommand(model);
            var result = await _mediator.Send(command);
            return result;
        }

        [HttpPut]
        public async Task<Customer> UpdateCustomer(Customer model)
        {
            var command = new UpdateCustomerCommand(model);
            var result = await _mediator.Send(command);
            return result;
        }

        [HttpDelete]
        public async Task<bool> DeleteCustomerByEmail(string email)
        {
            var command = new DeleteCustomerByEmailCommand(email);
            var result = await _mediator.Send(command);
            return result;
        }

    }
}

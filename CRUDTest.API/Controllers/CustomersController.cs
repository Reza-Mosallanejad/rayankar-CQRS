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

        // GET: api/<Customers>
        [HttpGet]
        public async Task<List<Customer>> GetAll()
        {
            var query = new GetAllCustomersQuery();
            var result = await _mediator.Send(query);
            return result;
        }

        // POST api/<Customers>
        [HttpPost]
        public async Task<Customer> Post([FromBody] Customer model)
        {
            var command = new CreateCustomerCommand(model);
            var result = await _mediator.Send<Customer>(command);
            return result;
        }

    }
}

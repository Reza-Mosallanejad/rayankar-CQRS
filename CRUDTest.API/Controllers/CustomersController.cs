using CRUDTest.Application.Customers.Commands;
using CRUDTest.Application.Customers.Queries;
using CRUDTest.Domain.DTOs;
using CRUDTest.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("GetAll")]
        public async Task<List<CustomerDTO>> GetAllCustomers()
        {
            var query = new GetAllCustomersQuery();
            var result = await _mediator.Send(query);
            return result;
        }

        [HttpGet("GetByEmail")]
        public async Task<CustomerDTO> GetCustomerByEmail(string email)
        {
            var query = new GetCustomerByEmailQuery(email);
            var result = await _mediator.Send(query);
            return result;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateCustomer(CustomerDTO model)
        {
            var command = new CreateCustomerCommand(model);
            var opr = await _mediator.Send(command);

            if (opr.Status)
                return Ok(opr.Result);
            else
                return BadRequest(opr.Message);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateCustomer(CustomerDTO model)
        {
            var command = new UpdateCustomerCommand(model);
            var opr = await _mediator.Send(command);

            if (opr.Status)
                return Ok(opr.Result);
            else
                return BadRequest(opr.Message);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteCustomerByEmail(string email)
        {
            var command = new DeleteCustomerByEmailCommand(email);
            var opr = await _mediator.Send(command);

            if (opr.Status)
                return Ok(opr.Result);
            else
                return BadRequest(opr.Message);
        }

    }
}

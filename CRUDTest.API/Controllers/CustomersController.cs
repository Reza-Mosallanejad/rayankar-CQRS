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
        public async Task<IActionResult> GetAllCustomers()
        {
            var query = new GetAllCustomersQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("GetByEmail")]
        public async Task<IActionResult> GetCustomerByEmail(string email)
        {
            var query = new GetCustomerByEmailQuery(email);
            var result = await _mediator.Send(query);
            return result != null ? Ok(result) : NotFound();
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateCustomer(CreateCustomerCommand command)
        {
            var opr = await _mediator.Send(command);
            return opr.Status ? Ok(opr.Result) : BadRequest(opr.Message);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateCustomer(UpdateCustomerCommand command)
        {
            var opr = await _mediator.Send(command);
            return opr.Status ? Ok(opr.Result) : BadRequest(opr.Message);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteCustomerByEmail(DeleteCustomerByEmailCommand command)
        {
            var opr = await _mediator.Send(command);
            return opr.Status ? Ok(opr.Result) : BadRequest(opr.Message);
        }

    }
}

using System.Threading;
using System.Threading.Tasks;
using Application.Queires;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllEmployees")]
        public async Task<ActionResult<PagedResponse<EmployeeDto>>> GetAllEmployees(
        [FromQuery] EmployeeQueryParameters parameters,
        CancellationToken cancellationToken)
        {
            var query = new GetAllEmployeesQuery(parameters);   
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }
    }
}
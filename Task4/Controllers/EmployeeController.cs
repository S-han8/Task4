using Application.Commands;
using Application.Queires;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllEmployees")]
        public async Task<ActionResult<IEnumerable<EmployeeResponse>>> GetAllEmployees()
        {
            var result = await _mediator.Send(new GetAllEmployeesQuery());
            return Ok(result);
        }
    }
    }
}

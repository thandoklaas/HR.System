using HR.System.Application.feature.employees.commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http;
using FromBodyAttribute = System.Web.Http.FromBodyAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;

namespace HR.System.Controllers
{

    //[Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IHttpActionResult> CreateEmployee([FromBody] CreateEmployeeCommand command)
        {
            return (IHttpActionResult)Ok(await _mediator.Send(command));
        }


        [HttpPost]
        public async Task<IHttpActionResult> UpdateEmployee([FromBody] UpdateEmployeeCommand command)
        {
            return (IHttpActionResult)Ok(await _mediator.Send(command));
        }


        [HttpPost]
        public async Task<IHttpActionResult> ActivateEmployee([FromBody] ActivateEmployeeCommand command)
        {
            return (IHttpActionResult)Ok(await _mediator.Send(command));
        }

        [HttpPost]
        public async Task<IHttpActionResult> DeactivateEmployee([FromBody] DeactivateEmployeeCommand command)
        {
            return (IHttpActionResult)Ok(await _mediator.Send(command));
        }

    }
}

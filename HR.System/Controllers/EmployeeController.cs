using HR.System.Application.feature.employees.commands;
using HR.System.Application.feature.employees.queries;
using HR.System.Application.viewmodels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HR.System.Controllers;

[ApiController]
[Route("api/employee")]
[Authorize]
public sealed class EmployeeController : ControllerBase
{
    private readonly IMediator _mediator;

    public EmployeeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> CreateEmployee([FromBody] CreateEmployeeRequest request)
    {

        var command = new CreateEmployeeCommand(
            new EmployeeViewModel
            {
                EmployeeNumber = request.EmployeeNumber,
                Name = request.Name,
                Surname = request.Surname,
                HireDate = request.HireDate,
                AddressId = request.AddressId,
                ContactDetailId = request.ContactDetailId,
                DepartmentId = request.DepartmentId,
                EmployeeTypeId = request.EmployeeTypeId,
                ManagerId = request.ManagerId,
                JobTitleId = request.JobTitleId
            });


        var result = await _mediator.Send(command);

        return Ok(result);
    }

    //[Authorize]
    //[HttpPost("update")]
    //public async Task<IActionResult> UpdateEmployee(
    //    [FromBody] UpdateEmployeeCommand command)
    //{
    //    var result = await _mediator.Send(command);

    //    return Ok(result);
    //}

    //[Authorize]
    //[HttpPost("activate")]
    //public async Task<IActionResult> ActivateEmployee(
    //    [FromBody] ActivateEmployeeCommand command)
    //{
    //    var result = await _mediator.Send(command);

    //    return Ok(result);
    //}

    //[Authorize]
    //[HttpPost("deactivate")]
    //public async Task<IActionResult> DeactivateEmployee(
    //    [FromBody] DeactivateEmployeeCommand command)
    //{
    //    var result = await _mediator.Send(command);

    //    return Ok(result);
    //}

    //[Authorize]
    //[HttpGet]
    //public async Task<IActionResult> GetCollection(GetFilteredEmployeeCollectionRequest request)
    //{
    //    var collection = await _mediator.Send(request);
    //    return Ok(collection);
    //}

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var collection = await _mediator.Send(new GetEmployeeCollectionRequest());
        return Ok(collection);
    }


}


using AutoMapper;
using HR.System.Application.exceptions;
using HR.System.Application.interfaces;
using HR.System.Application.viewmodels;
using HR.System.Domain.entities;

namespace HR.System.Application.feature.employees.commands;

public class BaseEmployeeCommandHandler
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;
    private readonly IAuthenticationAdapter _adapter;

    protected BaseEmployeeCommandHandler(IUnitOfWork uow, IMapper mapper, IAuthenticationAdapter adapter)
    {
        _uow = uow;
        _mapper = mapper;
        _adapter = adapter;
    }

    protected async Task DuplicateCheck(EmployeeViewModel viewModel)
    {
        var duplicate = await _uow.Employee.AnyAsync(
                                            t => t.EmployeeId != viewModel.EmployeeId &&
                                            t.EmployeeNumber.Equals(viewModel.EmployeeNumber, StringComparison.InvariantCultureIgnoreCase));

        if (duplicate)
        {
            throw new DuplicationException(new[] { "Employee" });
        }
    }

    protected async Task<Employee> FindRecord(int id)
    {
        var employee = await _uow.Employee.FindAsync(id);

        if (employee == null)
        {
            throw new EntityNotFoundException("Employee", "Employee  Id", $"{id}");
        }

        return employee;
    }

    protected async Task<Employee> ConvertViewModelToModel(EmployeeViewModel viewModel)
    {
        var employeeModel = new Employee();

        if (viewModel.EmployeeId > 0)
        {
            var dbModel = await FindRecord(viewModel.EmployeeId);
            employeeModel = _mapper.Map(viewModel, dbModel);
        }
        else
        {
            employeeModel = _mapper.Map<Employee>(viewModel);   
        }

        return employeeModel;
    }



}




using AutoMapper;
using HR.System.Application.interfaces;
using HR.System.Application.viewmodels;
using MediatR;

namespace HR.System.Application.feature.employees.commands;

public class UpdateEmployeeCommand : IRequest<bool>
{
    public UpdateEmployeeCommand(EmployeeViewModel model)
    {
        Model = model;
    }

    public EmployeeViewModel Model { get; }
}
public class UpdateEmployeeCommandHandler : BaseEmployeeCommandHandler, IRequestHandler<UpdateEmployeeCommand, bool>
{
    private readonly IUnitOfWork _uow;

    public UpdateEmployeeCommandHandler(IMapper mapper, IUnitOfWork uow, IAuthenticationAdapter adapter)
        : base(uow, mapper, adapter)
    {
        _uow = uow;
    }

    public async Task<bool> Handle(UpdateEmployeeCommand command, CancellationToken cancellationToken)
    {
        using (var transaction = _uow.BeginTransaction())
        {
            try
            {
                await DuplicateCheck(command.Model);

                var model = await ConvertViewModelToModel(command.Model);

                var result = await _uow.Employee.UpdateAsync(model);

                transaction.Commit();

                return result;
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        }
    }


}


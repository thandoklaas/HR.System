

using AutoMapper;
using HR.System.Application.interfaces;
using MediatR;

namespace HR.System.Application.feature.employees.commands;

public class DeactivateEmployeeCommand : IRequest<bool>
{
    public DeactivateEmployeeCommand(int id)
    {
        Id = id;
    }

    public int Id { get; }
}

public class DeactivateEmployeeCommandHandler : BaseEmployeeCommandHandler, IRequestHandler<DeactivateEmployeeCommand, bool>
{
    private readonly IUnitOfWork _uow;

    public DeactivateEmployeeCommandHandler(IMapper mapper, IUnitOfWork uow, IAuthenticationAdapter adapter)
        : base(uow, mapper, adapter)
    {
        _uow = uow;
    }
    public async Task<bool> Handle(DeactivateEmployeeCommand command, CancellationToken cancellationToken)
    {
        using var transaction = _uow.BeginTransaction();
        try
        {
            var record = await FindRecord(command.Id);
            //deactivate the record
            record.IsActive = false;
            var result = await _uow.Employee.UpdateAsync(record);

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




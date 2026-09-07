

using AutoMapper;
using HR.System.Application.interfaces;
using MediatR;

namespace HR.System.Application.feature.employees.commands;

public class ActivateEmployeeCommand : IRequest<bool>
{
    public ActivateEmployeeCommand(int id)
    {
        Id = id;
    }

    public int Id { get; }
}

public class ActivateEmployeeCommandHandler : BaseEmployeeCommandHandler, IRequestHandler<ActivateEmployeeCommand, bool>
{
    private readonly IUnitOfWork _uow;

    public ActivateEmployeeCommandHandler(IMapper mapper, IUnitOfWork uow, IAuthenticationAdapter adapter)
        : base(uow, mapper, adapter)
    {
        _uow = uow;
    }
    public async Task<bool> Handle(ActivateEmployeeCommand command, CancellationToken cancellationToken)
    {
        using (var transaction = _uow.BeginTransaction())
        {
            try
            {
                var record = await FindRecord(command.Id);
                //Activate the record
                record.IsActive = true;
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

}




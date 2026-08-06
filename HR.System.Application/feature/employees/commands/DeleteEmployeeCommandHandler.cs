

using AutoMapper;
using HR.System.Application.interfaces;
using MediatR;

namespace HR.System.Application.feature.employees.commands;

public class DeleteEmployeeCommand : IRequest<bool>
{
    public DeleteEmployeeCommand(int id)
    {
        Id = id;
    }

    public int Id { get; }
}

public class DeleteEmployeeCommandHandler : BaseEmployeeCommandHandler, IRequestHandler<DeleteEmployeeCommand, bool>
{
    private readonly IUnitOfWork _uow;

    public DeleteEmployeeCommandHandler(IMapper mapper, IUnitOfWork uow, IAuthenticationAdapter adapter)
        : base(uow, mapper, adapter)
    {
        _uow = uow;
    }
    public async Task<bool> Handle(DeleteEmployeeCommand command, CancellationToken cancellationToken)
    {
        using (var transaction = _uow.BeginTransaction())
        {
            try
            {
                //find the record
                var record = await FindRecord(command.Id);
                //soft  delete the record
                record.IsDeleted = true;
                var result = await _uow.Employee.UpdateAsync(record);
                //var result = await _uow.Employee.DeleteAsync(record);
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





using AutoMapper;
using HR.System.Application.interfaces;
using HR.System.Application.viewmodels;
using MediatR;

namespace HR.System.Application.feature.employees.commands;

public class CreateEmployeeCommand : IRequest<bool>
{
    public CreateEmployeeCommand(EmployeeViewModel model)
    {
        Model = model;
    }

    public EmployeeViewModel Model { get; }
}
public class CreateEmployeeCommandHandler : BaseEmployeeCommandHandler, IRequestHandler<CreateEmployeeCommand, bool>
{
    private readonly IUnitOfWork _uow;
    private readonly IAuthenticationAdapter _adapter;
    private readonly IMapper _mapper;

    public CreateEmployeeCommandHandler(IUnitOfWork uow, IMapper mapper, IAuthenticationAdapter adapter) : base(uow, mapper, adapter)
    {
        _uow = uow;
        _adapter = adapter;
        _mapper = mapper;
    }
    public async Task<bool> Handle(CreateEmployeeCommand command, CancellationToken cancellationToken)
    {
        using (var transaction = _uow.BeginTransaction())
        {
            try
            {
                await DuplicateCheck(command.Model);

                var model = await ConvertViewModelToModel(command.Model);

                model.CreatedBy = _adapter.GetCurrentUserName();
                model.CreatedDate = DateTimeOffset.Now;

                var result = await _uow.Employee.AddAsync(model);

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


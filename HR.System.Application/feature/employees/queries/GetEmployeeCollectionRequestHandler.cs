using AutoMapper;
using HR.System.Application.interfaces;
using HR.System.Application.viewmodels;
using HR.System.Domain.entities;
using MediatR;

namespace HR.System.Application.feature.employees.queries;

public class GetEmployeeCollectionRequest : IRequest<List<EmployeeViewModel>>
{

}

public class GetEmployeeCollectionRequestHandler : IRequestHandler<GetEmployeeCollectionRequest, List<EmployeeViewModel>>
{
    private readonly IRepository<Employee> _repository;
    private readonly IMapper _mapper;

    public GetEmployeeCollectionRequestHandler(IRepository<Employee> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<EmployeeViewModel>> Handle(GetEmployeeCollectionRequest request, CancellationToken cancellationToken)
    {
        var result = await _repository.GetCollectionAsync();

        return result
            .Select(t => _mapper.Map<EmployeeViewModel>(t))
            .ToList();
    }
}

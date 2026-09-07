using AutoMapper;
using HR.System.Application.interfaces;
using HR.System.Application.viewmodels;
using HR.System.Domain.entities;
using MediatR;
using System.Linq.Expressions;

namespace HR.System.Application.feature.employees.queries;
public class GetFilteredEmployeeCollectionRequest : IRequest<List<EmployeeViewModel>>
{
    public int EmployeeId { get; set; }
    public string EmployeeNumber { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
}

public class GetFilteredEmployeeCollectionRequestHandler : IRequestHandler<GetFilteredEmployeeCollectionRequest, List<EmployeeViewModel>>
{
    private readonly IRepository<Employee> _repository;
    private readonly IMapper _mapper;

    public GetFilteredEmployeeCollectionRequestHandler(IRepository<Employee> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<EmployeeViewModel>> Handle(GetFilteredEmployeeCollectionRequest request, CancellationToken cancellationToken)
    {
        Expression<Func<Employee, bool>> expression = t =>
             (t.EmployeeId == request.EmployeeId) &&
             (!string.IsNullOrWhiteSpace(request.EmployeeNumber) && request.EmployeeNumber == t.EmployeeNumber) &&
             (!string.IsNullOrWhiteSpace(request.Name) && request.Name == t.Name) &&
             (!string.IsNullOrWhiteSpace(request.Surname) && request.Surname == t.Surname);

        var result = await _repository.GetCollectionByExpressionAsync(expression);

        return result
            .Select(t => _mapper.Map<EmployeeViewModel>(t))
            .ToList();
    }
}

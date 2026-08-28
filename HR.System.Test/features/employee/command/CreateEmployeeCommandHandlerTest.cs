using AutoMapper;
using HR.System.Application.exceptions;
using HR.System.Application.feature.employees.commands;
using HR.System.Application.interfaces;
using HR.System.Application.mappings;
using HR.System.Application.viewmodels;
using HR.System.Domain.entities;
using HR.System.Test.infrastructure;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;
namespace HR.System.Test.features.employee.command;

public class CreateEmployeeCommandHandlerTest
{
    //CreateMap<Employee, EmployeeViewModel>();
    private readonly IMapper config;

    private readonly CreateEmployeeCommandHandler _sut;
    public CreateEmployeeCommandHandlerTest()
    {
        var logg = new Mock<ILoggerFactory>();

        logg.Setup(x => x.CreateLogger(It.IsAny<string>())).Returns(new Mock<ILogger>().Object);

        config = new MapperConfiguration(c =>
        {
            c.AddProfile(new EmployeeViewModelMappingProfile());
            c.AddProfile(new EmployeeDbModelMappingProfile());
        }, logg.Object).CreateMapper();

        var authAdapter = new Mock<IAuthenticationAdapter>();
        authAdapter.Setup(e => e.GetCurrentUserName()).Returns("testusername");

        _sut = new CreateEmployeeCommandHandler(CreateMockUnitOfWork(), config, authAdapter.Object);

    }

    [Fact]
    public async Task WhenEmployeeExist_Handle_ShouldThrowDuplicateException()
    {
        // Arrange
        var model = new EmployeeViewModel
        {
            EmployeeNumber = "EMP001",
            EmployeeId = 1
        };
        var request = new CreateEmployeeCommand(model);

        // Assert
        await Assert.ThrowsAsync<DuplicationException>(async () =>
            await _sut.Handle(request, new CancellationToken()));
    }

    private IUnitOfWork CreateMockUnitOfWork()
    {
        var mockUow = new Mock<IUnitOfWork>();


        Address EmployeeAddress = new Address
        {
            AddressId = 1,
            UnitNumber = "Apt 101",
            Street = "123 Main St",
            Suburb = "Downtown",
            Town = "New York",
            Province = "NY",
            PostalCode = "10001",
        };

       Address EmployeeAddress2 = new Address
        {

            AddressId = 2,
            UnitNumber = "Apt 20",
            Street = "456 Elm St",
            Suburb = "Downtown",
            Town = "New York",
            Province = "CA",
            PostalCode = "90001",

        };
        Address EmployeeAddress3 = new Address
        {
            AddressId = 3,
            Street = "789 Oak St",
            PostalCode = "90001",
            UnitNumber = "Apt 110",
            Suburb = "Uptown",
            Town = "Chicago",
            Province = "IL",
        };

        Address EmployeeAddress4 = new Address
        {
            AddressId = 4,
            Street = "101 Pine St",
            UnitNumber = "Apt 23",
            Town = "Houston",
            Province = "TX",
            PostalCode = "77001",
            Suburb = "Midtown"
        };

        //Job title mock data
        JobTitle JobTitle1 = new JobTitle
        {
            JobTitleId = 1,
            JobTitleName = "Software Engineer",
            Description = "Responsible for developing software applications",
            IsActive = true
        };
        JobTitle JobTitle2 = new JobTitle
        {
            JobTitleId = 2,
            JobTitleName = "Project Manager",
            Description = "Responsible for managing projects and teams",
            IsActive = true
        };
        JobTitle JobTitle3 = new JobTitle
        {
            JobTitleId = 3,
            JobTitleName = "HR Specialist",
            Description = "Responsible for handling HR-related tasks and employee relations",
            IsActive = true
        };
        JobTitle JobTitle4 = new JobTitle
        {
            JobTitleId = 4,
            JobTitleName = "Finance Analyst",
            Description = "Responsible for analyzing financial data and providing insights",
            IsActive = true
        };

        //contact detail mock data
        ContactDetail EmployeeContactDetails = new ContactDetail
        {

            ContactDetailId = 1,
            Mobile = "1234567890",
            AlternateMobile = "0987654321",
            Email = "tim@gmail.com",
            WorkEmail = "tim@atwork.com"

        };

        ContactDetail EmployeeContactDetails2 = new ContactDetail
        {
            ContactDetailId = 2,
            Mobile = "1234567890",
            AlternateMobile = "0987654321",
            Email = "tim2@gmail.com",
            WorkEmail = "tim2@atwork.com"
        };
        ContactDetail EmployeeContactDetails3 = new ContactDetail
        {
            ContactDetailId = 3,
            Mobile = "1234567890",
            AlternateMobile = "0987654321",
            Email = "tim3@gmail.com",
            WorkEmail = "tim3@atwork.com"
        };
        //department mock data
        Department Department1 = new Department
        {

            DepartmentId = 1,
            DepartmentName = "Human Resources",
            DepartmentCode = "HR",
            Description = "Handles employee relations and recruitment",
            IsActive = true
        };
        Department Department2 = new Department
        {

            DepartmentId = 2,
            DepartmentName = "Software Engineering and Architecture",
            DepartmentCode = "ICT",
            Description = "Handles Software Engineering and Architecture",
            IsActive = true
        };
        Department Department3 = new Department
        {

            DepartmentId = 3,
            DepartmentName = "Finance",
            DepartmentCode = "FIN",
            Description = "Handles all finance related matters",
            IsActive = true
        };
        //employee type mock data
        EmployeeType EmployeeType1 = new EmployeeType
        {
            EmployeeTypeId = 1,
            Description = "Full-Time",
            Code = "FT",
            IsActive = true
        };
        EmployeeType EmployeeType2 = new EmployeeType
        {
            EmployeeTypeId = 2,
            Description = "Part-Time",
            Code = "PT",
            IsActive = true
        };
        EmployeeType EmployeeType3 = new EmployeeType
        {
            EmployeeTypeId = 3,
            Description = "Contractor",
            Code = "CT",
            IsActive = true
        };


        //Employee mock data
    
        Employee Employee2 = new Employee
        {
            EmployeeId = 2,
            EmployeeNumber = "EMP002",
            Name = "Jane",
            Surname = "Smith",
            IsActive = true,
            HireDate = new DateOnly(2021, 5, 15),
            TerminationDate = null,
            AddressId = 2,
            ContactDetailId = 2,
            DepartmentId = 2,
            EmployeeTypeId = 2,
            ManagerId = 2,
            JobTitleId = 2,
            IdentityUserId = null,
            EmployeeAddress = EmployeeAddress2,
            EmployeeType = EmployeeType2,
            EmployeeContactDetails = EmployeeContactDetails2,
            EmployeeRoles = new List<EmployeeRole>
            {
                new EmployeeRole
                {
                    EmployeeRoleId = 1,
                    EmployeeId = 2,
                    RoleId = 1,
                     Role = new Role {
                        RoleId = 1,
                        RoleName = "Admin",
                        Description = "Administrator role with full access",
                        IsActive = true
                     }
                    //IsActive = true
                },
                new EmployeeRole{
                    EmployeeRoleId = 2,
                    EmployeeId = 2,
                    RoleId = 2,
                     Role = new Role {
                        RoleId = 2,
                        RoleName = "Manager",
                        Description = "Manager role with limited access",
                        IsActive = true
                     }
                    //IsActive = true
                },
                new EmployeeRole{
                    EmployeeRoleId = 3,
                    EmployeeId = 2,
                    RoleId = 3,
                     Role = new Role {
                        RoleId = 3,
                        RoleName = "Employee",
                        Description = "Employee role with basic access",
                        IsActive = true
                     }
                    //IsActive = true
                }
            }
        };

        Employee Employee3 = new Employee
        {
            EmployeeId = 3,
            EmployeeNumber = "EMP003",
            Name = "Michael",
            Surname = "Johnson",
            IsActive = true,
            HireDate = new DateOnly(2022, 3, 10),
            TerminationDate = null,
            AddressId = 3,
            ContactDetailId = 3,
            DepartmentId = 1,
            EmployeeTypeId = 1,
            ManagerId = 2,
            JobTitleId = 3,
            IdentityUserId = null,
            EmployeeAddress = EmployeeAddress3,
            EmployeeType = EmployeeType3,
            EmployeeContactDetails = EmployeeContactDetails3,
            Manager = Employee2,
            EmployeeRoles = new List<EmployeeRole>
            {
                new EmployeeRole{
                    EmployeeRoleId = 3,
                    EmployeeId = 3,
                    RoleId = 3,
                     Role = new Role {
                        RoleId = 3,
                        RoleName = "Employee",
                        Description = "Employee role with basic access",
                        IsActive = true
                     }
                    //IsActive = true
                }
            }
        };

        Employee Employee = new Employee
        {
            EmployeeId = 1,
            EmployeeNumber = "EMP001",
            Name = "John",
            Surname = "Doe",
            IsActive = true,
            HireDate = new DateOnly(2020, 1, 1),
            TerminationDate = null,
            AddressId = 1,
            ContactDetailId = 1,
            DepartmentId = 1,
            EmployeeTypeId = 1,
            ManagerId = 2,
            JobTitleId = 1,
            IdentityUserId = null,
            EmployeeAddress = EmployeeAddress,
            EmployeeType = EmployeeType1,
            EmployeeContactDetails = EmployeeContactDetails,
            Manager = Employee2,
            EmployeeRoles = new List<EmployeeRole>
            {
                new EmployeeRole{
                    EmployeeRoleId = 3,
                    EmployeeId = 3,
                    RoleId = 3,
                     Role = new Role {
                        RoleId = 3,
                        RoleName = "Employee",
                        Description = "Employee role with basic access",
                        IsActive = true
                     }
                    //IsActive = true
                }
            }
        };

        // Database transaction
        mockUow.Setup(d => d.BeginTransaction())
            .Returns(new InMemoryDatabaseTransaction());

        mockUow.Setup(e => e.Employee)
            .Returns(new InMemoryRepository<Employee>(new List<Employee>
            {
                Employee,
                Employee2,
                Employee3
            }));

        return mockUow.Object;
    }

}

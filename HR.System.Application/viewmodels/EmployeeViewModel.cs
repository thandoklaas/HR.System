using HR.System.Domain.entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.System.Application.viewmodels;

public class EmployeeViewModel
{
    public int EmployeeId { get; set; }

    public string EmployeeNumber { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public string Surname { get; set; } = string.Empty;

    public bool IsActive { get; set; } = true;

    public DateOnly HireDate { get; set; }

    public DateOnly? TerminationDate { get; set; }

    #region Foreign Keys

    public int AddressId { get; set; }

    public Address EmployeeAddress { get; set; } = null!;

    public int ContactDetailId { get; set; }

    public ContactDetail EmployeeContactDetails { get; set; } = null!;

    public int DepartmentId { get; set; }

    public Department Department { get; set; } = null!;

    public int EmployeeTypeId { get; set; }

    public EmployeeType EmployeeType { get; set; } = null!;

    public int? ManagerId { get; set; }

    public Employee? Manager { get; set; }

    public int JobTitleId { get; set; }

    public JobTitle JobTitle { get; set; } = null!;

    public int? IdentityUserId { get; set; }

    //public ApplicationUser? IdentityUser { get; set; }

    #endregion

    #region Navigation Collections

    public ICollection<Employee> DirectReports { get; set; }
        = new List<Employee>();

    public ICollection<EmployeeRole> EmployeeRoles { get; set; }
        = new List<EmployeeRole>();

    public ICollection<LeaveRequest> LeaveRequests { get; set; }
        = new List<LeaveRequest>();

    public ICollection<LeaveBalance> LeaveBalances { get; set; }
        = new List<LeaveBalance>();

    public ICollection<Document> UploadedDocuments { get; set; }
        = new List<Document>();

    public ICollection<AuditLog> AuditLogs { get; set; }
        = new List<AuditLog>();


    public ICollection<EmployeeRole> AssignedRoles { get; set; }
        = new List<EmployeeRole>();

    public ICollection<LeaveResponse> LeaveResponses { get; set; }
        = new List<LeaveResponse>();

    public ICollection<AuditLog> PerformedAuditLogs { get; set; }
        = new List<AuditLog>();

    #endregion

    #region Computed Properties

    public string FullName => $"{Name} {Surname}";

    #endregion
}


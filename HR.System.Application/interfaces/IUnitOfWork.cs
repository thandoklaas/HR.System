using HR.System.Domain.entities;

namespace HR.System.Application.interfaces
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// This Provides transaction support for
        /// the underlying database context
        /// </summary>
        /// <returns>IDatabaseTransaction</returns>
        IDatabaseTransaction BeginTransaction();

        public IRepository<Address> Address { get; }
        public IRepository<ContactDetail> ContactDetail { get; }
        public IRepository<Employee> Employee { get; }
        public IRepository<EmployeeRole> EmployeeRole { get; }
        public IRepository<Role> Role { get; }
        public IRepository<Department> Department { get; }
        public IRepository<JobTitle> JobTitle { get; }
        public IRepository<EmployeeType> EmployeeType { get; }
        public IRepository<LeaveRequest> LeaveRequest { get; }
        public IRepository<LeaveResponse> LeaveResponse { get; }
        public IRepository<LeaveBalance> LeaveBalance { get; }
        public IRepository<LeaveType> LeaveType { get; }
        public IRepository<LeaveStatus> LeaveStatus { get; }
        public IRepository<Document> Document { get; }
        public IRepository<AuditLog> AuditLog { get; }
    }
}

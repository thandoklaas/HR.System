using HR.System.Domain.entities;
using HR.System.Infrastructure.persistance;

namespace HR.System.Infrastructure.repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LeaveDbContext _db;

        public UnitOfWork(LeaveDbContext db)
        {
            _db = db;
        }

        public IRepository<Address> Address => new EntityFrameworkRepository<Address>(_db);
        public IRepository<ContactDetail> ContactDetail => new EntityFrameworkRepository<ContactDetail>(_db);
        public IRepository<Employee> Employee => new EntityFrameworkRepository<Employee>(_db);
        public IRepository<EmployeeRole> EmployeeRole => new EntityFrameworkRepository<EmployeeRole>(_db);
        public IRepository<Role> Role => new EntityFrameworkRepository<Role>(_db);
        public IRepository<Department> Department => new EntityFrameworkRepository<Department>(_db);
        public IRepository<JobTitle> JobTitle => new EntityFrameworkRepository<JobTitle>(_db);
        public IRepository<EmployeeType> EmployeeType => new EntityFrameworkRepository<EmployeeType>(_db);
        public IRepository<LeaveRequest> LeaveRequest => new EntityFrameworkRepository<LeaveRequest>(_db);
        public IRepository<LeaveResponse> LeaveResponse => new EntityFrameworkRepository<LeaveResponse>(_db);
        public IRepository<LeaveBalance> LeaveBalance => new EntityFrameworkRepository<LeaveBalance>(_db);
        public IRepository<LeaveType> LeaveType => new EntityFrameworkRepository<LeaveType>(_db);
        public IRepository<LeaveStatus> LeaveStatus => new EntityFrameworkRepository<LeaveStatus>(_db);
        public IRepository<Document> Document => new EntityFrameworkRepository<Document>(_db);
        public IRepository<AuditLog> AuditLog => new EntityFrameworkRepository<AuditLog>(_db);

        public IDatabaseTransaction BeginTransaction()
            => new EntityDatabaseTransaction(_db);
    }
}

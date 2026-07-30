

namespace HR.System.Infrastructure.identity
{
    public class Permissions
    {
        public static class Employees
        {
            public const string View = "Employees.View";
            public const string Create = "Employees.Create";
            public const string Update = "Employees.Update";
            public const string Delete = "Employees.Delete";
        }

        public static class Leave
        {
            public const string View = "Leave.View";
            public const string Create = "Leave.Create";
            public const string Approve = "Leave.Approve";
            public const string Reject = "Leave.Reject";
            public const string Cancel = "Leave.Cancel";
        }

        public static class Documents
        {
            public const string Upload = "Documents.Upload";
            public const string Download = "Documents.Download";
            public const string Delete = "Documents.Delete";
        }

        public static class Administration
        {
            public const string ManageUsers = "Administration.ManageUsers";
            public const string ManageRoles = "Administration.ManageRoles";
            public const string Audit = "Administration.Audit";
        }
    }
}

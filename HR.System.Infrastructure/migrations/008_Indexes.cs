using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HR.System.Infrastructure.migrations
{
    public partial class _008_Indexes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //==============================================================
            // Employees
            //==============================================================

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeNumber",
                table: "Employees",
                column: "EmployeeNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeTypeId",
                table: "Employees",
                column: "EmployeeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ManagerId",
                table: "Employees",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_IsActive",
                table: "Employees",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Name_Surname",
                table: "Employees",
                columns: new[] { "Surname", "Name" });

            //==============================================================
            // Employee Roles
            //==============================================================

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeRoles_EmployeeId",
                table: "EmployeeRoles",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeRoles_RoleId",
                table: "EmployeeRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeRoles_IsPrimary",
                table: "EmployeeRoles",
                column: "IsPrimary");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeRoles_EffectiveFrom",
                table: "EmployeeRoles",
                column: "EffectiveFrom");

            //==============================================================
            // Leave Requests
            //==============================================================

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequests_EmployeeId",
                table: "LeaveRequests",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequests_LeaveTypeId",
                table: "LeaveRequests",
                column: "LeaveTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequests_CurrentStatusId",
                table: "LeaveRequests",
                column: "CurrentStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequests_DocumentId",
                table: "LeaveRequests",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequests_Start_End",
                table: "LeaveRequests",
                columns: new[]
                {
                    "StartDateTime",
                    "EndDateTime"
                });

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequests_IsActive",
                table: "LeaveRequests",
                column: "IsActive");

            //==============================================================
            // Leave Responses
            //==============================================================

            migrationBuilder.CreateIndex(
                name: "IX_LeaveResponses_LeaveRequestId",
                table: "LeaveResponses",
                column: "LeaveRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveResponses_LeaveResponseEmployeeId",
                table: "LeaveResponses",
                column: "LeaveResponseEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveResponses_LeaveStatusId",
                table: "LeaveResponses",
                column: "LeaveStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveResponses_IsCurrent",
                table: "LeaveResponses",
                column: "IsCurrent");

            //==============================================================
            // Leave Balances
            //==============================================================

            migrationBuilder.CreateIndex(
                name: "IX_LeaveBalances_EmployeeId",
                table: "LeaveBalances",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveBalances_LeaveTypeId",
                table: "LeaveBalances",
                column: "LeaveTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveBalances_LeaveYear",
                table: "LeaveBalances",
                column: "LeaveYear");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveBalances_Employee_LeaveType_Year",
                table: "LeaveBalances",
                columns: new[]
                {
                    "EmployeeId",
                    "LeaveTypeId",
                    "LeaveYear"
                },
                unique: true);

            //==============================================================
            // Documents
            //==============================================================

            migrationBuilder.CreateIndex(
                name: "IX_Documents_UploadedByEmployeeId",
                table: "Documents",
                column: "UploadedByEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_UploadedDate",
                table: "Documents",
                column: "UploadedDate");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_IsDeleted",
                table: "Documents",
                column: "IsDeleted");

            //==============================================================
            // Audit Logs
            //==============================================================

            migrationBuilder.CreateIndex(
                name: "IX_AuditLogs_PerformedByEmployeeId",
                table: "AuditLogs",
                column: "PerformedByEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_AuditLogs_TableName",
                table: "AuditLogs",
                column: "TableName");

            migrationBuilder.CreateIndex(
                name: "IX_AuditLogs_Action",
                table: "AuditLogs",
                column: "Action");

            migrationBuilder.CreateIndex(
                name: "IX_AuditLogs_CorrelationId",
                table: "AuditLogs",
                column: "CorrelationId");

            migrationBuilder.CreateIndex(
                name: "IX_AuditLogs_CreatedDate",
                table: "AuditLogs",
                column: "CreatedDate");

            //==============================================================
            // Lookup Tables
            //==============================================================

            migrationBuilder.CreateIndex(
                name: "IX_Departments_DepartmentDescription",
                table: "Departments",
                column: "DepartmentDescription",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTypes_EmployeeTypeDescription",
                table: "EmployeeTypes",
                column: "EmployeeTypeDescription",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobTitles_JobTitleDescription",
                table: "JobTitles",
                column: "JobTitleDescription",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LeaveTypes_Description",
                table: "LeaveTypes",
                column: "Description",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LeaveStatuses_Description",
                table: "LeaveStatuses",
                column: "Description",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_RoleDescription",
                table: "Roles",
                column: "RoleDescription",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex("IX_Employees_EmployeeNumber", "Employees");
            migrationBuilder.DropIndex("IX_Employees_DepartmentId", "Employees");
            migrationBuilder.DropIndex("IX_Employees_EmployeeTypeId", "Employees");
            migrationBuilder.DropIndex("IX_Employees_ManagerId", "Employees");
            migrationBuilder.DropIndex("IX_Employees_IsActive", "Employees");
            migrationBuilder.DropIndex("IX_Employees_Name_Surname", "Employees");

            migrationBuilder.DropIndex("IX_EmployeeRoles_EmployeeId", "EmployeeRoles");
            migrationBuilder.DropIndex("IX_EmployeeRoles_RoleId", "EmployeeRoles");
            migrationBuilder.DropIndex("IX_EmployeeRoles_IsPrimary", "EmployeeRoles");
            migrationBuilder.DropIndex("IX_EmployeeRoles_EffectiveFrom", "EmployeeRoles");

            migrationBuilder.DropIndex("IX_LeaveRequests_EmployeeId", "LeaveRequests");
            migrationBuilder.DropIndex("IX_LeaveRequests_LeaveTypeId", "LeaveRequests");
            migrationBuilder.DropIndex("IX_LeaveRequests_CurrentStatusId", "LeaveRequests");
            migrationBuilder.DropIndex("IX_LeaveRequests_DocumentId", "LeaveRequests");
            migrationBuilder.DropIndex("IX_LeaveRequests_Start_End", "LeaveRequests");
            migrationBuilder.DropIndex("IX_LeaveRequests_IsActive", "LeaveRequests");

            migrationBuilder.DropIndex("IX_LeaveResponses_LeaveRequestId", "LeaveResponses");
            migrationBuilder.DropIndex("IX_LeaveResponses_LeaveResponseEmployeeId", "LeaveResponses");
            migrationBuilder.DropIndex("IX_LeaveResponses_LeaveStatusId", "LeaveResponses");
            migrationBuilder.DropIndex("IX_LeaveResponses_IsCurrent", "LeaveResponses");

            migrationBuilder.DropIndex("IX_LeaveBalances_EmployeeId", "LeaveBalances");
            migrationBuilder.DropIndex("IX_LeaveBalances_LeaveTypeId", "LeaveBalances");
            migrationBuilder.DropIndex("IX_LeaveBalances_LeaveYear", "LeaveBalances");
            migrationBuilder.DropIndex("IX_LeaveBalances_Employee_LeaveType_Year", "LeaveBalances");

            migrationBuilder.DropIndex("IX_Documents_UploadedByEmployeeId", "Documents");
            migrationBuilder.DropIndex("IX_Documents_UploadedDate", "Documents");
            migrationBuilder.DropIndex("IX_Documents_IsDeleted", "Documents");

            migrationBuilder.DropIndex("IX_AuditLogs_PerformedByEmployeeId", "AuditLogs");
            migrationBuilder.DropIndex("IX_AuditLogs_TableName", "AuditLogs");
            migrationBuilder.DropIndex("IX_AuditLogs_Action", "AuditLogs");
            migrationBuilder.DropIndex("IX_AuditLogs_CorrelationId", "AuditLogs");
            migrationBuilder.DropIndex("IX_AuditLogs_CreatedDate", "AuditLogs");

            migrationBuilder.DropIndex("IX_Departments_DepartmentDescription", "Departments");
            migrationBuilder.DropIndex("IX_EmployeeTypes_EmployeeTypeDescription", "EmployeeTypes");
            migrationBuilder.DropIndex("IX_JobTitles_JobTitleDescription", "JobTitles");
            migrationBuilder.DropIndex("IX_LeaveTypes_Description", "LeaveTypes");
            migrationBuilder.DropIndex("IX_LeaveStatuses_Description", "LeaveStatuses");
            migrationBuilder.DropIndex("IX_Roles_RoleDescription", "Roles");
        }
    }
}
using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HR.System.Infrastructure.migrations
{
    public partial class _002_Lookups : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var currentDate = new DateTime(2026, 07, 30, 0, 0, 0, DateTimeKind.Utc);
            //===========================================================
            // Departments
            //===========================================================

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1,1"),

                    DepartmentName = table.Column<string>(maxLength: 100, nullable: false),

                    DepartmentCode = table.Column<string>(maxLength: 20, nullable: false),

                    Description = table.Column<string>(maxLength: 500, nullable: true),

                    IsActive = table.Column<bool>(nullable: false, defaultValue: true),

                    CreatedDate = table.Column<DateTime>(nullable: false),

                    CreatedBy = table.Column<string>(maxLength: 100, nullable: false),

                    ModifiedDate = table.Column<DateTime>(nullable: true),

                    ModifiedBy = table.Column<string>(maxLength: 100, nullable: true),

                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departments_DepartmentCode",
                table: "Departments",
                column: "DepartmentCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departments_DepartmentName",
                table: "Departments",
                column: "DepartmentName",
                unique: true);

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[]
                {
                    "DepartmentId",
                    "DepartmentName",
                    "DepartmentCode",
                    "Description",
                    "IsActive",
                    "CreatedDate",
                    "CreatedBy"
                },
                values: new object[,]
                {
                    {1,"Human Resources","HR","Human Resources",true, currentDate,"System"},
                    {2,"Information Technology","IT","Information Technology",true, currentDate,"System"},
                    {3,"Finance","FIN","Finance",true, currentDate,"System"},
                    {4,"Operations","OPS","Operations",true, currentDate,"System"},
                    {5,"Procurement","PROC","Procurement",true, currentDate,"System"},
                    {6,"Legal","LEG","Legal",true, currentDate,"System"},
                    {7,"Marketing","MKT","Marketing",true, currentDate,"System"},
                    {8,"Executive","EXEC","Executive",true, currentDate,"System"}
                });

            //===========================================================
            // Employee Types
            //===========================================================

            migrationBuilder.CreateTable(
                name: "EmployeeTypes",
                columns: table => new
                {
                    EmployeeTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1,1"),

                    Description = table.Column<string>(maxLength: 100, nullable: false),

                    Code = table.Column<string>(maxLength: 20, nullable: false),

                    IsActive = table.Column<bool>(nullable: false, defaultValue: true),

                    CreatedDate = table.Column<DateTime>(nullable: false),

                    CreatedBy = table.Column<string>(maxLength: 100, nullable: false),

                    ModifiedDate = table.Column<DateTime>(nullable: true),

                    ModifiedBy = table.Column<string>(maxLength: 100, nullable: true),

                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTypes", x => x.EmployeeTypeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTypes_Code",
                table: "EmployeeTypes",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTypes_Description",
                table: "EmployeeTypes",
                column: "Description",
                unique: true);

            migrationBuilder.InsertData(
                table: "EmployeeTypes",
                columns: new[]
                {
                    "EmployeeTypeId",
                    "Description",
                    "Code",
                    "IsActive",
                    "CreatedDate",
                    "CreatedBy"
                },
                values: new object[,]
                {
                    {1,"Permanent","PERM",true,currentDate, "System"},
                    {2,"Contract","CONT",true,currentDate, "System"},
                    {3,"Temporary","TEMP",true,currentDate, "System"},
                    {4,"Intern","INT",true,currentDate, "System"},
                    {5,"Consultant","CONS",true,currentDate, "System"}
                });

            //===========================================================
            // Job Titles
            //===========================================================

            migrationBuilder.CreateTable(
                name: "JobTitles",
                columns: table => new
                {
                    JobTitleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1,1"),

                    JobTitleName = table.Column<string>(maxLength: 150, nullable: false),

                    JobCode = table.Column<string>(maxLength: 20, nullable: false),

                    Description = table.Column<string>(maxLength: 500, nullable: true),

                    IsManagementRole = table.Column<bool>(nullable: false),

                    IsActive = table.Column<bool>(nullable: false, defaultValue: true),

                    CreatedDate = table.Column<DateTime>(nullable: false),

                    CreatedBy = table.Column<string>(maxLength: 100, nullable: false),

                    ModifiedDate = table.Column<DateTime>(nullable: true),

                    ModifiedBy = table.Column<string>(maxLength: 100, nullable: true),

                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTitles", x => x.JobTitleId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobTitles_JobCode",
                table: "JobTitles",
                column: "JobCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobTitles_JobTitleName",
                table: "JobTitles",
                column: "JobTitleName",
                unique: true);

            migrationBuilder.InsertData(
                table: "JobTitles",
                columns: new[]
                {
                    "JobTitleId",
                    "JobTitleName",
                    "JobCode",
                    "Description",
                    "IsManagementRole",
                    "IsActive",
                    "CreatedDate",
                    "CreatedBy"
                },
                values: new object[,]
                {
                    {1,"Software Engineer","SWE","Software Engineer",false,true, currentDate,"System"},
                    {2,"Senior Software Engineer","SSWE","Senior Software Engineer",false,true, currentDate,"System"},
                    {3,"Technical Lead","TL","Technical Lead",true,true, currentDate,"System"},
                    {4,"Development Manager","DM","Development Manager",true,true, currentDate,"System"},
                    {5,"HR Officer","HRO","Human Resources Officer",false,true, currentDate,"System"},
                    {6,"HR Manager","HRM","Human Resources Manager",true,true, currentDate,"System"},
                    {7,"Finance Officer","FO","Finance Officer",false,true, currentDate,"System"},
                    {8,"General Manager","GM","General Manager",true,true, currentDate,"System"},
                    {9,"Chief Executive Officer","CEO","Chief Executive Officer",true,true, currentDate,"System"}
                });

            // Roles, LeaveTypes, LeaveStatuses
            //===========================================================
            // Roles
            //===========================================================

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1,1"),

                    RoleName = table.Column<string>(maxLength: 100, nullable: false),

                    RoleCode = table.Column<string>(maxLength: 20, nullable: false),

                    Description = table.Column<string>(maxLength: 500, nullable: true),

                    IsSystemRole = table.Column<bool>(nullable: false, defaultValue: false),

                    IsActive = table.Column<bool>(nullable: false, defaultValue: true),

                    CreatedDate = table.Column<DateTime>(nullable: false),

                    CreatedBy = table.Column<string>(maxLength: 100, nullable: false),

                    ModifiedDate = table.Column<DateTime>(nullable: true),

                    ModifiedBy = table.Column<string>(maxLength: 100, nullable: true),

                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Roles_RoleCode",
                table: "Roles",
                column: "RoleCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_RoleName",
                table: "Roles",
                column: "RoleName",
                unique: true);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[]
                {
                    "RoleId",
                    "RoleName",
                    "RoleCode",
                    "Description",
                    "IsSystemRole",
                    "IsActive",
                    "CreatedDate",
                    "CreatedBy"
                },
                values: new object[,]
                {
                    {1,"Employee","EMP","Standard Employee",false,true,currentDate,"System"},
                    {2,"Supervisor","SUP","Supervisor",false,true,currentDate,"System"},
                    {3,"Manager","MGR","Manager",false,true,currentDate,"System"},
                    {4,"HR Administrator","HRADMIN","Human Resources Administrator",true,true,currentDate,"System"},
                    {5,"System Administrator","SYSADMIN","Application Administrator",true,true,currentDate,"System"}
                });

            //===========================================================
            // Leave Types
            //===========================================================

            migrationBuilder.CreateTable(
                name: "LeaveTypes",
                columns: table => new
                {
                    LeaveTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1,1"),

                    Description = table.Column<string>(maxLength: 100, nullable: false),

                    RequiresDocument = table.Column<bool>(nullable: false),

                    DefaultDaysPerYear = table.Column<decimal>(
                        type: "decimal(5,2)",
                        nullable: false),

                    MaxDaysPerRequest = table.Column<decimal>(
                        type: "decimal(5,2)",
                        nullable: false),

                    IsPaidLeave = table.Column<bool>(nullable: false),

                    IsActive = table.Column<bool>(nullable: false, defaultValue: true),

                    CreatedDate = table.Column<DateTime>(nullable: false),

                    CreatedBy = table.Column<string>(maxLength: 100, nullable: false),

                    ModifiedDate = table.Column<DateTime>(nullable: true),

                    ModifiedBy = table.Column<string>(maxLength: 100, nullable: true),

                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveTypes", x => x.LeaveTypeId);

                    table.CheckConstraint(
                        "CK_LeaveTypes_DefaultDays",
                        "[DefaultDaysPerYear] >= 0");

                    table.CheckConstraint(
                        "CK_LeaveTypes_MaxDays",
                        "[MaxDaysPerRequest] >= 0");
                });

            migrationBuilder.CreateIndex(
                name: "IX_LeaveTypes_Description",
                table: "LeaveTypes",
                column: "Description",
                unique: true);

            migrationBuilder.InsertData(
                table: "LeaveTypes",
                columns: new[]
                {
                    "LeaveTypeId",
                    "Description",
                    "RequiresDocument",
                    "DefaultDaysPerYear",
                    "MaxDaysPerRequest",
                    "IsPaidLeave",
                    "IsActive",
                    "CreatedDate",
                    "CreatedBy"
                },
                values: new object[,]
                {
                    {1,"Annual Leave",false,15m,15m,true,true,currentDate,"System"},
                    {2,"Sick Leave",true,30m,30m,true,true,currentDate,"System"},
                    {3,"Family Responsibility",false,5m,5m,true,true,currentDate,"System"},
                    {4,"Study Leave",true,10m,10m,true,true,currentDate,"System"},
                    {5,"Maternity Leave",false,120m,120m,true,true,currentDate,"System"},
                    {6,"Paternity Leave",false,10m,10m,true,true,currentDate,"System"},
                    {7,"Unpaid Leave",false,365m,365m,false,true,currentDate,"System"}
                });

            //===========================================================
            // Leave Statuses
            //===========================================================

            migrationBuilder.CreateTable(
                name: "LeaveStatuses",
                columns: table => new
                {
                    LeaveStatusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1,1"),

                    Description = table.Column<string>(maxLength: 50, nullable: false),

                    DisplayOrder = table.Column<int>(nullable: false),

                    IsFinalStatus = table.Column<bool>(nullable: false),

                    IsActive = table.Column<bool>(nullable: false, defaultValue: true),

                    CreatedDate = table.Column<DateTime>(nullable: false),

                    CreatedBy = table.Column<string>(maxLength: 100, nullable: false),

                    ModifiedDate = table.Column<DateTime>(nullable: true),

                    ModifiedBy = table.Column<string>(maxLength: 100, nullable: true),

                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveStatuses", x => x.LeaveStatusId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LeaveStatuses_Description",
                table: "LeaveStatuses",
                column: "Description",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LeaveStatuses_DisplayOrder",
                table: "LeaveStatuses",
                column: "DisplayOrder");

            migrationBuilder.InsertData(
                table: "LeaveStatuses",
                columns: new[]
                {
                    "LeaveStatusId",
                    "Description",
                    "DisplayOrder",
                    "IsFinalStatus",
                    "IsActive",
                    "CreatedDate",
                    "CreatedBy"
                },
                values: new object[,]
                {
                    {1,"Pending",1,false,true,currentDate,"System"},
                    {2,"Submitted",2,false,true,currentDate,"System"},
                    {3,"Under Review",3,false,true,currentDate,"System"},
                    {4,"Approved",4,true,true,currentDate,"System"},
                    {5,"Rejected",5,true,true,currentDate,"System"},
                    {6,"Cancelled",6,true,true,currentDate,"System"}
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "LeaveStatuses");
            migrationBuilder.DropTable(name: "LeaveTypes");
            migrationBuilder.DropTable(name: "Roles");
            migrationBuilder.DropTable(name: "JobTitles");
            migrationBuilder.DropTable(name: "EmployeeTypes");
            migrationBuilder.DropTable(name: "Departments");
        }
    }
}
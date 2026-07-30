using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HR.System.Infrastructure.migrations
{
    public partial class _007_SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var createdDate = new DateTime(2026, 07, 30, 0, 0, 0, DateTimeKind.Utc);

            //===========================================================
            // Departments
            //===========================================================

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
                    { 1, "Human Resources", "HR", "Human Resources Department", true, createdDate, "System" },
                    { 2, "Information Technology", "IT", "Information Technology", true, createdDate, "System" },
                    { 3, "Finance", "FIN", "Finance Department", true, createdDate, "System" },
                    { 4, "Operations", "OPS", "Operations Department", true, createdDate, "System" },
                    { 5, "Executive", "EXEC", "Executive Management", true, createdDate, "System" }
                });

            //===========================================================
            // Employee Types
            //===========================================================

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
                    { 1, "Permanent", "PERM", true, createdDate, "System" },
                    { 2, "Contract", "CONT", true, createdDate, "System" },
                    { 3, "Temporary", "TEMP", true, createdDate, "System" },
                    { 4, "Intern", "INT", true, createdDate, "System" },
                    { 5, "Consultant", "CONS", true, createdDate, "System" }
                });

            //===========================================================
            // Job Titles
            //===========================================================

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
                    { 1, "Software Developer", "DEV", "Software Developer", false, true, createdDate, "System" },
                    { 2, "Senior Software Developer", "SDEV", "Senior Software Developer", false, true, createdDate, "System" },
                    { 3, "Team Lead", "TL", "Technical Team Lead", true, true, createdDate, "System" },
                    { 4, "Development Manager", "DM", "Development Manager", true, true, createdDate, "System" },
                    { 5, "HR Administrator", "HRA", "HR Administrator", false, true, createdDate, "System" },
                    { 6, "HR Manager", "HRM", "HR Manager", true, true, createdDate, "System" },
                    { 7, "Chief Executive Officer", "CEO", "Chief Executive Officer", true, true, createdDate, "System" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData("JobTitles", "JobTitleId", 1);
            migrationBuilder.DeleteData("JobTitles", "JobTitleId", 2);
            migrationBuilder.DeleteData("JobTitles", "JobTitleId", 3);
            migrationBuilder.DeleteData("JobTitles", "JobTitleId", 4);
            migrationBuilder.DeleteData("JobTitles", "JobTitleId", 5);
            migrationBuilder.DeleteData("JobTitles", "JobTitleId", 6);
            migrationBuilder.DeleteData("JobTitles", "JobTitleId", 7);

            migrationBuilder.DeleteData("EmployeeTypes", "EmployeeTypeId", 1);
            migrationBuilder.DeleteData("EmployeeTypes", "EmployeeTypeId", 2);
            migrationBuilder.DeleteData("EmployeeTypes", "EmployeeTypeId", 3);
            migrationBuilder.DeleteData("EmployeeTypes", "EmployeeTypeId", 4);
            migrationBuilder.DeleteData("EmployeeTypes", "EmployeeTypeId", 5);

            migrationBuilder.DeleteData("Departments", "DepartmentId", 1);
            migrationBuilder.DeleteData("Departments", "DepartmentId", 2);
            migrationBuilder.DeleteData("Departments", "DepartmentId", 3);
            migrationBuilder.DeleteData("Departments", "DepartmentId", 4);
            migrationBuilder.DeleteData("Departments", "DepartmentId", 5);
        }
    }
}
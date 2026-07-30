using HR.System.Domain.entities;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace HR.System.Infrastructure.migrations
{
    public partial class _003_EmployeeManagement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var currentDate = new DateTime(2026, 07, 30, 0, 0, 0, DateTimeKind.Utc);
            //===========================================================
            // Addresses
            //===========================================================

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AddressId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1,1"),

                    UnitNumber = table.Column<string>(
                        type: "nvarchar(20)",
                        maxLength: 20,
                        nullable: true),

                    Street = table.Column<string>(
                        type: "nvarchar(200)",
                        maxLength: 200,
                        nullable: false),

                    Suburb = table.Column<string>(
                        type: "nvarchar(100)",
                        maxLength: 100,
                        nullable: false),

                    Town = table.Column<string>(
                        type: "nvarchar(100)",
                        maxLength: 100,
                        nullable: false),

                    Province = table.Column<string>(
                        type: "nvarchar(100)",
                        maxLength: 100,
                        nullable: false),

                    PostalCode = table.Column<string>(
                        type: "nvarchar(10)",
                        maxLength: 10,
                        nullable: false),

                    CreatedDate = table.Column<DateTime>(
                        nullable: false),

                    CreatedBy = table.Column<string>(
                        maxLength: 100,
                        nullable: false),

                    ModifiedDate = table.Column<DateTime>(
                        nullable: true),

                    ModifiedBy = table.Column<string>(
                        maxLength: 100,
                        nullable: true),

                    RowVersion = table.Column<byte[]>(
                        rowVersion: true,
                        nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_PostalCode",
                table: "Addresses",
                column: "PostalCode");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_Town",
                table: "Addresses",
                column: "Town");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_Province",
                table: "Addresses",
                column: "Province");

            //===========================================================
            // Contact Details
            //===========================================================

            migrationBuilder.CreateTable(
                name: "ContactDetails",
                columns: table => new
                {
                    ContactDetailsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1,1"),

                    Mobile = table.Column<string>(
                        type: "nvarchar(20)",
                        maxLength: 20,
                        nullable: false),

                    Email = table.Column<string>(
                        type: "nvarchar(256)",
                        maxLength: 256,
                        nullable: true),

                    CreatedDate = table.Column<DateTime>(
                        nullable: false),

                    CreatedBy = table.Column<string>(
                        maxLength: 100,
                        nullable: false),

                    ModifiedDate = table.Column<DateTime>(
                        nullable: true),

                    ModifiedBy = table.Column<string>(
                        maxLength: 100,
                        nullable: true),

                    RowVersion = table.Column<byte[]>(
                        rowVersion: true,
                        nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactDetails", x => x.ContactDetailsId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContactDetails_Email",
                table: "ContactDetails",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ContactDetails_Mobile",
                table: "ContactDetails",
                column: "Mobile",
                unique: true);

            //===========================================================
            // Employees
            //===========================================================

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1,1"),

                    EmployeeNumber = table.Column<string>(
                        type: "nvarchar(20)",
                        maxLength: 20,
                        nullable: false),

                    Name = table.Column<string>(
                        type: "nvarchar(100)",
                        maxLength: 100,
                        nullable: false),

                    Surname = table.Column<string>(
                        type: "nvarchar(100)",
                        maxLength: 100,
                        nullable: false),

                    HireDate = table.Column<DateOnly>(
                        type: "date",
                        nullable: false),

                    TerminationDate = table.Column<DateOnly>(
                        type: "date",
                        nullable: true),

                    IsActive = table.Column<bool>(
                        nullable: false,
                        defaultValue: true),

                    DepartmentId = table.Column<int>(
                        nullable: false),

                    EmployeeTypeId = table.Column<int>(
                        nullable: false),

                    JobTitleId = table.Column<int>(
                        nullable: false),

                    AddressId = table.Column<int>(
                        nullable: false),

                    ContactDetailsId = table.Column<int>(
                        nullable: false),

                    ManagerId = table.Column<int>(
                        nullable: true),

                    DeletedDate = table.Column<DateTime>(
                        nullable: true),

                    CreatedDate = table.Column<DateTime>(
                        nullable: false),

                    CreatedBy = table.Column<string>(
                        maxLength: 100,
                        nullable: false),

                    ModifiedDate = table.Column<DateTime>(
                        nullable: true),

                    ModifiedBy = table.Column<string>(
                        maxLength: 100,
                        nullable: true),

                    RowVersion = table.Column<byte[]>(
                        rowVersion: true,
                        nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);

                    table.ForeignKey(
                        name: "FK_Employees_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Restrict);

                    table.ForeignKey(
                        name: "FK_Employees_ContactDetails_ContactDetailsId",
                        column: x => x.ContactDetailsId,
                        principalTable: "ContactDetails",
                        principalColumn: "ContactDetailsId",
                        onDelete: ReferentialAction.Restrict);

                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Restrict);

                    table.ForeignKey(
                        name: "FK_Employees_EmployeeTypes_EmployeeTypeId",
                        column: x => x.EmployeeTypeId,
                        principalTable: "EmployeeTypes",
                        principalColumn: "EmployeeTypeId",
                        onDelete: ReferentialAction.Restrict);

                    table.ForeignKey(
                        name: "FK_Employees_JobTitles_JobTitleId",
                        column: x => x.JobTitleId,
                        principalTable: "JobTitles",
                        principalColumn: "JobTitleId",
                        onDelete: ReferentialAction.Restrict);

                    table.ForeignKey(
                        name: "FK_Employees_Employees_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            //===========================================================
            // Indexes
            //===========================================================

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeNumber",
                table: "Employees",
                column: "EmployeeNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_AddressId",
                table: "Employees",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ContactDetailsId",
                table: "Employees",
                column: "ContactDetailsId",
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
                name: "IX_Employees_JobTitleId",
                table: "Employees",
                column: "JobTitleId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ManagerId",
                table: "Employees",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Name_Surname",
                table: "Employees",
                columns: new[]
                {
                    "Name",
                    "Surname"
                });


            //===========================================================
            // Check Constraints
            //===========================================================

            migrationBuilder.AddCheckConstraint(
                name: "CK_Employees_EmployeeNumber",
                table: "Employees",
                sql: "LEN([EmployeeNumber]) >= 4");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Employees_HireDate",
                table: "Employees",
                sql: "[TerminationDate] IS NULL OR [TerminationDate] >= [HireDate]");


            //===========================================================
            // Employee Roles
            //===========================================================

            migrationBuilder.CreateTable(
                name: "EmployeeRoles",
                columns: table => new
                {
                    EmployeeRoleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1,1"),

                    EmployeeId = table.Column<int>(nullable: false),

                    RoleId = table.Column<int>(nullable: false),

                    AssignedByEmployeeId = table.Column<int>(nullable: true),

                    EffectiveFrom = table.Column<DateOnly>(
                        type: "date",
                        nullable: false),

                    EffectiveTo = table.Column<DateOnly>(
                        type: "date",
                        nullable: true),

                    IsPrimary = table.Column<bool>(
                        nullable: false,
                        defaultValue: false),

                    Reason = table.Column<string>(
                        type: "nvarchar(500)",
                        maxLength: 500,
                        nullable: true),

                    CreatedDate = table.Column<DateTime>(
                        nullable: false),

                    CreatedBy = table.Column<string>(
                        maxLength: 100,
                        nullable: false),

                    ModifiedDate = table.Column<DateTime>(
                        nullable: true),

                    ModifiedBy = table.Column<string>(
                        maxLength: 100,
                        nullable: true),

                    RowVersion = table.Column<byte[]>(
                        rowVersion: true,
                        nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeRoles", x => x.EmployeeRoleId);

                    table.ForeignKey(
                        name: "FK_EmployeeRoles_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);

                    table.ForeignKey(
                        name: "FK_EmployeeRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Restrict);

                    table.ForeignKey(
                        name: "FK_EmployeeRoles_Employees_AssignedByEmployeeId",
                        column: x => x.AssignedByEmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeRoles");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "ContactDetails");

            migrationBuilder.DropTable(
                name: "Addresses");

        }
    }
}
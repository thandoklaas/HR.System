using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HR.System.Infrastructure.migrations
{
    public partial class _005_LeaveManagement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //===========================================================
            // Leave Balances
            //===========================================================

            migrationBuilder.CreateTable(
                name: "LeaveBalances",
                columns: table => new
                {
                    LeaveBalanceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1,1"),

                    EmployeeId = table.Column<int>(nullable: false),

                    LeaveTypeId = table.Column<int>(nullable: false),

                    LeaveYear = table.Column<int>(nullable: false),

                    OpeningBalance = table.Column<decimal>(
                        type: "decimal(10,2)",
                        nullable: false),

                    Accrued = table.Column<decimal>(
                        type: "decimal(10,2)",
                        nullable: false,
                        defaultValue: 0m),

                    Adjustments = table.Column<decimal>(
                        type: "decimal(10,2)",
                        nullable: false,
                        defaultValue: 0m),

                    Taken = table.Column<decimal>(
                        type: "decimal(10,2)",
                        nullable: false,
                        defaultValue: 0m),

                    CarriedForward = table.Column<decimal>(
                        type: "decimal(10,2)",
                        nullable: false,
                        defaultValue: 0m),

                    AvailableBalance = table.Column<decimal>(
                        type: "decimal(10,2)",
                        nullable: false),

                    LastAccrualDate = table.Column<DateTime>(
                        nullable: true),

                    LastCalculatedDate = table.Column<DateTime>(
                        nullable: true),

                    IsActive = table.Column<bool>(
                        nullable: false,
                        defaultValue: true),

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
                    table.PrimaryKey(
                        "PK_LeaveBalances",
                        x => x.LeaveBalanceId);

                    table.ForeignKey(
                        name: "FK_LeaveBalances_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);

                    table.ForeignKey(
                        name: "FK_LeaveBalances_LeaveTypes_LeaveTypeId",
                        column: x => x.LeaveTypeId,
                        principalTable: "LeaveTypes",
                        principalColumn: "LeaveTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            //===========================================================
            // Indexes
            //===========================================================

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

            migrationBuilder.CreateIndex(
                name: "IX_LeaveBalances_IsActive",
                table: "LeaveBalances",
                column: "IsActive");

            //===========================================================
            // Check Constraints
            //===========================================================

            migrationBuilder.AddCheckConstraint(
                name: "CK_LeaveBalances_OpeningBalance",
                table: "LeaveBalances",
                sql: "[OpeningBalance] >= 0");

            migrationBuilder.AddCheckConstraint(
                name: "CK_LeaveBalances_Accrued",
                table: "LeaveBalances",
                sql: "[Accrued] >= 0");

            migrationBuilder.AddCheckConstraint(
                name: "CK_LeaveBalances_Taken",
                table: "LeaveBalances",
                sql: "[Taken] >= 0");

            migrationBuilder.AddCheckConstraint(
                name: "CK_LeaveBalances_CarriedForward",
                table: "LeaveBalances",
                sql: "[CarriedForward] >= 0");

            migrationBuilder.AddCheckConstraint(
                name: "CK_LeaveBalances_AvailableBalance",
                table: "LeaveBalances",
                sql: "[AvailableBalance] >= 0");

            migrationBuilder.AddCheckConstraint(
                name: "CK_LeaveBalances_LeaveYear",
                table: "LeaveBalances",
                sql: "[LeaveYear] >= 2020");

            //===========================================================
            // Leave Requests
            //===========================================================

            migrationBuilder.CreateTable(
                name: "LeaveRequests",
                columns: table => new
                {
                    LeaveRequestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1,1"),

                    EmployeeId = table.Column<int>(nullable: false),

                    LeaveTypeId = table.Column<int>(nullable: false),

                    CurrentStatusId = table.Column<int>(nullable: false),

                    DocumentId = table.Column<int>(nullable: true),

                    Duration = table.Column<decimal>(
                        type: "decimal(10,2)",
                        nullable: false),

                    StartDateTime = table.Column<DateTimeOffset>(
                        nullable: false),

                    EndDateTime = table.Column<DateTimeOffset>(
                        nullable: false),

                    LeaveSession = table.Column<int>(
                        nullable: false),

                    Reason = table.Column<string>(
                        type: "nvarchar(1000)",
                        maxLength: 1000,
                        nullable: true),

                    RejectionReason = table.Column<string>(
                        type: "nvarchar(1000)",
                        maxLength: 1000,
                        nullable: true),

                    SickNoteRequired = table.Column<bool>(
                        nullable: false,
                        defaultValue: false),

                    IsActive = table.Column<bool>(
                        nullable: false,
                        defaultValue: true),

                    CurrentWorkflowLevel = table.Column<int>(
                        nullable: false,
                        defaultValue: 1),

                    SubmittedDate = table.Column<DateTimeOffset>(
                        nullable: false,
                        defaultValueSql: "SYSDATETIMEOFFSET()"),

                    ApprovedDate = table.Column<DateTimeOffset>(
                        nullable: true),

                    CancelledDate = table.Column<DateTimeOffset>(
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
                    table.PrimaryKey(
                        "PK_LeaveRequests",
                        x => x.LeaveRequestId);

                    table.ForeignKey(
                        name: "FK_LeaveRequests_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);

                    table.ForeignKey(
                        name: "FK_LeaveRequests_LeaveTypes_LeaveTypeId",
                        column: x => x.LeaveTypeId,
                        principalTable: "LeaveTypes",
                        principalColumn: "LeaveTypeId",
                        onDelete: ReferentialAction.Restrict);

                    table.ForeignKey(
                        name: "FK_LeaveRequests_LeaveStatuses_CurrentStatusId",
                        column: x => x.CurrentStatusId,
                        principalTable: "LeaveStatuses",
                        principalColumn: "LeaveStatusId",
                        onDelete: ReferentialAction.Restrict);

                    table.ForeignKey(
                        name: "FK_LeaveRequests_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Documents",
                        principalColumn: "DocumentId",
                        onDelete: ReferentialAction.SetNull);
                });


            //===========================================================
            // Indexes
            //===========================================================

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
                name: "IX_LeaveRequests_StartDateTime",
                table: "LeaveRequests",
                column: "StartDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequests_EndDateTime",
                table: "LeaveRequests",
                column: "EndDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequests_IsActive",
                table: "LeaveRequests",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequests_WorkflowLevel",
                table: "LeaveRequests",
                column: "CurrentWorkflowLevel");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequests_Employee_Status",
                table: "LeaveRequests",
                columns: new[]
                {
                    "EmployeeId",
                    "CurrentStatusId"
                });

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequests_Employee_DateRange",
                table: "LeaveRequests",
                columns: new[]
                {
                    "EmployeeId",
                    "StartDateTime",
                    "EndDateTime"
                });


            //===========================================================
            // Check Constraints
            //===========================================================

            migrationBuilder.AddCheckConstraint(
                name: "CK_LeaveRequests_Duration",
                table: "LeaveRequests",
                sql: "[Duration] > 0");

            migrationBuilder.AddCheckConstraint(
                name: "CK_LeaveRequests_DateRange",
                table: "LeaveRequests",
                sql: "[EndDateTime] >= [StartDateTime]");

            migrationBuilder.AddCheckConstraint(
                name: "CK_LeaveRequests_WorkflowLevel",
                table: "LeaveRequests",
                sql: "[CurrentWorkflowLevel] >= 1");


            //===========================================================
            // Leave Responses
            //===========================================================

            migrationBuilder.CreateTable(
                name: "LeaveResponses",
                columns: table => new
                {
                    LeaveResponseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1,1"),

                    LeaveRequestId = table.Column<int>(nullable: false),

                    LeaveResponseEmployeeId = table.Column<int>(nullable: false),

                    LeaveStatusId = table.Column<int>(nullable: false),

                    WorkflowLevel = table.Column<int>(
                        nullable: false),

                    IsCurrent = table.Column<bool>(
                        nullable: false,
                        defaultValue: true),

                    Comment = table.Column<string>(
                        type: "nvarchar(1000)",
                        maxLength: 1000,
                        nullable: true),

                    RejectionReason = table.Column<string>(
                        type: "nvarchar(1000)",
                        maxLength: 1000,
                        nullable: true),

                    ReviewedDate = table.Column<DateTimeOffset>(
                        nullable: false,
                        defaultValueSql: "SYSDATETIMEOFFSET()"),

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
                    table.PrimaryKey(
                        "PK_LeaveResponses",
                        x => x.LeaveResponseId);

                    table.ForeignKey(
                        name: "FK_LeaveResponses_LeaveRequests_LeaveRequestId",
                        column: x => x.LeaveRequestId,
                        principalTable: "LeaveRequests",
                        principalColumn: "LeaveRequestId",
                        onDelete: ReferentialAction.Cascade);

                    table.ForeignKey(
                        name: "FK_LeaveResponses_Employees_LeaveResponseEmployeeId",
                        column: x => x.LeaveResponseEmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);

                    table.ForeignKey(
                        name: "FK_LeaveResponses_LeaveStatuses_LeaveStatusId",
                        column: x => x.LeaveStatusId,
                        principalTable: "LeaveStatuses",
                        principalColumn: "LeaveStatusId",
                        onDelete: ReferentialAction.Restrict);
                });


            //===========================================================
            // Indexes
            //===========================================================

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
                name: "IX_LeaveResponses_WorkflowLevel",
                table: "LeaveResponses",
                column: "WorkflowLevel");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveResponses_ReviewedDate",
                table: "LeaveResponses",
                column: "ReviewedDate");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveResponses_IsCurrent",
                table: "LeaveResponses",
                column: "IsCurrent");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveResponses_Request_Workflow",
                table: "LeaveResponses",
                columns: new[]
                {
                    "LeaveRequestId",
                    "WorkflowLevel"
                });

            migrationBuilder.CreateIndex(
                name: "IX_LeaveResponses_Request_Current",
                table: "LeaveResponses",
                columns: new[]
                {
                    "LeaveRequestId",
                    "IsCurrent"
                });


            //===========================================================
            // Check Constraints
            //===========================================================

            migrationBuilder.AddCheckConstraint(
                name: "CK_LeaveResponses_WorkflowLevel",
                table: "LeaveResponses",
                sql: "[WorkflowLevel] >= 1");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeaveResponses");

            migrationBuilder.DropTable(
                name: "LeaveRequests");

            migrationBuilder.DropTable(
                name: "LeaveBalances");

        }
    }
}
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HR.System.Infrastructure.migrations;

public partial class Auditing : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        //===========================================================
        // Audit Logs
        //===========================================================

        migrationBuilder.CreateTable(
            name: "AuditLogs",
            columns: table => new
            {
                AuditLogId = table.Column<long>(nullable: false)
                    .Annotation("SqlServer:Identity", "1,1"),

                TableName = table.Column<string>(
                    type: "nvarchar(128)",
                    maxLength: 128,
                    nullable: false),

                RecordId = table.Column<string>(
                    type: "nvarchar(100)",
                    maxLength: 100,
                    nullable: false),

                Action = table.Column<string>(
                    type: "nvarchar(20)",
                    maxLength: 20,
                    nullable: false),

                OldValues = table.Column<string>(
                    type: "nvarchar(max)",
                    nullable: true),

                NewValues = table.Column<string>(
                    type: "nvarchar(max)",
                    nullable: true),

                ChangedColumns = table.Column<string>(
                    type: "nvarchar(max)",
                    nullable: true),

                PerformedByEmployeeId = table.Column<int>(
                    nullable: true),

                PerformedBy = table.Column<string>(
                    type: "nvarchar(100)",
                    maxLength: 100,
                    nullable: true),

                UserRole = table.Column<string>(
                    type: "nvarchar(100)",
                    maxLength: 100,
                    nullable: true),

                IpAddress = table.Column<string>(
                    type: "nvarchar(50)",
                    maxLength: 50,
                    nullable: true),

                UserAgent = table.Column<string>(
                    type: "nvarchar(500)",
                    maxLength: 500,
                    nullable: true),

                CorrelationId = table.Column<Guid>(
                    nullable: true),

                RequestId = table.Column<Guid>(
                    nullable: true),

                CommandName = table.Column<string>(
                    type: "nvarchar(200)",
                    maxLength: 200,
                    nullable: true),

                EventName = table.Column<string>(
                    type: "nvarchar(200)",
                    maxLength: 200,
                    nullable: true),

                MachineName = table.Column<string>(
                    type: "nvarchar(100)",
                    maxLength: 100,
                    nullable: true),

                Environment = table.Column<string>(
                    type: "nvarchar(100)",
                    maxLength: 100,
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
                    "PK_AuditLogs",
                    x => x.AuditLogId);

                table.ForeignKey(
                    name: "FK_AuditLogs_Employees_PerformedByEmployeeId",
                    column: x => x.PerformedByEmployeeId,
                    principalTable: "Employees",
                    principalColumn: "EmployeeId",
                    onDelete: ReferentialAction.SetNull);
            });

        //===========================================================
        // Standard Indexes
        //===========================================================

        migrationBuilder.CreateIndex(
            name: "IX_AuditLogs_PerformedByEmployeeId",
            table: "AuditLogs",
            column: "PerformedByEmployeeId");

        migrationBuilder.CreateIndex(
            name: "IX_AuditLogs_TableName",
            table: "AuditLogs",
            column: "TableName");

        migrationBuilder.CreateIndex(
            name: "IX_AuditLogs_RecordId",
            table: "AuditLogs",
            column: "RecordId");

        migrationBuilder.CreateIndex(
            name: "IX_AuditLogs_Action",
            table: "AuditLogs",
            column: "Action");

        migrationBuilder.CreateIndex(
            name: "IX_AuditLogs_CreatedDate",
            table: "AuditLogs",
            column: "CreatedDate");

        migrationBuilder.CreateIndex(
            name: "IX_AuditLogs_CorrelationId",
            table: "AuditLogs",
            column: "CorrelationId");

        migrationBuilder.CreateIndex(
            name: "IX_AuditLogs_RequestId",
            table: "AuditLogs",
            column: "RequestId");

        //===========================================================
        // Composite Indexes
        //===========================================================

        migrationBuilder.CreateIndex(
            name: "IX_AuditLogs_Table_Record",
            table: "AuditLogs",
            columns: new[]
            {
                "TableName",
                "RecordId"
            });

        migrationBuilder.CreateIndex(
            name: "IX_AuditLogs_Table_Action_Date",
            table: "AuditLogs",
            columns: new[]
            {
                "TableName",
                "Action",
                "CreatedDate"
            });

        migrationBuilder.CreateIndex(
            name: "IX_AuditLogs_Employee_Date",
            table: "AuditLogs",
            columns: new[]
            {
                "PerformedByEmployeeId",
                "CreatedDate"
            });

        migrationBuilder.CreateIndex(
            name: "IX_AuditLogs_Command",
            table: "AuditLogs",
            column: "CommandName");

        migrationBuilder.CreateIndex(
            name: "IX_AuditLogs_Event",
            table: "AuditLogs",
            column: "EventName");


        //===========================================================
        // Check Constraints
        //===========================================================

        migrationBuilder.AddCheckConstraint(
            name: "CK_AuditLogs_Action",
            table: "AuditLogs",
            sql: "[Action] IN ('INSERT','UPDATE','DELETE','LOGIN','LOGOUT','APPROVE','REJECT')");

        migrationBuilder.AddCheckConstraint(
            name: "CK_AuditLogs_TableName",
            table: "AuditLogs",
            sql: "LEN(LTRIM(RTRIM([TableName]))) > 0");

        migrationBuilder.AddCheckConstraint(
            name: "CK_AuditLogs_RecordId",
            table: "AuditLogs",
            sql: "LEN(LTRIM(RTRIM([RecordId]))) > 0");


        //===========================================================
        // Filtered SQL Server Indexes
        //===========================================================

        migrationBuilder.Sql(@"
                                CREATE NONCLUSTERED INDEX IX_AuditLogs_Correlation
                                ON AuditLogs (CorrelationId)
                                WHERE CorrelationId IS NOT NULL;
                                ");

        migrationBuilder.Sql(@"
                                CREATE NONCLUSTERED INDEX IX_AuditLogs_Request
                                ON AuditLogs (RequestId)
                                WHERE RequestId IS NOT NULL;
                                ");

        migrationBuilder.Sql(@"
                                CREATE NONCLUSTERED INDEX IX_AuditLogs_CommandName
                                ON AuditLogs (CommandName)
                                WHERE CommandName IS NOT NULL;
                                ");

        migrationBuilder.Sql(@"
                                CREATE NONCLUSTERED INDEX IX_AuditLogs_EventName
                                ON AuditLogs (EventName)
                                WHERE EventName IS NOT NULL;
                                ");

        //===========================================================
        // SQL Server Extended Property
        //===========================================================

        migrationBuilder.Sql(@"
                                EXEC sys.sp_addextendedproperty
                                @name=N'MS_Description',
                                @value=N'Enterprise audit trail for CQRS commands, queries and entity changes.',
                                @level0type=N'SCHEMA',
                                @level0name='dbo',
                                @level1type=N'TABLE',
                                @level1name='AuditLogs';
                                ");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "AuditLogs");
    }
}

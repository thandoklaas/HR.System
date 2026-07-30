using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HR.System.Infrastructure.migrations
{
    public partial class _004_Documents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //===========================================================
            // Documents
            //===========================================================

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    DocumentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1,1"),

                    OriginalFileName = table.Column<string>(
                        type: "nvarchar(255)",
                        maxLength: 255,
                        nullable: false),

                    DocumentName = table.Column<string>(
                        type: "nvarchar(255)",
                        maxLength: 255,
                        nullable: false),

                    DocumentFormat = table.Column<string>(
                        type: "nvarchar(20)",
                        maxLength: 20,
                        nullable: false),

                    ContentType = table.Column<string>(
                        type: "nvarchar(100)",
                        maxLength: 100,
                        nullable: false),

                    FileSize = table.Column<long>(
                        nullable: false),

                    StorageProvider = table.Column<string>(
                        type: "nvarchar(50)",
                        maxLength: 50,
                        nullable: false),

                    StoragePath = table.Column<string>(
                        type: "nvarchar(500)",
                        maxLength: 500,
                        nullable: false),

                    UploadedDate = table.Column<DateTimeOffset>(
                        nullable: false),

                    UploadedByEmployeeId = table.Column<int>(
                        nullable: true),

                    IsDeleted = table.Column<bool>(
                        nullable: false,
                        defaultValue: false),

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
                    table.PrimaryKey("PK_Documents", x => x.DocumentId);

                    table.ForeignKey(
                        name: "FK_Documents_Employees_UploadedByEmployeeId",
                        column: x => x.UploadedByEmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            //===========================================================
            // Indexes
            //===========================================================

            migrationBuilder.CreateIndex(
                name: "IX_Documents_UploadedByEmployeeId",
                table: "Documents",
                column: "UploadedByEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_UploadedDate",
                table: "Documents",
                column: "UploadedDate");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_DocumentFormat",
                table: "Documents",
                column: "DocumentFormat");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_ContentType",
                table: "Documents",
                column: "ContentType");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_IsDeleted",
                table: "Documents",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_DocumentName",
                table: "Documents",
                column: "DocumentName");

            //===========================================================
            // Check Constraints
            //===========================================================

            // File size cannot be negative
            migrationBuilder.AddCheckConstraint(
                name: "CK_Documents_FileSize",
                table: "Documents",
                sql: "[FileSize] >= 0");

            // Document name cannot be empty
            migrationBuilder.AddCheckConstraint(
                name: "CK_Documents_DocumentName",
                table: "Documents",
                sql: "LEN(LTRIM(RTRIM([DocumentName]))) > 0");

            // Original file name cannot be empty
            migrationBuilder.AddCheckConstraint(
                name: "CK_Documents_OriginalFileName",
                table: "Documents",
                sql: "LEN(LTRIM(RTRIM([OriginalFileName]))) > 0");

            //===========================================================
            // Filtered Indexes (SQL Server)
            //===========================================================

            // Quickly locate active (non-deleted) documents
            migrationBuilder.Sql(@"
                                    CREATE NONCLUSTERED INDEX IX_Documents_Active
                                    ON Documents (UploadedDate)
                                    WHERE IsDeleted = 0;
                                    ");

            // Fast searches by uploader for active documents
            migrationBuilder.Sql(@"
                                    CREATE NONCLUSTERED INDEX IX_Documents_Employee_Active
                                    ON Documents (UploadedByEmployeeId, UploadedDate)
                                    WHERE IsDeleted = 0;
                                    ");

            //===========================================================
            // Extended Properties (Optional)
            //===========================================================

            migrationBuilder.Sql(@"
                                    EXEC sys.sp_addextendedproperty
                                    @name=N'MS_Description',
                                    @value=N'Stores uploaded HR documents.',
                                    @level0type=N'SCHEMA',@level0name='dbo',
                                    @level1type=N'TABLE',@level1name='Documents';
                                    ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                                    IF EXISTS (SELECT * FROM sys.indexes
                                    WHERE name = 'IX_Documents_Employee_Active')
                                    DROP INDEX IX_Documents_Employee_Active ON Documents;
                                    ");

            migrationBuilder.Sql(@"
                                    IF EXISTS (SELECT * FROM sys.indexes
                                    WHERE name = 'IX_Documents_Active')
                                    DROP INDEX IX_Documents_Active ON Documents;
                                    ");

            migrationBuilder.DropTable(
                name: "Documents");
        }
    }
}
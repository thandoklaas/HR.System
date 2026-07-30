using HR.System.Domain.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRSystem.Infrastructure.Persistence.Configurations;

public sealed class EmployeeConfiguration : BaseEntityConfiguration<Employee>
{
    public override void Configure(EntityTypeBuilder<Employee> builder)
    {
        base.Configure(builder);

        builder.ToTable("Employees");

        builder.HasKey(x => x.EmployeeId);

        builder.Property(x => x.EmployeeNumber)
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(x => x.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.Surname)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.IsActive)
            .HasDefaultValue(true);

        builder.HasIndex(x => x.EmployeeNumber)
            .IsUnique();

        builder.HasIndex(x => x.DepartmentId);

        builder.HasIndex(x => x.EmployeeTypeId);

        builder.HasIndex(x => x.JobTitleId);

        builder.HasIndex(x => x.ManagerId);

        //-------------------------------------------------
        // Address (1 : 1)
        //-------------------------------------------------

        builder.HasOne(x => x.EmployeeAddress)
            .WithOne(x => x.Employee)
            .HasForeignKey<Employee>(x => x.AddressId)
            .OnDelete(DeleteBehavior.Restrict);

        //-------------------------------------------------
        // Contact Detail (1 : 1)
        //-------------------------------------------------

        builder.HasOne(x => x.EmployeeContactDetails)
            .WithOne(x => x.Employee)
            .HasForeignKey<Employee>(x => x.ContactDetailId)
            .OnDelete(DeleteBehavior.Restrict);

        //-------------------------------------------------
        // Department
        //-------------------------------------------------

        builder.HasOne(x => x.Department)
            .WithMany(x => x.Employees)
            .HasForeignKey(x => x.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);

        //-------------------------------------------------
        // Employee Type
        //-------------------------------------------------

        builder.HasOne(x => x.EmployeeType)
            .WithMany(x => x.Employees)
            .HasForeignKey(x => x.EmployeeTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        //-------------------------------------------------
        // Job Title
        //-------------------------------------------------

        builder.HasOne(x => x.JobTitle)
            .WithMany(x => x.Employees)
            .HasForeignKey(x => x.JobTitleId)
            .OnDelete(DeleteBehavior.Restrict);

        //-------------------------------------------------
        // Manager
        //-------------------------------------------------

        builder.HasOne(x => x.Manager)
            .WithMany(x => x.DirectReports)
            .HasForeignKey(x => x.ManagerId)
            .OnDelete(DeleteBehavior.Restrict);

        //-------------------------------------------------
        // Uploaded Documents
        //-------------------------------------------------

        builder.HasMany(x => x.UploadedDocuments)
            .WithOne(x => x.UploadedByEmployee)
            .HasForeignKey(x => x.UploadedByEmployeeId)
            .OnDelete(DeleteBehavior.Restrict);

        //-------------------------------------------------
        // Leave Requests
        //-------------------------------------------------

        builder.HasMany(x => x.LeaveRequests)
            .WithOne(x => x.Employee)
            .HasForeignKey(x => x.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);

        //-------------------------------------------------
        // Leave Balances
        //-------------------------------------------------

        builder.HasMany(x => x.LeaveBalances)
            .WithOne(x => x.Employee)
            .HasForeignKey(x => x.EmployeeId)
            .OnDelete(DeleteBehavior.Cascade);

        //-------------------------------------------------
        // Leave Responses (Reviewer)
        //-------------------------------------------------

        builder.HasMany(x => x.LeaveResponses)
            .WithOne(x => x.LeaveResponseEmployee)
            .HasForeignKey(x => x.LeaveResponseEmployeeId)
            .OnDelete(DeleteBehavior.Restrict);

        //-------------------------------------------------
        // Audit Logs
        //-------------------------------------------------

        builder.HasMany(x => x.PerformedAuditLogs)
            .WithOne(x => x.PerformedByEmployee)
            .HasForeignKey(x => x.PerformedByEmployeeId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
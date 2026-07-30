using HR.System.Domain.entities;
using HRSystem.Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.System.Infrastructure.persistance.configurations;

public sealed class JobTitleConfiguration : BaseEntityConfiguration<JobTitle>
{
    public override void Configure(EntityTypeBuilder<JobTitle> builder)
    {
        base.Configure(builder);

        builder.ToTable("JobTitles");

        builder.HasKey(x => x.JobTitleId);

        builder.Property(x => x.JobTitleName)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.JobCode)
            .HasMaxLength(20);

        builder.Property(x => x.Description)
            .HasMaxLength(500);

        builder.Property(x => x.IsManagementRole)
            .HasDefaultValue(false);

        builder.Property(x => x.IsActive)
            .HasDefaultValue(true);

        builder.HasMany(x => x.Employees)
            .WithOne(x => x.JobTitle)
            .HasForeignKey(x => x.JobTitleId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => x.JobTitleName)
            .IsUnique();

        builder.HasIndex(x => x.JobCode)
            .IsUnique();
    }
}
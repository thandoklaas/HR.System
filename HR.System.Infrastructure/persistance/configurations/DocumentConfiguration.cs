using HR.System.Domain.entities;
using HRSystem.Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.System.Infrastructure.persistance.configurations;

public sealed class DocumentConfiguration : BaseEntityConfiguration<Document>
{
    public override void Configure(EntityTypeBuilder<Document> builder)
    {
        base.Configure(builder);

        builder.ToTable("Documents", table => table.HasCheckConstraint(
                                                        "CK_Document_FileSize",
                                                        "[FileSize] >= 0")
        );

        builder.HasKey(x => x.DocumentId);

        builder.Property(x => x.DocumentName)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(x => x.OriginalFileName)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(x => x.DocumentFormat)
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(x => x.ContentType)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.StorageProvider)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.StoragePath)
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(x => x.FileSize)
            .IsRequired();

        builder.Property(x => x.UploadedDate)
            .IsRequired();

        builder.Property(x => x.IsDeleted)
            .HasDefaultValue(false);

        builder.HasOne(x => x.UploadedByEmployee)
            .WithMany(x => x.UploadedDocuments)
            .HasForeignKey(x => x.UploadedByEmployeeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.LeaveRequests)
            .WithOne(x => x.Document)
            .HasForeignKey(x => x.DocumentId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasIndex(x => x.UploadedByEmployeeId);

        builder.HasIndex(x => x.UploadedDate);

        builder.HasIndex(x => x.DocumentFormat);

        builder.HasIndex(x => x.ContentType);
    }
}
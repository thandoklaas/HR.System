using HR.System.Domain.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRSystem.Infrastructure.Persistence.Configurations;

public sealed class ContactDetailConfiguration : BaseEntityConfiguration<ContactDetail>
{
    public override void Configure(EntityTypeBuilder<ContactDetail> builder)
    {
        base.Configure(builder);

        builder.ToTable("ContactDetails");

        builder.HasKey(x => x.ContactDetailId);

        builder.Property(x => x.Mobile)
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(x => x.AlternateMobile)
            .HasMaxLength(20);

        builder.Property(x => x.Email)
            .HasMaxLength(256)
            .IsRequired();

        builder.Property(x => x.WorkEmail)
            .HasMaxLength(256);

        builder.HasIndex(x => x.Email)
            .IsUnique();

        builder.HasIndex(x => x.Mobile);
    }
}
using HR.System.Domain.entities;
using HRSystem.Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.System.Infrastructure.persistance.configurations;

public sealed class AddressConfiguration : BaseEntityConfiguration<Address>
{
    public override void Configure(EntityTypeBuilder<Address> builder)
    {
        base.Configure(builder);

        builder.ToTable("Addresses");

        builder.HasKey(x => x.AddressId);

        builder.Property(x => x.UnitNumber)
            .HasMaxLength(20);

        builder.Property(x => x.Street)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.Suburb)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.Town)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.Province)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.PostalCode)
            .HasMaxLength(10)
            .IsRequired();

        builder.HasIndex(x => new
        {
            x.Street,
            x.Suburb,
            x.Town
        });
    }
}
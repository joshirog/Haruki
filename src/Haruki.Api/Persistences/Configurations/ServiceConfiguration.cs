using Haruki.Api.Domains.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Haruki.Api.Persistences.Configurations;

public class ServiceConfiguration : IEntityTypeConfiguration<Service>
{
    public void Configure(EntityTypeBuilder<Service> builder)
    {
        builder.ToTable("h1_services");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasDefaultValueSql("uuid_generate_v4()")
            .HasMaxLength(36)
            .HasColumnOrder(0)
            .IsRequired();

        builder.Property(x => x.Name)
            .HasColumnName("name")
            .HasColumnOrder(1)
            .IsRequired();

        builder.Property(x => x.CreatedAt)
            .HasColumnName("created_at")
            .HasColumnOrder(18)
            .IsRequired();

        builder.Property(x => x.CreatedBy)
            .HasColumnName("created_by")
            .HasColumnOrder(19)
            .HasMaxLength(120)
            .IsRequired();

        builder.Property(x => x.UpdatedAt)
           .HasColumnName("updated_at")
           .HasColumnOrder(20)
           .IsRequired(false);

        builder.Property(x => x.UpdatedBy)
            .HasColumnName("updated_by")
            .HasColumnOrder(21)
            .HasMaxLength(120)
            .IsRequired(false);
    }
}
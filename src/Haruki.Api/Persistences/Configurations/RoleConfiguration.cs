using Haruki.Api.Domains.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Haruki.Api.Persistences.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("h0_roles");

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

        builder.Property(x => x.NormalizedName)
            .HasColumnName("normalized_name")
            .HasColumnOrder(2)
            .IsRequired();
        
        builder.Property(x => x.Status)
            .HasColumnName("status")
            .HasColumnOrder(3)
            .IsRequired();

        builder.Property(x => x.ConcurrencyStamp)
            .HasColumnName("concurrency_stamp")
            .HasColumnOrder(4)
            .IsRequired(false);

        builder.Property(x => x.CreatedAt)
            .HasColumnName("created_at")
            .HasColumnOrder(5)
            .IsRequired();

        builder.Property(x => x.CreatedBy)
            .HasColumnName("created_by")
            .HasColumnOrder(6)
            .HasMaxLength(120)
            .IsRequired();

        builder.Property(x => x.UpdatedAt)
            .HasColumnName("updated_at")
            .HasColumnOrder(7)
            .IsRequired(false);

        builder.Property(x => x.UpdatedBy)
            .HasColumnName("updated_by")
            .HasColumnOrder(8)
            .HasMaxLength(120)
            .IsRequired(false);
    }
}
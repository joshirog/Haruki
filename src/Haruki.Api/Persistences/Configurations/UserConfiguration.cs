using Haruki.Api.Domains.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Haruki.Api.Persistences.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("h0_users");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasDefaultValueSql("uuid_generate_v4()")
            .HasMaxLength(36)
            .HasColumnOrder(0)
            .IsRequired();

        builder.Property(x => x.UserName)
            .HasColumnName("username")
            .HasColumnOrder(1)
            .IsRequired();

        builder.Property(x => x.NormalizedUserName)
            .HasColumnName("normalized_username")
            .HasColumnOrder(2)
            .IsRequired();

        builder.Property(x => x.Email)
            .HasColumnName("email")
            .HasColumnOrder(3)
            .IsRequired(false);

        builder.Property(x => x.NormalizedEmail)
            .HasColumnName("normalized_email")
            .HasColumnOrder(4)
            .IsRequired(false);
        
        builder.Property(x => x.Status)
            .HasColumnName("status")
            .HasColumnOrder(5)
            .IsRequired();

        builder.Property(x => x.EmailConfirmed)
            .HasColumnName("email_confirmed")
            .HasColumnOrder(6)
            .IsRequired();

        builder.Property(x => x.PasswordHash)
            .HasColumnName("password_hash")
            .HasColumnOrder(7)
            .IsRequired(false);

        builder.Property(x => x.SecurityStamp)
            .HasColumnName("security_stamp")
            .HasColumnOrder(8)
            .IsRequired(false);

        builder.Property(x => x.ConcurrencyStamp)
            .HasColumnName("concurrency_stamp")
            .HasColumnOrder(9)
            .IsRequired(false);

        builder.Property(x => x.PhoneNumber)
            .HasColumnName("phone_number")
            .HasColumnOrder(10)
            .IsRequired(false);

        builder.Property(x => x.PhoneNumberConfirmed)
            .HasColumnName("phone_number_confirmed")
            .HasColumnOrder(11)
            .IsRequired();

        builder.Property(x => x.TwoFactorEnabled)
            .HasColumnName("two_factor_enabled")
            .HasColumnOrder(12)
            .IsRequired();

        builder.Property(x => x.LockoutEnd)
            .HasColumnName("lockout_end")
            .HasColumnOrder(13)
            .IsRequired(false);

        builder.Property(x => x.LockoutEnabled)
            .HasColumnName("lockout_enabled")
            .HasColumnOrder(14)
            .IsRequired();

        builder.Property(x => x.AccessFailedCount)
            .HasColumnName("access_failed_count")
            .HasColumnOrder(15)
            .IsRequired();
        
        builder.Property(x => x.RefreshToken)
            .HasColumnName("refresh_token")
            .HasColumnOrder(16)
            .IsRequired(false);
        
        builder.Property(x => x.TokenExpires)
            .HasColumnName("token_expires")
            .HasColumnOrder(17)
            .IsRequired(false);

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
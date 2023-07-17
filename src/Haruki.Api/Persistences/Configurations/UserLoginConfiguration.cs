using Haruki.Api.Domains.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Haruki.Api.Persistences.Configurations;

public class UserLoginConfiguration : IEntityTypeConfiguration<UserLogin>
{
    public void Configure(EntityTypeBuilder<UserLogin> builder)
    {
        builder.ToTable("h0_user_logins");
        
        builder.Property(x => x.UserId)
            .HasColumnName("user_id")
            .IsRequired();

        builder.Property(x => x.LoginProvider)
            .HasColumnName("login_provider")
            .IsRequired();

        builder.Property(x => x.ProviderKey)
            .HasColumnName("provider_key")
            .IsRequired();

        builder.Property(x => x.ProviderDisplayName)
            .HasColumnName("provider_display_name")
            .IsRequired(false);
    }
}
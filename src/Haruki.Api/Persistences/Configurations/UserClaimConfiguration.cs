using Haruki.Api.Domains.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Haruki.Api.Persistences.Configurations;

public class UserClaimConfiguration : IEntityTypeConfiguration<UserClaim>
{
    public void Configure(EntityTypeBuilder<UserClaim> builder)
    {
        builder.ToTable("h0_user_claims");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .IsRequired();

        builder.Property(x => x.UserId)
            .HasColumnName("user_id")
            .IsRequired();

        builder.Property(x => x.ClaimType)
            .HasColumnName("claim_type")
            .IsRequired(false);

        builder.Property(x => x.ClaimValue)
            .HasColumnName("claim_value")
            .IsRequired(false);
    }
}
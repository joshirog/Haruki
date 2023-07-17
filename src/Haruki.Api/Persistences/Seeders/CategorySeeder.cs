using Haruki.Api.Commons.Constants;
using Haruki.Api.Domains.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Haruki.Api.Persistences.Seeders;

public class CategorySeeder : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        var date = new DateTime(2021, 1, 1);

        builder.HasData(
            new Category
            {
                Id = Guid.Parse("10000000-0000-0000-0000-000000000000"),
                ServiceId = Guid.Parse("10000000-0000-0000-0000-000000000000"),
                Name = "Dogs",
                CreatedBy = GeneralConstant.DefaultUsername,
                CreatedAt = date
            },
            new Category
            {
                Id = Guid.Parse("20000000-0000-0000-0000-000000000000"),
                ServiceId = Guid.Parse("10000000-0000-0000-0000-000000000000"),
                Name = "Cats",
                CreatedBy = GeneralConstant.DefaultUsername,
                CreatedAt = date
            },
            new Category
            {
                Id = Guid.Parse("30000000-0000-0000-0000-000000000000"),
                ServiceId = Guid.Parse("10000000-0000-0000-0000-000000000000"),
                Name = "Birds",
                CreatedBy = GeneralConstant.DefaultUsername,
                CreatedAt = date
            },
            new Category
            {
                Id = Guid.Parse("40000000-0000-0000-0000-000000000000"),
                ServiceId = Guid.Parse("10000000-0000-0000-0000-000000000000"),
                Name = "Fishes",
                CreatedBy = GeneralConstant.DefaultUsername,
                CreatedAt = date
            }
        );
    }
}
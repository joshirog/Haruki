using Haruki.Api.Commons.Constants;
using Haruki.Api.Domains.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Haruki.Api.Persistences.Seeders;

public class ServiceSeeder : IEntityTypeConfiguration<Service>
{
    public void Configure(EntityTypeBuilder<Service> builder)
    {
        var date = new DateTime(2021, 1, 1);

        builder.HasData(
            new Service
            {
                Id = Guid.Parse("10000000-0000-0000-0000-000000000000"),
                Name = "Adoption",
                CreatedBy = GeneralConstant.DefaultUsername,
                CreatedAt = date
            },
            new Service
            {
                Id = Guid.Parse("20000000-0000-0000-0000-000000000000"),
                Name = "Grooming",
                CreatedBy = GeneralConstant.DefaultUsername,
                CreatedAt = date
            },
            new Service
            {
                Id = Guid.Parse("30000000-0000-0000-0000-000000000000"),
                Name = "Veterinary",
                CreatedBy = GeneralConstant.DefaultUsername,
                CreatedAt = date
            },
            new Service
            {
                Id = Guid.Parse("40000000-0000-0000-0000-000000000000"),
                Name = "Medicine",
                CreatedBy = GeneralConstant.DefaultUsername,
                CreatedAt = date
            },
            new Service
            {
                Id = Guid.Parse("50000000-0000-0000-0000-000000000000"),
                Name = "Foods",
                CreatedBy = GeneralConstant.DefaultUsername,
                CreatedAt = date
            },
            new Service
            {
                Id = Guid.Parse("60000000-0000-0000-0000-000000000000"),
                Name = "Training",
                CreatedBy = GeneralConstant.DefaultUsername,
                CreatedAt = date
            },
            new Service
            {
                Id = Guid.Parse("70000000-0000-0000-0000-000000000000"),
                Name = "Boarding",
                CreatedBy = GeneralConstant.DefaultUsername,
                CreatedAt = date
            },
            new Service
            {
                Id = Guid.Parse("80000000-0000-0000-0000-000000000000"),
                Name = "Toys",
                CreatedBy = GeneralConstant.DefaultUsername,
                CreatedAt = date
            },
            new Service
            {
                Id = Guid.Parse("90000000-0000-0000-0000-000000000000"),
                Name = "Accessories",
                CreatedBy = GeneralConstant.DefaultUsername,
                CreatedAt = date
            }
        );
    }
}
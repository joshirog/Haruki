using System.Security.Claims;
using Haruki.Api.Commons.Constants;
using Haruki.Api.Commons.Enums;
using Haruki.Api.Domains.Entities;
using Microsoft.AspNetCore.Identity;

namespace Haruki.Api.Persistences.Seeders;

public static class IdentitySeeder
{
    public static async void Seed(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();

        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();

        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<Role>>();

        if (await userManager.FindByNameAsync("administrator@haruki.com") is not null) 
            return;
        
        var user = new User
        {
            Id = Guid.NewGuid(),
            UserName = "administrator@haruki.com",
            Email = "administrator@haruki.com",
            EmailConfirmed = false,
            PhoneNumber = "946678198",
            Status = Enum.GetName(typeof(StatusEnum), StatusEnum.Active),
            TwoFactorEnabled = false
        };

        await userManager.CreateAsync(user, "Admin2023$$");

        if (await roleManager.FindByNameAsync(Enum.GetName(typeof(RoleEnum), RoleEnum.Administrator)!) is not null)
            return;
        
        await roleManager.CreateAsync(new Role
        {
            Id = Guid.Parse(RoleConstant.AdministratorId),
            Name = Enum.GetName(typeof(RoleEnum), RoleEnum.Administrator),
            Status = Enum.GetName(typeof(StatusEnum), StatusEnum.Active),
            ConcurrencyStamp = Guid.NewGuid().ToString()
        });
        
        await roleManager.CreateAsync(new Role
        {
            Id = Guid.Parse(RoleConstant.ManagementId),
            Name = Enum.GetName(typeof(RoleEnum), RoleEnum.Management),
            Status = Enum.GetName(typeof(StatusEnum), StatusEnum.Active),
            ConcurrencyStamp = Guid.NewGuid().ToString()
        });
        
        await roleManager.CreateAsync(new Role
        {
            Id = Guid.Parse(RoleConstant.OperatorId),
            Name = Enum.GetName(typeof(RoleEnum), RoleEnum.Operator),
            Status = Enum.GetName(typeof(StatusEnum), StatusEnum.Active),
            ConcurrencyStamp = Guid.NewGuid().ToString()
        });
        
        await roleManager.CreateAsync(new Role
        {
            Id = Guid.Parse(RoleConstant.KeeperId),
            Name = Enum.GetName(typeof(RoleEnum), RoleEnum.Keeper),
            Status = Enum.GetName(typeof(StatusEnum), StatusEnum.Active),
            ConcurrencyStamp = Guid.NewGuid().ToString()
        });
        
        await roleManager.CreateAsync(new Role
        {
            Id = Guid.Parse(RoleConstant.OwnerId),
            Name = Enum.GetName(typeof(RoleEnum), RoleEnum.Owner),
            Status = Enum.GetName(typeof(StatusEnum), StatusEnum.Active),
            ConcurrencyStamp = Guid.NewGuid().ToString()
        });

        await roleManager.CreateAsync(new Role
        {
            Id = Guid.Parse(RoleConstant.GuestId),
            Name = Enum.GetName(typeof(RoleEnum), RoleEnum.Guest),
            Status = Enum.GetName(typeof(StatusEnum), StatusEnum.Active),
            ConcurrencyStamp = Guid.NewGuid().ToString()
        });

        await userManager.AddToRoleAsync(user, Enum.GetName(typeof(RoleEnum), RoleEnum.Administrator)!);
        
        await userManager.AddClaimsAsync(user, new List<Claim>
        {
            new("identifier", user.Id.ToString()),
            new("first_name", "Jose Luis"),
            new("last_name", "Oshiro Gushiken"),
            new("nick_name", "JO"),
            new("avatar", GeneralConstant.DefaultAvatar, ClaimValueTypes.String)
        });
    }
}
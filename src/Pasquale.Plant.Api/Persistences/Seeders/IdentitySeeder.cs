using Microsoft.AspNetCore.Identity;
using Pasquale.Plant.Api.Commons.Enums;
using Pasquale.Plant.Api.Domains.Entities;

namespace Pasquale.Plant.Api.Persistences.Seeders;

public static class IdentitySeeder
{
    public static async void Seed(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();

        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();

        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<Role>>();

        if (await userManager.FindByNameAsync("administrator@pasquale.com") is not null) 
            return;
        
        var user = new User()
        {
            Id = Guid.NewGuid(),
            UserName = "administrator@pasquale.com",
            Email = "administrator@pasquale.com",
            EmailConfirmed = true,
            PhoneNumber = "946678198",
            Status = Enum.GetName(typeof(StatusEnum), StatusEnum.Active),
            TwoFactorEnabled = false
        };

        await userManager.CreateAsync(user, "Admin2023$$");

        if (await roleManager.FindByNameAsync(Enum.GetName(typeof(RoleEnum), RoleEnum.Administrator)!) is not null)
            return;
        
        await roleManager.CreateAsync(new Role
        {
            Name = Enum.GetName(typeof(RoleEnum), RoleEnum.Administrator)
        });
        
        await roleManager.CreateAsync(new Role
        {
            Name = Enum.GetName(typeof(RoleEnum), RoleEnum.Guest),
        });

        await userManager.AddToRoleAsync(user, Enum.GetName(typeof(RoleEnum), RoleEnum.Administrator)!);
    }
}
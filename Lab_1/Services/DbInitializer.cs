﻿using Lab_1.DAL.Context;
using Lab_1.DAL.Entities;
using Microsoft.AspNetCore.Identity;

namespace Lab_1.Services;

/// <summary>
/// 
/// </summary>
public static class DbInitializer
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static async Task Seed(this WebApplication app)
    {
        using var scope = app.Services.CreateScope(); // из scope мы можем получить контекст бд
        using var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        using var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        using var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        //context.Database.EnsureDeleted(); // чтобы не внесли оно будет уничтожаться при следующем запуске

        // создать БД, если она еще не создана
        context.Database.EnsureCreated();
        // проверка наличия ролей
        if (!context.Roles.Any())
        {
            var roleAdmin = new IdentityRole
            {
                Name = "admin",
                NormalizedName = "admin"
            };
            // создать роль admin
            await roleManager.CreateAsync(roleAdmin);
        }
        // проверка наличия пользователей
        if (!context.Users.Any())
        {
            // создать пользователя user@mail.ru
            var user = new ApplicationUser
            {
                Email = "user@mail.ru",
                UserName = "user@mail.ru"
            };
            await userManager.CreateAsync(user, "123456");
            // создать пользователя admin@mail.ru
            var admin = new ApplicationUser
            {
                Email = "admin@mail.ru",
                UserName = "admin@mail.ru"
            };
            await userManager.CreateAsync(admin, "123456");
            // назначить роль admin
            admin = await userManager.FindByEmailAsync("admin@mail.ru");

            if (admin != null)
            {
                await userManager.AddToRoleAsync(admin, "admin");
            }
        }

        //проверка наличия групп объектов
        if (!context.DishGroups.Any())
        {
            context.DishGroups.AddRange(
            new List<DishGroup>
            {
                new DishGroup {GroupName="Стартеры"},
                new DishGroup {GroupName="Салаты"},
                new DishGroup {GroupName="Супы"},
                new DishGroup {GroupName="Основные блюда"},
                new DishGroup {GroupName="Напитки"},
                new DishGroup {GroupName="Десерты"}
            });
            await context.SaveChangesAsync();
        }
        // проверка наличия объектов
        if (!context.Dishes.Any())
        {
            context.Dishes.AddRange(
            new List<Dish>
            {
                new Dish {DishName="Суп-харчо", Description="Очень острый, невкусный", Calories =200, DishGroupId=3, Image="Суп.jpg" },
                new Dish {DishName="Борщ", Description="Много сала, без сметаны", Calories =330, DishGroupId=3, Image="Борщ.jpg" },
                new Dish {DishName="Котлета пожарская", Description="Хлеб - 80%, Морковь - 20%", Calories =635, DishGroupId=4, Image="Котлета.jpg" },
                new Dish {DishName="Макароны по-флотски", Description="С охотничьей колбаской", Calories =524, DishGroupId=4, Image="Макароны.jpg" },
                new Dish {DishName="Компот", Description="Быстро растворимый, 2 литра", Calories =180, DishGroupId=5, Image="Компот.jpg" }
            });
            await context.SaveChangesAsync();
        }
    }
}
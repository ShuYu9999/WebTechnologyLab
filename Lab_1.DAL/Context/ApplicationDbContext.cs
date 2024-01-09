using Lab_1.DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Lab_1.DAL.Context;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{

    /// <summary>
    /// 
    /// </summary>
    public DbSet<Dish> Dishes { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public DbSet<DishGroup> DishGroups { get; set; }
}

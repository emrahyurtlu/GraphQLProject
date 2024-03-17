using GraphQLProject.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLProject.Data;

public class GraphqlDbContext: DbContext
{
    public GraphqlDbContext(DbContextOptions<GraphqlDbContext> options): base(options)
    {
        
    }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Menu> Menus { get; set; }
    public DbSet<Reservation> Reservations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Menu>().HasData(Seed.Menus());
        modelBuilder.Entity<Category>().HasData(Seed.Categories());
        modelBuilder.Entity<Reservation>().HasData(Seed.Reservations());
    }
}

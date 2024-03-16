using GraphQLProject.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLProject.Data;

public class GraphqlDbContext: DbContext
{
    public GraphqlDbContext(DbContextOptions<GraphqlDbContext> options): base(options)
    {
        
    }
    public DbSet<Menu> Menus { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Menu>().HasData(Seed.Menus());
    }
}

using GraphiQl;
using GraphQL;
using GraphQL.Types;
using GraphQLProject.Data;
using GraphQLProject.Interfaces;
using GraphQLProject.Mutation;
using GraphQLProject.Query;
using GraphQLProject.Schema;
using GraphQLProject.Services;
using GraphQLProject.Type;
using Microsoft.EntityFrameworkCore;

namespace GraphQLProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddTransient<IMenuRepository, MenuRepository>();
            
            // GraphQL Settings
            builder.Services.AddTransient<MenuType>();
            builder.Services.AddTransient<MenuQuery>();
            builder.Services.AddTransient<MenuMutation>();
            builder.Services.AddTransient<MenuInputType>();

            builder.Services.AddTransient<ISchema,MenuSchema>();

            // Enabling GraphQL Settings
            builder.Services.AddGraphQL(b=> b.AddAutoSchema<ISchema>().AddSystemTextJson());


            // Adding SqlServer
            builder.Services.AddDbContext<GraphqlDbContext>(opt =>
            {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString"));
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.

            // Enabled GraphiQl playground
            app.UseGraphiQl("/graphql");
            // Using GraphQL Settings
            app.UseGraphQL<ISchema>();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}

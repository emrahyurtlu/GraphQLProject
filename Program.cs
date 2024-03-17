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
            builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
            builder.Services.AddTransient<IReservationRepository, ReservationRepository>();

            

            // GraphQL Menu Settings
            builder.Services.AddTransient<MenuType>();
            builder.Services.AddTransient<MenuQuery>();
            builder.Services.AddTransient<MenuMutation>();
            builder.Services.AddTransient<MenuInputType>();

            // GraphQL Category Settings
            builder.Services.AddTransient<CategoryType>();
            builder.Services.AddTransient<CategoryQuery>();
            builder.Services.AddTransient<CategoryMutation>();
            builder.Services.AddTransient<CategoryInputType>();

            // GraphQL Reservation Settings
            builder.Services.AddTransient<ReservationType>();
            builder.Services.AddTransient<ReservationQuery>();
            builder.Services.AddTransient<ReservationMutation>();
            builder.Services.AddTransient<ReservationInputType>();

            // GraphQL Root Settings
            builder.Services.AddTransient<RootQuery>();
            builder.Services.AddTransient<RootMutation>();
            builder.Services.AddTransient<ISchema, RootSchema>();

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

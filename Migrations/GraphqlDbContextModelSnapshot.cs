﻿// <auto-generated />
using GraphQLProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GraphQLProject.Migrations
{
    [DbContext(typeof(GraphqlDbContext))]
    partial class GraphqlDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GraphQLProject.Models.Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Menus");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Classic Burger Desc",
                            Name = "Classic Burger",
                            Price = 6.9900000000000002
                        },
                        new
                        {
                            Id = 2,
                            Description = "Margherita Pizza Desc",
                            Name = "Margherita Pizza",
                            Price = 10.99
                        },
                        new
                        {
                            Id = 3,
                            Description = "Grilled Chicked Salad Desc",
                            Name = "Grilled Chicked Salad",
                            Price = 8.9900000000000002
                        },
                        new
                        {
                            Id = 4,
                            Description = "Pasta Alfredo Desc",
                            Name = "Pasta Alfredo",
                            Price = 16.989999999999998
                        },
                        new
                        {
                            Id = 5,
                            Description = "Chocolate Brownie Sundae Desc",
                            Name = "Chocolate Brownie Sundae",
                            Price = 3.9900000000000002
                        });
                });
#pragma warning restore 612, 618
        }
    }
}

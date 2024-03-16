using GraphQLProject.Models;

namespace GraphQLProject.Data
{
    public class Seed
    {
        public static List<Menu> Menus ()
        {
            return new List<Menu> {
                new Menu
                {
                    Id = 1,
                    Name = "Classic Burger",
                    Description = "Classic Burger Desc",
                    Price = 6.99
                },
                new Menu
                {
                    Id = 2,
                    Name = "Margherita Pizza",
                    Description = "Margherita Pizza Desc",
                    Price = 10.99
                },
                new Menu
                {
                    Id = 3,
                    Name = "Grilled Chicked Salad",
                    Description = "Grilled Chicked Salad Desc",
                    Price = 8.99
                },
                new Menu
                {
                    Id = 4,
                    Name = "Pasta Alfredo",
                    Description = "Pasta Alfredo Desc",
                    Price = 16.99
                },
                new Menu
                {
                    Id = 5,
                    Name = "Chocolate Brownie Sundae",
                    Description = "Chocolate Brownie Sundae Desc",
                    Price = 3.99
                }
            };
        }
    }
}

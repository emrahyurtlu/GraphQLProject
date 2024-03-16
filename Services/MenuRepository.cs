using GraphQLProject.Data;
using GraphQLProject.Interfaces;
using GraphQLProject.Models;

namespace GraphQLProject.Services
{
    public class MenuRepository : IMenuRepository
    {
        private readonly GraphqlDbContext _context;

        public MenuRepository(GraphqlDbContext context)
        {
            _context = context;
        }

        public Menu AddMenu(Menu menu)
        {
            _context.Add(menu);
            _context.SaveChanges();
            return menu;
        }

        public void DeleteMenu(int id)
        {
            var menu = _context.Menus.Find(id);
            _context.Menus.Remove(menu);
            _context.SaveChanges();
        }

        public List<Menu> GetAllMenu()
        {
            return _context.Menus.ToList();
        }

        public Menu GetMenuById(int id)
        {
            return _context.Menus.FirstOrDefault(t => t.Id == id);
        }

        public Menu UpdateMenu(int id, Menu menu)
        {
            var menuResult = _context.Menus.Find(id);
            menuResult.Name = menu.Name; 
            menuResult.Description = menu.Description;
            menuResult.Price = menu.Price;
            _context.SaveChanges();

            return menu;
        }
    }
}

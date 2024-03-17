using GraphQL.Types;
using GraphQLProject.Interfaces;
using GraphQLProject.Models;
using GraphQLProject.Services;

namespace GraphQLProject.Type
{
    public class CategoryType: ObjectGraphType<Category>
    {
        public CategoryType(IMenuRepository menuRepository)
        {
            Field(m => m.Id);
            Field(m => m.Name);
            Field(m => m.ImageUrl);
            // Nested Query
            Field<ListGraphType<MenuType>>("Menus").Resolve(ctx => {
                return menuRepository.GetAll();
            });
        }
    }
}

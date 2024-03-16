using GraphQL;
using GraphQL.Types;
using GraphQLProject.Interfaces;
using GraphQLProject.Type;

namespace GraphQLProject.Query
{
    public class MenuQuery : ObjectGraphType
    {
        public MenuQuery(IMenuRepository menuRepository)
        {
            Field<ListGraphType<MenuType>>("Menus").Resolve(ctx => {
                return menuRepository.GetAllMenu();
            });

            Field<MenuType>("Menu")
                .Arguments(new QueryArguments(new QueryArgument<IntGraphType> { Name = "menuId"}))
                .Resolve(ctx => {
                    return menuRepository.GetMenuById(ctx.GetArgument<int>("menuId"));
            });
        }
    }
}

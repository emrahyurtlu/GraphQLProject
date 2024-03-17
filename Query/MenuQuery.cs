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
                return menuRepository.GetAll();
            });

            Field<MenuType>("Menu")
                .Arguments(new QueryArguments(new QueryArgument<IntGraphType> { Name = "menuId"}))
                .Resolve(ctx => {
                    return menuRepository.GetById(ctx.GetArgument<int>("menuId"));
            });
        }
    }
}

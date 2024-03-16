using GraphQL;
using GraphQL.Types;
using GraphQLProject.Interfaces;
using GraphQLProject.Type;

namespace GraphQLProject.Mutation;

public class MenuMutation: ObjectGraphType
{
    public MenuMutation(IMenuRepository menuRepository)
    {
        Field<MenuType>("CreateMenu")
                .Arguments(new QueryArguments(new QueryArgument<MenuInputType> { Name = "menu" }))
                .Resolve(ctx => {
                    var menu = ctx.GetArgument<Models.Menu>("menu");
                    return menuRepository.AddMenu(menu);
                });

        Field<MenuType>("UpdateMenu")
                .Arguments(new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "menuId" }, 
                    new QueryArgument<MenuInputType> { Name = "menu" }))
                .Resolve(ctx => {
                    int menuId = ctx.GetArgument<int>("menuId");
                    var menu = ctx.GetArgument<Models.Menu>("menu");
                    return menuRepository.UpdateMenu(menuId, menu);
                });

        Field<StringGraphType>("DeleteMenu")
                .Arguments(new QueryArguments(new QueryArgument<IntGraphType> { Name = "menuId" }))
                .Resolve(ctx => {
                    int menuId = ctx.GetArgument<int>("menuId");
                    menuRepository.DeleteMenu(menuId);
                    return "The menu has been deleted.";
                });
    }
}

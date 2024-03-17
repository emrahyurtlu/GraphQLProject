using GraphQL;
using GraphQL.Types;
using GraphQLProject.Interfaces;
using GraphQLProject.Type;

namespace GraphQLProject.Mutation;

public class CategoryMutation: ObjectGraphType
{
    public CategoryMutation(ICategoryRepository repository)
    {
        Field<CategoryType>("CreateCategory")
                .Arguments(new QueryArguments(new QueryArgument<CategoryInputType> { Name = "category" }))
                .Resolve(ctx => {
                    var entity = ctx.GetArgument<Models.Category>("category");
                    return repository.Add(entity);
                });

        Field<CategoryType>("UpdateCategory")
                .Arguments(new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "id" }, 
                    new QueryArgument<CategoryInputType> { Name = "category" }))
                .Resolve(ctx => {
                    int id = ctx.GetArgument<int>("id");
                    var entity = ctx.GetArgument<Models.Category>("category");
                    return repository.Update(id, entity);
                });

        Field<StringGraphType>("DeleteCategory")
                .Arguments(new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }))
                .Resolve(ctx => {
                    int id = ctx.GetArgument<int>("id");
                    repository.Delete(id);
                    return "The category has been deleted.";
                });
    }
}

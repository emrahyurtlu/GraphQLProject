using GraphQL;
using GraphQL.Types;
using GraphQLProject.Interfaces;
using GraphQLProject.Type;

namespace GraphQLProject.Query
{
    public class CategoryQuery : ObjectGraphType
    {
        public CategoryQuery(ICategoryRepository repository)
        {
            Field<ListGraphType<CategoryType>>("Categories").Resolve(ctx => {
                return repository.GetAll();
            });

            Field<CategoryType>("Category")
                .Arguments(new QueryArguments(new QueryArgument<IntGraphType> { Name = "id"}))
                .Resolve(ctx => {
                    return repository.GetById(ctx.GetArgument<int>("id"));
            });
        }
    }
}

using GraphQL;
using GraphQL.Types;
using GraphQLProject.Interfaces;
using GraphQLProject.Type;

namespace GraphQLProject.Query
{
    public class ReservationQuery : ObjectGraphType
    {
        public ReservationQuery(IReservationRepository repository)
        {
            Field<ListGraphType<ReservationType>>("Reservations").Resolve(ctx => {
                return repository.GetAll();
            });

            Field<ReservationType>("Reservation")
                .Arguments(new QueryArguments(new QueryArgument<IntGraphType> { Name = "id"}))
                .Resolve(ctx => {
                    return repository.GetById(ctx.GetArgument<int>("id"));
            });
        }
    }
}

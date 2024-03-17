using GraphQL;
using GraphQL.Types;
using GraphQLProject.Interfaces;
using GraphQLProject.Type;

namespace GraphQLProject.Mutation;

public class ReservationMutation : ObjectGraphType
{
    public ReservationMutation(IReservationRepository repository)
    {
        Field<ReservationType>("CreateReservation")
                .Arguments(new QueryArguments(new QueryArgument<ReservationInputType> { Name = "reservation" }))
                .Resolve(ctx =>
                {
                    var entity = ctx.GetArgument<Models.Reservation>("reservation");
                    return repository.Add(entity);
                });
    }
}

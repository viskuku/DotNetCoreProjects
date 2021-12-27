using GraphQL;
using GraphQL.Types;
using GraphQLLearn.GraphQL.Types;
using GraphQLLearn.Models;
using GraphQLLearn.Repositores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLLearn.GraphQL.Schemas.Mutations
{
    public sealed class MutationObject : ObjectGraphType<object>
    {
        public MutationObject(IMovieRepository movieRepository)
        {
            Name = "Mutations";
            Description = "The base mutation for all the entities in our object graph.";

            FieldAsync<MovieObject, Movie>("addReview", "Add review to a movie.", new QueryArguments(
                new QueryArgument<NonNullGraphType<IdGraphType>>
                {
                    Name = "id",
                    Description = "The unique GUID of the movie."
                },
                new QueryArgument<NonNullGraphType<ReviewInputObject>>
                {
                    Name = "review",
                    Description = "Review for the movie."
                }),
                context =>
                {
                    var id = context.GetArgument<Guid>("id");
                    var review = context.GetArgument<Review>("review");

                    return movieRepository.AddReviewToMovieAsync(id, review);
                });
        }
    }
}

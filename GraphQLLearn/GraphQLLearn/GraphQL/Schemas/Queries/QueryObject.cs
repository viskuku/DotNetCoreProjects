using GraphQL;
using GraphQL.Types;
using GraphQLLearn.GraphQL.Types;
using GraphQLLearn.Models;
using GraphQLLearn.Repositores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLLearn.GraphQL.Schemas.Queries
{
    public sealed class QueryObject : ObjectGraphType<object>
    {
        public QueryObject(IMovieRepository movieRepository)
        {
            Name = "Queries";
            Description = "The base query for all the entities in our object graph.";

            FieldAsync<MovieObject, Movie>("movie", "Gets a movie by its unique identifier.", 
                new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> 
                { Name ="id", Description= "The unique GUID of the movie." }),
                Context => movieRepository.GetMovieByIdAsync(Context.GetArgument("Id",Guid.Empty)));
        }
    }
}

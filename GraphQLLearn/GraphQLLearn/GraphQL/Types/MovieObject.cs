using GraphQL.Types;
using GraphQLLearn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLLearn.GraphQL.Types
{
    public sealed class MovieObject : ObjectGraphType<Movie>
    {
        public MovieObject()
        {
            Name = nameof(Movie);
            Description = "A movie in the collection";

            Field(m => m.Id).Description("Identifier of Movie");
            Field(m => m.Name).Description("Name of the Movie");
            Field(name:"Reviews", description:"Reviews of the Movie", type: typeof(ListGraphType<ReviewObject>), resolve: m=>m.Source.Reviews );
        }
    }
}

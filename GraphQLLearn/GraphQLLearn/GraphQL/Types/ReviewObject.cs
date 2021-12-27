using GraphQL.Types;
using GraphQLLearn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLLearn.GraphQL.Types
{
    public sealed class ReviewObject : ObjectGraphType<Review>
    {
        public ReviewObject()
        {
            Name = nameof(Review);
            Description = "A review of the movie";

            Field(r => r.Reviewer).Description("Name of the reviewer");
            Field(r => r.Stars).Description("Star rating out of five");
        }
    }
}

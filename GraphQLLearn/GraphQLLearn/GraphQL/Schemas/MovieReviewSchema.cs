using GraphQL.Types;
using GraphQLLearn.GraphQL.Schemas.Mutations;
using GraphQLLearn.GraphQL.Schemas.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLLearn.GraphQL.Schemas
{
    public class MovieReviewSchema : Schema
    {
        public MovieReviewSchema(QueryObject queryObject, MutationObject mutationObject, IServiceProvider serviceProvider):base(serviceProvider)
        {
            Query = queryObject;
            Mutation = mutationObject;
        }
    }
}

using GraphQL;
using RealEstateGraphQL.Queries;

namespace RealEstateGraphQL.Schema
{
    public class RealEstateSchema : GraphQL.Types.Schema
    {
        public RealEstateSchema(IDependencyResolver resolver): base(resolver)
        {
            Query = resolver.Resolve<PropertyQuery>();
        }
    }
}

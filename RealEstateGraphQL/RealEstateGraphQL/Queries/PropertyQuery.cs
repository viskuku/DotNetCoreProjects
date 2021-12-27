using GraphQL.Types;
using RealEstateGraphQL.DataAccess.Repositories.Contracts;
using RealEstateGraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateGraphQL.Queries
{
    public class PropertyQuery : ObjectGraphType
    {
        public PropertyQuery(IPropertyRepository propertyRepository)
        {
            Field<ListGraphType<PropertyType>>("properties", resolve: context => propertyRepository.GetAll());
        }
    }
}

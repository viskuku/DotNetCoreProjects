using RealEstateGraphQL.Database.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateGraphQL.DataAccess.Repositories.Contracts
{
    public interface IPropertyRepository
    {
        IEnumerable<Property> GetAll();
    }
}

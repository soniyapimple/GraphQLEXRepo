using GraphQL.Types;
using GraphQL.Utilities;
using GraphQLApi.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Web.Mvc;

namespace GraphQLApi.Schemas
{
    public class GraphQLDemoSchema : Schema
    {
        public GraphQLDemoSchema(IServiceProvider provider): base(provider)
        {
            Query = provider.GetRequiredService<AuthorQuery>();
        }
    }
}

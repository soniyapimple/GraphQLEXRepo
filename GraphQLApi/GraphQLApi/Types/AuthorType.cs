using GraphQL.Types;
using GraphQLApi.Models;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLApi.Types
{
    public class AuthorType : ObjectGraphType<Author>
    {
        public AuthorType()
        {
            Name = "Author";
            Field(_ => _.Id).Description("Author's Id");
            Field(_ => _.FirstName).Description("First Name of the Author");
            Field(_ => _.LastName).Description("Last Name of the Author");
        }
    }
}

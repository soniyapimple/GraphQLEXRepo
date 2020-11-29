using GraphQL.Types;
using GraphQLApi.Models;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLApi.Types
{
    public class BlogPostType : ObjectGraphType<BlogPost>
    {
        public BlogPostType()
        {
            Name = "BlogPost";
            Field(_ => _.Id, type: typeof(IdGraphType)).Description("The Id of the BlogPost");
            Field(_ => _.Title).Description("Title of Blog Post");
            Field(_ => _.Content).Description("The Content of Blog Post");
        }
    }
}

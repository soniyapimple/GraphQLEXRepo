using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.NewtonsoftJson;
using GraphQLApi.DTO;
using GraphQLApi.Schemas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GraphQLApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GraphQLController : ControllerBase
    {
        private readonly IDocumentExecuter documentExecuter;
        private readonly GraphQLDemoSchema schema;
        public GraphQLController(GraphQLDemoSchema schema, IDocumentExecuter documentExecuter)
        {
            this.documentExecuter = documentExecuter;
            this.schema = schema;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] GraphQLQueryDTO queryDTO)
        {
            if (queryDTO == null)
            {
                throw new ArgumentNullException(nameof(queryDTO));
            }

            var inputs = queryDTO.variables.ToInputs();

            var executionOptions = new ExecutionOptions
            {
                Schema = schema,
                Query = queryDTO.Query,
                Inputs = inputs
            };

            var results = await this.documentExecuter.ExecuteAsync(executionOptions);

            if (results.Errors?.Count > 0)
            {
                return BadRequest(results);
            }

            return Ok(results);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace api.Security.ApiKey
{
    public class CustomHeaderParameter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            operation.Parameters =
            [
                new OpenApiParameter
                {
                    Name = "X-Api-Key",
                    In = ParameterLocation.Header,
                    Description = "Header for API Auth",
                    Required = true
                }
            ];
        }
    }
}
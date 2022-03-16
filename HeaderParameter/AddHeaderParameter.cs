using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INCI_KILIC_MiddlewareAPI_HW2.HeaderParameter
{

    // REFERANS --->
    // https://stackoverflow.com/questions/41493130/web-api-how-to-add-a-header-parameter-for-all-api-in-swagger


    public class AddHeaderParameter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                operation.Parameters = new List<OpenApiParameter>();

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "app-version",
                In = ParameterLocation.Header,
                Required = false,
                Description = "app-version",
                Schema = new OpenApiSchema
                {
                    Type = "string",
                    ReadOnly = true,
                    Default = new OpenApiString("2.0.0.0")
                }
            });
        }
    }
}


using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace FanPage.Api.Swagger
{
    public class AuthOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (context != null)
            {
                var authAttributes = context.MethodInfo
                    .GetCustomAttributes(true)
                    .OfType<AuthorizeAttribute>()
                    .Distinct();

                if (!authAttributes.Any())
                    return;
            }

            if (operation == null) return;
            operation.Responses.TryAdd("401", new OpenApiResponse { Description = "Unauthorized" });

            var bearerScheme = new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "bearer" }
            };

            operation.Security = new List<OpenApiSecurityRequirement>
            {
                new OpenApiSecurityRequirement
                {
                    [bearerScheme] = Array.Empty<string>()
                }
            };
        }
    }
}

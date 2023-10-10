using Microsoft.OpenApi.Models;

public static class ApplicationBuilderExtensions
{
    private const string SwaggerPath = "/swagger/v1/swagger.json";

    /// <summary>
    /// Enables configured Swagger query processing.
    /// </summary>
    /// <param name="app">
    ///     An instance of an object that provides mechanisms for configuring application request processing channels.
    /// </param>
    public static void UseConfiguredSwagger(this IApplicationBuilder app)
    {
        app.UseSwagger(c =>
        {
            c.PreSerializeFilters.Add((swagger, httpReq) =>
            {
                swagger.Servers = new List<OpenApiServer>
                        {new OpenApiServer {Url = $"{httpReq.Scheme}://{httpReq.Host.Value}"}};
            });
            c.RouteTemplate = "swagger/{documentName}/swagger.json";
        });

        app.UseSwaggerUI(c => { c.SwaggerEndpoint(SwaggerPath, "Api FanPage V1"); });
    }
}
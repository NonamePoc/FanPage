using FanPage.Api.Mapper;
using Microsoft.OpenApi.Models;
using FanPage.Api.Configure;
using FanPage.Api.Hubs;
using FanPage.Api.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
var swaggerInfo = new OpenApiInfo
{
    Title = "Fan Page Api",
    Version = "v1"
};

builder.Services.ConfigureSwagger(builder.Configuration, swaggerInfo);
builder.Services.AddAutoMapper(typeof(OutputModelsMapperProfile));
builder.Services.DataBase(builder.Configuration);
builder.Services.Logger(builder.Configuration);
builder.Services.ConfigureAuthentication(builder.Configuration);
builder.Services.ConfigureSmtp(builder.Configuration);
builder.Services.ConfigureApplication(builder.Configuration);
builder.Services.ConfigureBusinessServices();
builder.Services.ConfigureMapper();
builder.Services.ConfigureRepository();
builder.Services.AddControllersWithViews();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        corsPolicyBuilder => corsPolicyBuilder
            .WithOrigins("http://127.0.0.1:5500")
            .AllowAnyMethod()
            .SetIsOriginAllowed((host) => true) //allow all connections (including Signalr)
            .AllowAnyHeader()
            .AllowCredentials());
});

builder.Services.AddSignalR();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(x => { x.SwaggerEndpoint("/swagger/v1/swagger.json", "FanPage.Api WEB API v1.0.0"); });
}

app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true)
    .AllowCredentials());

app.UseStaticFiles(new StaticFileOptions
{
    OnPrepareResponse = ctx =>
    {
        // Встановити заголовки кешування для статичних файлів
        ctx.Context.Response.Headers.Append("Cache-Control", "public, max-age=31536000");
    }
});
app.UseMiddleware<GlobalExceptionMiddleware>();
app.UseMiddleware<CorsMiddleware>(); 

app.UseApiLogging();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<CommentHub>("/commentHub");
    endpoints.MapHub<ChatHub>("/chatHub");
});

app.MapControllers();

app.SeedIdentity();

app.Run();
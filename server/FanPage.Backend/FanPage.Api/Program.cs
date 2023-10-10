using FanPage.Api.Mapper;
using FanPage.APi.Configure;
using FanPage.APi.Middware;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;


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


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(x => { x.SwaggerEndpoint("/swagger/v1/swagger.json", "FanPage.Api WEB API v1.0.0"); });
}

app.UseMiddleware<GlobalExceptionMiddleware>();


app.UseApiLogging();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.SeedIdentity();

app.Run();
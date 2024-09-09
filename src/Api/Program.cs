using TvMaze.Api.DependencyInjection;
using TvMaze.Application.DependencyInjection;
using TvMaze.Application.Features;
using TvMaze.ShareCommon.Exceptions;
using TvMaze.ShareCommon.Models.Settings;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

var appSettings = configuration.GetSection("AppSettings").Get<AppSettings>();
if (appSettings == null)
{
    throw new MissingConfigurationException();
}

appSettings.CheckConfigurations();

builder.Services
    .AddApiServices(appSettings)
    .AddApplicationServices()
    .AddInfrastructureServices(appSettings);

var app = builder.Build();

app.UseCors();

app.UseHttpsRedirection();

if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error-development");
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
    app.UseHttpLogging();
}
else
{
    app.UseExceptionHandler("/error");
}

app.UseAuthorization();
app.UseHttpsRedirection();
app.MapEndpoints();

app.Run();
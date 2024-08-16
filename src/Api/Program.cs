using TvMaze.Api.DependencyInjection;
using TvMaze.Application.DependencyInjection;
using TvMaze.Application.Features;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services
    .AddApiServices(configuration)
    .AddApplicationServices()
    .AddInfrastructureServices(configuration);

var app = builder.Build();

// Enable middleware to serve generated Swagger as a JSON endpoint.
app.UseSwagger();

// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

app.UseCors();

app.UseHttpsRedirection();

if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error-development");
    app.UseSwagger();
    app.UseSwaggerUI();
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

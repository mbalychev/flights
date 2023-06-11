using flights.models;
using flights.Repository;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
var services = builder.Services;

builder.WebHost.UseUrls(urls: "http://0.0.0.0:3002");
services.AddDbContext<DemoContext>();
services.AddCors();

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddTransient<FlightRepository>();

services.AddSwaggerGen(opt =>
{
    var xmlFilename = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    opt.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

    opt.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Flights API",
        Version = "v1",

        Description = "API управления полетами (демо версия)"
    });

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

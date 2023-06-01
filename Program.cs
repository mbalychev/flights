using flights.models;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
var services = builder.Services;

services.AddDbContext<DemoContext>();
services.AddCors();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

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

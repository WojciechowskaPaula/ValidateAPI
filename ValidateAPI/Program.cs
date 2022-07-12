using Microsoft.OpenApi.Models;
using Serilog;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x=>
{
    x.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Validate API",
        Description = "API for validate parameters",
        Contact = new OpenApiContact
        {
            Name = "Paula Wojciechowska-Rynkowska",
            Email = "paulla.wojciechowska@gmail.com"
        }
    });
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath =(Path.Combine(AppContext.BaseDirectory, xmlFilename));
    x.IncludeXmlComments(xmlPath);
});
builder.Host.UseSerilog((ctx, lc) => lc
.WriteTo.Console()
.WriteTo.File(".\\Logs\\ValidateAPI.log.txt", rollingInterval: RollingInterval.Day));

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

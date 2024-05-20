using FL.AppServices.Implementations;
using FL.AppServices.Interfaces;
using FL.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnectionString");
builder.Services.AddDbContext<FLDbContext>(options => options.UseSqlServer(connectionString, b => b.MigrationsAssembly("FL.WebAPI")));

builder.Services.AddScoped<DbContext, FLDbContext>();
builder.Services.AddScoped<ICarManagementService, CarManagementService>();
builder.Services.AddScoped<ILapManagementService, LapManagementService>();
builder.Services.AddScoped<IDriverManagementService, DriverManagementService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Version = "v1",
        Title = "Fast Laps",
        Description = "RESTful API for project Fast Laps"

    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

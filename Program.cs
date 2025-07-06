using Microsoft.EntityFrameworkCore;
using PetsFoundation.Application.Interfaces;
using PetsFoundation.Application.Services.Pets;
using PetsFoundation.Infraestructure.Api.Filters;
using PetsFoundation.Infraestructure.Persistance;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<PetsContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.

builder.Services.AddControllers(options =>
{ options.Filters.Add<PetsExceptionFilter>(); });

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("log.txt",
        rollingInterval: RollingInterval.Day)
    .CreateLogger();
builder.Host.UseSerilog(Log.Logger);

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddScoped<ICreatePet, CreatePet>();
builder.Services.AddScoped<IGetPet, GetPet>();
builder.Services.AddScoped<IPetRepository, PetRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

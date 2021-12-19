using System.Reflection;
using beng.InventoryService.Application.Features.CreateProduct;
using beng.InventoryService.Infrastructure;
using beng.OrdersService.Application.Common;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddControllers()
    .AddDapr()
    .AddFluentValidation(configuration =>
    {
        configuration.RegisterValidatorsFromAssembly(Assembly.GetAssembly(typeof(CreateProductCommandValidator)));
        configuration.AutomaticValidationEnabled = false;
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//infra
//database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("postgres")));

// application
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehaviour<,>));    

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseRouting();

app.UseAuthorization();

app.UseCloudEvents();

app.UseEndpoints(endpoints => { endpoints.MapSubscribeHandler(); });

app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(op=>op.RoutePrefix = string.Empty);
}

app.Run();
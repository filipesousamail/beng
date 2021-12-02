using System.Reflection;
using System.Text.Json;
using beng.OrdersService.Application.Common;
using beng.OrdersService.Application.Features.Orders.GetOrders;
using beng.OrdersService.Application.Features.Users;
using beng.OrdersService.Infrastructure;
using beng.OrdersService.Infrastructure.Gateways;
using beng.OrdersService.Infrastructure.Repositories;
using Dapr.Client;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddDapr()
    .AddFluentValidation(configuration =>
        configuration.RegisterValidatorsFromAssembly(Assembly.GetAssembly(typeof(CreateUserCommandValidator))));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//infra
//database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("postgres")));

//Apply migrations
var serviceProvider = builder.Services.BuildServiceProvider();
using var scope = serviceProvider.CreateScope();
var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
db.Database.Migrate();

// repos 
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();

// gateways
builder.Services.AddSingleton<IUserServiceGateway, UserServiceGateway>(
    _ => new UserServiceGateway(DaprClient.CreateInvokeHttpClient("userservice")));

// application
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehaviour<,>));    

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseRouting();

// app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCloudEvents();

app.UseEndpoints(endpoints => { endpoints.MapSubscribeHandler(); });

app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();
using System.Reflection;
using beng.UsersService.Application.Common;
using beng.UsersService.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddDapr();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//infra
//database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("postgres")));

// application
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
// mediator behaviours
builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehaviour<,>));    
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(TransactionBehaviour<,>));

var app = builder.Build();

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseCloudEvents();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints => { endpoints.MapSubscribeHandler(); });

app.MapControllers();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();
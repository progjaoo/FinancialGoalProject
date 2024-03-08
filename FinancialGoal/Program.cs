using FinancialGoal.Application.Commands.ObjetivosFinanceiros.AtualizarObjetivo;
using FinancialGoal.Application.Commands.ObjetivosFinanceiros.CriarObjetivo;
using FinancialGoal.Application.Queries.ObjetivoFinanceiro.BuscarTodos;
using FinancialGoal.Core.Repositories;
using FinancialGoal.Infrastructure.Persistence;
using FinancialGoal.Infrastructure.Persistence.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//connection string
builder.Services.AddDbContext<ObjetivoFinanceiroDbContext>(options
                => options.UseSqlServer(builder.Configuration.GetConnectionString("ObjetivoFinanceiroDB")));

//mediatr
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

builder.Services.AddMediatR(typeof(BuscarTodosQuery));
builder.Services.AddMediatR(typeof(AddObjetivoCommand));
builder.Services.AddMediatR(typeof(AtualizarObjetivoCommand));

//repositorioes
builder.Services.AddScoped<IObjetivoFinanceiroRepository, ObjetivoFinanceiroRepository>();

//CQRS-Dependency

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

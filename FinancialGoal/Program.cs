using FinancialGoal.Application.Commands.ObjetivosFinanceiros.AtualizarObjetivo;
using FinancialGoal.Application.Commands.ObjetivosFinanceiros.CriarObjetivo;
using FinancialGoal.Application.Queries.ObjetivoFinanceiro.BuscarTodos;
using FinancialGoal.Core.Repositories;
using FinancialGoal.Infrastructure.Persistence;
using FinancialGoal.Infrastructure.Persistence.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    s =>
    {
        s.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "FinancialGoal.API",
            Version = "v1",
            Contact = new OpenApiContact
            {
                Name = "João Marcos Valente",
                Email = "joaoprog.valente@gmail.com",
                Url = new Uri("https://github.com/progjaoo")
            }
        });
    });

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

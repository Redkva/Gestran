using Api.Servicos;
using Api.Servicos.Interfaces;
using Domain.Interfaces;
using Domain.Repositorio;
using Domain.Servicos;
using Microsoft.EntityFrameworkCore;
using Repositorio.DAL;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Conexao com o banco
builder.Services.AddDbContext<RepositorioBase>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));

#region Injecao de Dependencia

//Camada de Aplicacao
builder.Services.AddScoped<IServicoDeAplicacaoDeFornecedor, ServicoDeAplicacaoFornecedor>();

//Camada de Dominio
builder.Services.AddScoped<IServicoDeDominioDeFornecedor, ServicoDeDominioDeFornecedor>();

//Camada de Repositorio
builder.Services.AddScoped<IRepositorioFornecedor, RepositorioFornecedor>();

#endregion


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

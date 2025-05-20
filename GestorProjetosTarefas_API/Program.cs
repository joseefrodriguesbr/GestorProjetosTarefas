using System.Text.Json.Serialization;
using GestorProjetosTarefas.Shared.Data.BD;
using GestorProjetosTarefas_API.Endoints;
using GestorProjetosTarefas_Console;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddDbContext<GestorProjetosTarefasContext>();
builder.Services.AddTransient<DAL<Empregado>>();
builder.Services.AddTransient<DAL<Tarefa>>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.AddEndPointsEmpregado();
app.AddEndPointTarefas();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
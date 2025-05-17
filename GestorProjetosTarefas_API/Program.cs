using System.Text.Json.Serialization;
using GestorProjetosTarefas.Shared.Data.BD;
using GestorProjetosTarefas.Shared.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var app = builder.Build();

//teste da requisição GET --
app.MapGet("/", () =>
{
    var dal = new DAL<Empregado>();
    return dal.Read();
});

app.Run();
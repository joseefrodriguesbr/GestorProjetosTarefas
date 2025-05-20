using GestorProjetosTarefas.Shared.Data.BD;
using GestorProjetosTarefas_Console;
using Microsoft.AspNetCore.Mvc;

namespace GestorProjetosTarefas_API.Endoints
{
    public static class TarefaExtension
    {
        public static void AddEndPointTarefas(this WebApplication app)
        {
            app.MapGet("/Tarefa", ([FromServices] DAL<Tarefa> dal) =>
            {
                return Results.Ok(dal.Read());
            }
            );

            app.MapPost("/Tarefa", ([FromServices] DAL<Tarefa> dal, [FromBody] Tarefa tarefa) =>
            {

                dal.Create(tarefa);
                return Results.Created();
            }
            );

            app.MapDelete("/Tarefa/{id}", ([FromServices] DAL<Tarefa> dal, int id) =>
            {
                var tarefa = dal.ReadBy(t => t.Id == id);
                if (tarefa is null)
                {
                    return Results.NotFound();
                }

                dal.Delete(tarefa);
                return Results.NoContent();
            }
            );

            app.MapPut("/Tarefa", ([FromServices] DAL<Tarefa> dal, [FromBody] Tarefa tarefa) =>
            {
                var tarefaEdit = dal.ReadBy(t => t.Id == tarefa.Id);
                if (tarefaEdit is null) return Results.NotFound();

                tarefaEdit.Nome = tarefa.Nome;
                tarefaEdit.Descricao = tarefa.Descricao;
                tarefaEdit.DuracaoDias = tarefa.DuracaoDias;
                dal.Update(tarefaEdit);
                return Results.Created();
            }
            );
        }
    }
}

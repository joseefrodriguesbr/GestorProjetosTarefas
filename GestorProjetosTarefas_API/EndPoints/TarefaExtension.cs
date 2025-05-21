using GestorProjetosTarefas.Shared.Data.BD;
using GestorProjetosTarefas.Shared.Models;
using GestorProjetosTarefas_API.Requests;
using GestorProjetosTarefas_API.Responses;
using Microsoft.AspNetCore.Mvc;

namespace GestorProjetosTarefas_API.Endoints
{
    public static class TarefaExtension
    {
        public static void AddEndPointTarefas(this WebApplication app)
        {
            app.MapGet("/Tarefa", ([FromServices] DAL<Tarefa> dal) =>
            {
                var tarefaList = dal.Read();
                if (tarefaList == null) return Results.NotFound();

                var empregagoResponseList = EntityListToResponseList(tarefaList);
                return Results.Ok(empregagoResponseList);
            }
            );

            app.MapGet("/Tarefa/{id}", (int id, [FromServices] DAL<Tarefa> dal) =>
            {
                var tarefa = dal.ReadBy(t => t.Id == id);
                if (tarefa is null) return Results.NotFound();
                return Results.Ok(EntityToResponse(tarefa));
            });

            app.MapPost("/Tarefa", ([FromServices] DAL<Tarefa> dal, [FromBody] TarefaRequest tarefa) =>
            {

                dal.Create(new Tarefa(tarefa.nome,tarefa.descricao,tarefa.duracaoDias));
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

            app.MapPut("/Tarefa", ([FromServices] DAL<Tarefa> dal, [FromBody] TarefaEditRequest tarefa) =>
            {
                var tarefaEdit = dal.ReadBy(t => t.Id == tarefa.id);
                if (tarefaEdit is null) return Results.NotFound();

                tarefaEdit.Nome = tarefa.nome;
                tarefaEdit.Descricao = tarefa.descricao;
                tarefaEdit.DuracaoDias = tarefa.duracaoDias;
                dal.Update(tarefaEdit);
                return Results.Created();
            }
            );
        }

        private static ICollection<TarefaResponse> EntityListToResponseList(IEnumerable<Tarefa> entities)
        {
            return entities.Select(a => EntityToResponse(a)).ToList();
        }

        private static TarefaResponse EntityToResponse(Tarefa entity)
        {
            return new TarefaResponse(entity.Id, entity.Nome, entity.Descricao, entity.DuracaoDias);
        }
    }
}

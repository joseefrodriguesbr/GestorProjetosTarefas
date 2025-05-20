using System.Runtime.CompilerServices;
using GestorProjetosTarefas.Shared.Data.BD;
using GestorProjetosTarefas_API.Requests;
using GestorProjetosTarefas.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using GestorProjetosTarefas_API.Responses;

namespace GestorProjetosTarefas_API.Endoints
{
    public static class EmpregadoExtension
    {

        public static void AddEndPointsEmpregado(this WebApplication app)
        {

            app.MapGet("/Empregado", ([FromServices] DAL<Empregado> dal) =>
            {
                var empregadoList = dal.Read();
                if (empregadoList == null)return Results.NotFound();

                var empregadoResponseList = EntityListToResponseList(empregadoList);
                
                return Results.Ok(empregadoResponseList);
            }
            );

            app.MapPost("/Empregado", ([FromServices] DAL<Empregado> dal, [FromBody] EmpregadoRequest empregado) =>
            {
                dal.Create(new Empregado(empregado.nome,empregado.matricula));
                return Results.Created();
            }
            );

            app.MapDelete("/Empregado/{id}", ([FromServices] DAL<Empregado> dal, int id) =>
            {
                var empregado = dal.ReadBy(e => e.Id == id);
                if (empregado is null)
                {
                    return Results.NotFound();
                }

                dal.Delete(empregado);
                return Results.NoContent();
            }
            );

            app.MapPut("/Empregado", ([FromServices] DAL<Empregado> dal, [FromBody] EmpregadoEditRequest empregado) =>
            {
                var empregadoEdit = dal.ReadBy(e => e.Id == empregado.id);
                if (empregadoEdit is null) return Results.NotFound();

                empregadoEdit.Nome = empregado.nome;
                empregadoEdit.Matricula = empregado.matricula;
                dal.Update(empregadoEdit);
                return Results.Created();
            }
            );

        }

        private static ICollection<EmpregadoResponse> EntityListToResponseList(IEnumerable<Empregado> entities)
        {
            return entities.Select(a=>EntityToResponse(a)).ToList();
        }

        private static EmpregadoResponse EntityToResponse(Empregado entity)
        {
            return new EmpregadoResponse(entity.Id,entity.Nome,entity.Matricula);
        }
    }
}

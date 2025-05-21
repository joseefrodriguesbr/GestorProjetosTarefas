using GestorProjetosTarefas.Shared.Data.BD;
using GestorProjetosTarefas.Shared.Models;
using GestorProjetosTarefas_API.Requests;
using GestorProjetosTarefas_API.Responses;
using Microsoft.AspNetCore.Mvc;

namespace GestorProjetosTarefas_API.EndPoints
{
    public static class ProjetoExtension
    {
        public static void AddEndPointsProjeto(this WebApplication app)
        {

            app.MapGet("/Projeto", ([FromServices] DAL<Projeto> dal) =>
            {
                var projetoList = dal.Read();
                if (projetoList == null) return Results.NotFound();

                var projetoResponseList = EntityListToResponseList(projetoList);

                return Results.Ok(projetoResponseList);
            }
            );

            app.MapGet("/Projeto/{id}", (int id, [FromServices] DAL<Projeto> dal) =>
            {
                var projeto = dal.ReadBy(e => e.Id == id);
                if (projeto is null) return Results.NotFound();
                return Results.Ok(EntityToResponse(projeto));
            });

            app.MapPost("/Projeto", ([FromServices] DAL<Projeto> dal, [FromBody] ProjetoRequest projeto) =>
            {
                dal.Create(RequestToEntity(projeto));
                return Results.Created();
            }
            );

            app.MapDelete("/Projeto/{id}", ([FromServices] DAL<Projeto> dal, int id) =>
            {
                var projeto = dal.ReadBy(e => e.Id == id);
                if (projeto is null)
                {
                    return Results.NotFound();
                }

                dal.Delete(projeto);
                return Results.NoContent();
            }
            );
            
            app.MapPut("/Projeto", ([FromServices] DAL<Projeto> dal, [FromBody] ProjetoEditRequest projeto) =>
            {
                var projetoEdit = dal.ReadBy(e => e.Id == projeto.id);
                if (projetoEdit is null) return Results.NotFound();

                projetoEdit.Nome = projeto.nome;
                projetoEdit.Detalhe = projeto.detalhe;
                projetoEdit.Orcamento = projeto.orcamento;
                dal.Update(projetoEdit);
                return Results.Created();
            }
            );

        }


        private static List<Projeto> ProjetoRequestConvert(ICollection<ProjetoRequest> projetoList)
        {
            return projetoList.Select(p => RequestToEntity(p)).ToList();
           }

        private static Projeto RequestToEntity(ProjetoRequest projeto)
        {
            return new Projeto() { Nome = projeto.Nome, Detalhe = projeto.Detalhe, Orcamento = projeto.Orcamento};
        }

        private static ICollection<ProjetoResponse> EntityListToResponseList(IEnumerable<Projeto> entities)
        {
            return entities.Select(a => EntityToResponse(a)).ToList();
        }

        private static ProjetoResponse EntityToResponse(Projeto entity)
        {
            return new ProjetoResponse(entity.Id, entity.Nome, entity.Detalhe, entity.Orcamento);
        }
    }
}

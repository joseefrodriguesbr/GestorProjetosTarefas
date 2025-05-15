using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestorProjetosTarefas.Shared.Data.Migrations
{
    /// <inheritdoc />
    public partial class TarefaDataEntry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Tarefa", new[] { "Nome", "Descricao", "DuracaoDias", "EmpregadoId" }, new Object[] { "Progamacao", "Progamacao de dados",5, 1 });
            migrationBuilder.InsertData("Tarefa", new[] { "Nome", "Descricao", "DuracaoDias", "EmpregadoId" }, new Object[] { "repositorio", "configuracao do repositorio", 2, 1 });
            migrationBuilder.InsertData("Tarefa", new[] { "Nome", "Descricao", "DuracaoDias", "EmpregadoId" }, new Object[] { "banco de dados", "projeto banco", 1, 2 });
            migrationBuilder.InsertData("Tarefa", new[] { "Nome", "Descricao", "DuracaoDias", "EmpregadoId" }, new Object[] { "GUI", "Interface gráfica", 10, 3 });
            migrationBuilder.InsertData("Tarefa", new[] { "Nome", "Descricao", "DuracaoDias", "EmpregadoId" }, new Object[] { "documentao", "manual do usuario", 4, 4 });
            migrationBuilder.InsertData("Tarefa", new[] { "Nome", "Descricao", "DuracaoDias", "EmpregadoId" }, new Object[] {"levantamento de requisito", "Casos de Uso", 7, 4 });
            migrationBuilder.InsertData("Tarefa", new[] { "Nome", "Descricao", "DuracaoDias", "EmpregadoId" }, new Object[] {"DevOps", "Projeto de software", 1, 4 });
            migrationBuilder.InsertData("Tarefa", new[] { "Nome", "Descricao", "DuracaoDias", "EmpregadoId" }, new Object[] {"IA", "Agentes de IA", 12, 5 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

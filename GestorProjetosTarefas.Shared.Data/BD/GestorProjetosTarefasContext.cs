using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestorProjetosTarefas_Console;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace GestorProjetosTarefas.Shared.Data.BD
{
    public class GestorProjetosTarefasContext : DbContext
    {
        public DbSet<Empregado> Empregado { get; set; }

        public DbSet<Tarefa> Tarefa { get; set; }

        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=GestorProjetosTarefas_BD_V1;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        /*
        public SqlConnection Connect()
        {
            return new SqlConnection(connectionString);
        }
        */

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString).UseLazyLoadingProxies();
        }
    }
}

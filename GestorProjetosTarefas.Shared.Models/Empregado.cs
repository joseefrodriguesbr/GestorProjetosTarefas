using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorProjetosTarefas.Shared.Models
{
    public class Empregado
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public string Matricula { get; set; }

        public virtual ICollection<Tarefa> Tarefa { get; set; } = new List<Tarefa>();

        private List<Tarefa> Tarefas = new();

        public Empregado(string nome, string matricula)
        {
            Nome = nome;
            Matricula = matricula;
        }

        public override string ToString()
        {
            return $@"Id: {Id} , Empregado: {Nome} , Matrícula: {Matricula}";
        }

        public void adicionarTarefas(Tarefa tarefa)
        {
            Tarefa.Add(tarefa);
        }

        public void showTarefas()
        {
            Console.WriteLine($"Tarefas do empregado:{Nome}");
            if (Tarefa.Count > 0)
            {
                foreach (Tarefa tarefa in Tarefa)
                {
                    Console.WriteLine(tarefa);
                }
            }
            else
            {
                Console.WriteLine("Nenhuma tarefa registrada");
            }
        }
    }
}

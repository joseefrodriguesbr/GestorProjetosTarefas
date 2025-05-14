using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorProjetosTarefas_Console
{
    internal class Tarefa
    {
        public string Nome {  get; set; }

        public string Descricao { get; set; }

        public int DuracaoDias { get; set; }

        public Tarefa(string nome, string descricao, int duracaoDias)
        {
            Nome = nome;
            Descricao = descricao;
            DuracaoDias = duracaoDias;
        }

        public override string ToString()
        {
            return $@"Tarefa: {Nome} , descricao: {Descricao} , duração em dias: {DuracaoDias}";
        }
    }
}

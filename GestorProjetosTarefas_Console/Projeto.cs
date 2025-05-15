using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorProjetosTarefas_Console
{
    internal class Projeto
    {
        public string Nome {  get; set; }

        public string Detalhe { get; set; }

        public double Orcamento { get; set; }

        public Projeto(string nome, string detalhe, double orcamento)
        {
            Nome = nome;
            Detalhe = detalhe;
            Orcamento = orcamento;
        }

        public override string ToString()
        {
            return $@"Projeto: {Nome} , detalhe: {Detalhe}, orçamento : {Orcamento}";
        }
    }
}

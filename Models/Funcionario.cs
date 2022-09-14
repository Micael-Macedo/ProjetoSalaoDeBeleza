using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoSalaoDeBeleza.Models
{
    public class Funcionario
    {
        public int FuncionarioId { get; set; }
        public string Nome { get; set; }
        public string Funcao { get; set; }
        public string Matricula { get; set; }
        public bool TemCNH { get; set; }
        public double Salario { get; set; }
    }
}
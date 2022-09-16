using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoSalaoDeBeleza.Models
{
    public class Setor
    {
        public int SetorId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public virtual ICollection<Funcionario> Funcionarios { get; set; }
    }
}
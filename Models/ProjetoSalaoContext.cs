using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProjetoSalaoDeBeleza.Models
{
    public class ProjetoSalaoContext:DbContext
    {
        public ProjetoSalaoContext(DbContextOptions<ProjetoSalaoContext> options):base(options){}

        public DbSet<Funcionario> Funcionarios { get; set; }
    }
}
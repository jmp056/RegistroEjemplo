using RegistroEjemplo.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroEjemplo.DAL
{
    public class Contexto : DbContext {
        public DbSet<Personas> Persona { get; set; }
        public Contexto() : base("ConStr") { }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Empresa.LogicaDeNegocio.Entidades;
using Empresa.LogicaDeNegocio.Sistema;
using Papeleria.LogicaNegocio.Entidades.ValueObjects.Pedidos;
using Papeleria.LogicaNegocio.Entidades;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Papeleria.LogicaNegocio.Entidades.ValueObjects.Clientes;
using Papeleria.AccesoDatos.Configuraciones;

namespace Papeleria.AccesoDatos.EF
{
    public class PapeleriaContext:DbContext
    {
        public DbSet<Usuario> Usuarios{ get; set; }
        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Express> Expresses { get; set; }
        public DbSet<Comunes> Comuns { get; set; }
        public DbSet<LineaPedido> LineasPedidos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"SERVER=(localDB)\Mssqllocaldb;DATABASE=PapeleriaOBL;INTEGRATED SECURITY=True; encrypt=false");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new ClienteConfiguraciones().Configure(modelBuilder.Entity<Cliente>());
            modelBuilder.ApplyConfiguration(new ClienteConfiguraciones());
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Empresa.LogicaDeNegocio.Entidades;
using Empresa.LogicaDeNegocio.Sistema;
using Papeleria.LogicaNegocio.Entidades;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Papeleria.AccesoDatos.EF
{
    public class PapeleriaContext:DbContext
    {
        public DbSet<Usuario> Usuarios{ get; set; }
        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<EncargadoDeposito> EncargadosDepositos { get; set; }
        public DbSet<TipoMovimiento> TiposMovimientos { get; set; }
        public DbSet<MovimientoStock> MovimientoStocks { get; set; }

        public PapeleriaContext(DbContextOptions options) : base(options) { }
        public PapeleriaContext():base()
        {
            
        }
         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
          {
            if (!optionsBuilder.IsConfigured) throw new Exception("OptionsBuilder not configured");
          }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 
        }
    }
}

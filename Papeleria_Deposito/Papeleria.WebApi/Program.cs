
using Microsoft.EntityFrameworkCore;
using Papeleria.AccesoDatos.EF;
using Papeleria.LogicaAplicacion.ImplementacionCasosUso.Articulos;
using Papeleria.LogicaAplicacion.ImplementacionCasosUso.Usuarios;
using Papeleria.LogicaAplicacion.InterfacesCasosUso.Articulos;
using Papeleria.LogicaAplicacion.InterfacesCasosUso.Usuarios;
using Papeleria.LogicaNegocio.InterfacesRepositorio;

namespace Papeleria.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options => options.IncludeXmlComments("Docu.xml"));

            //Dependencias
            builder.Services.AddScoped<IRepositorioArticulo, RepositorioArticuloEF>();
            builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuarioEF>();

            /* 
             builder.Services.AddScoped<>();
             */
            builder.Services.AddScoped<IAltaArticulo, AltaArticulo>();
            builder.Services.AddScoped<IBorrarArticulo, BorrarArticulo>();
            builder.Services.AddScoped<IGetArticulo, BuscarArticulo>();
            builder.Services.AddScoped<IGetAllArticulos, GetAllArticulos>();
            builder.Services.AddScoped<IUpdateArticulo, UpdateArticulo>();
            builder.Services.AddScoped<IAltaUsuario, AltaUsuarios>();
            builder.Services.AddScoped<IBorrarUsuario, BorrarUsuario>();
            builder.Services.AddScoped<IGetUsuario, BuscarUsuario>();
            builder.Services.AddScoped<IGetAllUsuarios, GetAllUsuarios>();
            builder.Services.AddScoped<IModificarUsuario, ModificarUsuario>();


            //Configuración de la base de datos
            builder.Services.AddDbContext<PapeleriaContext>(
                options => options.UseSqlServer(@"SERVER=(localDB)\Mssqllocaldb;DATABASE=PapeleriaOBLv2;INTEGRATED SECURITY=True; encrypt=false")
            );



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {

                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
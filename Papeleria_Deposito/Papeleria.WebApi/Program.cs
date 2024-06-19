
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NuGet.Common;
using Papeleria.AccesoDatos.EF;
using Papeleria.LogicaAplicacion.ImplementacionCasosUso.Articulos;
using Papeleria.LogicaAplicacion.ImplementacionCasosUso.TipoMovimientos;
using Papeleria.LogicaAplicacion.ImplementacionCasosUso.Usuarios;
using Papeleria.LogicaAplicacion.InterfacesCasosUso.Articulos;
using Papeleria.LogicaAplicacion.InterfacesCasosUso.TipoMovimientos;
using Papeleria.LogicaAplicacion.InterfacesCasosUso.Usuarios;
using Papeleria.LogicaNegocio.InterfacesRepositorio;
using System.Drawing;
using System.Text;

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
            builder.Services.AddScoped<IRepositorioTipoMovimiento, RepositorioTipoMovimientoEF>();
            builder.Services.AddScoped<IRepositorioMovimientoStock, RepositorioMovimientoStockEF>();

            /* pal copypaste
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

            builder.Services.AddScoped<IAltaArticulo, AltaArticulo>();
            builder.Services.AddScoped<IBorrarArticulo, BorrarArticulo>();
            builder.Services.AddScoped<IGetArticulo, BuscarArticulo>();
            builder.Services.AddScoped<IGetAllArticulos, GetAllArticulos>();
            builder.Services.AddScoped<IUpdateArticulo, UpdateArticulo>();

            builder.Services.AddScoped<IAltaTiposMovimientos, AltaTipoMovimiento>();
            builder.Services.AddScoped<IBorrarTipoMovimiento, BorrarTipoMovimiento>();
            builder.Services.AddScoped<IGetTipoMovimiento, BuscarTipoMovimiento>();
            builder.Services.AddScoped<IGetAllTipoMovimiento, GetAllTiposMovimientos>();
            builder.Services.AddScoped<IUpdateTipoMovimiento, ModificarTipoMovimiento>();


            //Configuración de la base de datos
            builder.Services.AddDbContext<PapeleriaContext>(
                options => options.UseSqlServer(@"SERVER=(localDB)\Mssqllocaldb;DATABASE=PapeleriaOBLv2;INTEGRATED SECURITY=True; encrypt=false")
            );

            //Inyectar los servicios necesarios para la autenticacion
            var claveDificil =
                "ClaveMuySecreta1_ClaveMuySecreta1_ClaveMuySecreta1_ClaveMuySecreta1_ClaveMuySecreta1_ClaveMuySecreta1";
            var claveDificilEncriptada = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(claveDificil));

            #region Registro de servicios JWT.
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt =>
                 {
                     opt.TokenValidationParameters = new TokenValidationParameters
                    {
                         //Definir las validaciones a realizar
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = false,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = claveDificilEncriptada
                     };
                });

            #endregion


            var app = builder.Build();

            //Habilitar la autorizacion y autenticacion en la app.
            //para que los usuarios puedan acceder a los recursos protegidos
            //ORDEN: 1- Autenticacion 2- Autorizacion 3- Ruteo
            app.UseAuthorization();
            app.UseAuthorization();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {

                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();


            app.MapControllers();

            app.Run();
        }
    }
}
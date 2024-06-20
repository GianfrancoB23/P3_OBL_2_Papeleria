using Microsoft.Extensions.Options;

namespace Papeleria.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Generar sesiones de 20 minutos
            builder.Services.AddSession();
            // Add services to the container.
            builder.Services.AddControllersWithViews();
            // Add HttpClient
            builder.Services.AddHttpClient();
            builder.Services.AddSession(opt => {
                opt.Cookie.IsEssential = true;
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            //la app usa las sesiones
            app.UseSession();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Login}/{action=Autorizar}/{id?}");

            app.Run();
        }
    }
}
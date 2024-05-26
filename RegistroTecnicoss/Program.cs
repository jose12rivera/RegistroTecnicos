using Microsoft.EntityFrameworkCore;
using RegistrodeTecnicos.Services;
using RegistroTecnicoss.Components;
using RegistroTecnicoss.DAL;
using RegistroTecnicoss.Services;

namespace RegistroTecnicoss
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            // Obtener la cadena de conexión para usarla en el contexto
            var ConStr = builder.Configuration.GetConnectionString("ConStr");

            // Agregar el contexto al builder con la cadena de conexión
            builder.Services.AddDbContext<Contexto>(Options => Options.UseSqlite(ConStr));

            // Inyectar el servicio
            builder.Services.AddScoped<TecnicoService>();
            builder.Services.AddScoped<TipoTecnicoService>();
            builder.Services.AddScoped< IncentivosService> ();

            builder.Services.AddBlazorBootstrap();

            //// Añadir logging
            //builder.Logging.SetMinimumLevel(LogLevel.Debug);
            //builder.Logging.AddConsole();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}

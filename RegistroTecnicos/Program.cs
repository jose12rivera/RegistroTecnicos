using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.Components;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;
using RegistroTecnicos.Services;

namespace RegistroTecnicos
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            // La inyecci?n del contexto con SqlServer
            var SqlConStr = builder.Configuration.GetConnectionString("SqlConStr");
            builder.Services.AddDbContextFactory<Contexto>(o => o.UseSqlServer(SqlConStr));


            // La inyecci?n de servicios adicionales especificados en el segundo c?digo
            builder.Services.AddScoped<TecnicosServices>();
            builder.Services.AddScoped<TiposTecnicosServices>();
            builder.Services.AddScoped<ClientesServices>();
            builder.Services.AddScoped<TrabajosServices>();
            builder.Services.AddScoped<PrioridadesServices>();
            builder.Services.AddScoped<ArticulosServices>();
            builder.Services.AddScoped<CotizacionesServices>();

            // La inyecci?n del Bootstrap
            builder.Services.AddBlazorBootstrap();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error", createScopeForErrors: true);
                // The default HSTS value is 30 d?as. Puedes cambiar esto para escenarios de producci?n si es necesario.
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
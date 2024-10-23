using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.Components;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;
using RegistroTecnicos.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

//La inyeccion Del Contexto Con SqlServer
var SqlConStr = builder.Configuration.GetConnectionString("SqlConStr");
builder.Services.AddDbContextFactory<Contexto>(o => o.UseSqlServer(SqlConStr));

//La inyeccion Del services
builder.Services.AddScoped<TecnicosServices>();

//La inyeccion del services Tipos Tecnicos
builder.Services.AddScoped<TiposTecnicosServices>();

//La inyeccion del services Clientes
builder.Services.AddScoped<ClientesServices>();

//La inyeccion del services Trabajos
builder.Services.AddScoped<TrabajosServices>();

//La inyeccion del services de  Prioridades
builder.Services.AddScoped<PrioridadesServices>();

//La inyeccion del services de  Articulos
builder.Services.AddScoped<ArticulosServices>();

//La inyeccion del services de  CotizacionesServices
builder.Services.AddScoped<CotizacionesServices>();
//La inyeccion del Bootstrap
builder.Services.AddBlazorBootstrap();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

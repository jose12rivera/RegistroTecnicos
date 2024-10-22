using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.Models;

namespace RegistroTecnicos.DAL;
public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options)
        : base(options) { }
    public DbSet<Tecnicos> Tecnicos { get; set; }
    public DbSet<TiposTecnicos> TiposTecnicos { get; set; }
    public DbSet<Clientes> Clientes { get; set; }
    public DbSet<Trabajos> Trabajos { get; set; }
    public DbSet<Prioridades> Prioridades { get; set; }
    public DbSet<Articulos> Articulos { get; set; }
    public DbSet<TrabajosDetalle> TrabajosDetalle { get; set; }
    public  DbSet<Cotizaciones> Cotizaciones { get; set; }
    public DbSet<CotizacionesDetalle> CotizacionesDetalle { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Articulos>().HasData(new List<Articulos>()
        {
        new Articulos() { ArticuloId = 1, Descripcion = "Mouse", Costo = 100, Precio = 150, Existencia = 50 },
        new Articulos() { ArticuloId = 2, Descripcion = "Teclado", Costo = 80, Precio = 120, Existencia = 40 },
        new Articulos() { ArticuloId = 3, Descripcion = "Monitor", Costo = 200, Precio = 300, Existencia = 20 },
        new Articulos() { ArticuloId = 4, Descripcion = "Impresora", Costo = 250, Precio = 400, Existencia = 15 },
        new Articulos() { ArticuloId = 5, Descripcion = "Webcam", Costo = 50, Precio = 90, Existencia = 25 },
        new Articulos() { ArticuloId = 6, Descripcion = "Pendrive", Costo = 15, Precio = 30, Existencia = 70 },
        new Articulos() { ArticuloId = 7, Descripcion = "Cable HDMI", Costo = 10, Precio = 20, Existencia = 60 },
        new Articulos() { ArticuloId = 8, Descripcion = "Disco Duro Externo", Costo = 100, Precio = 180, Existencia = 30 },
        new Articulos() { ArticuloId = 9, Descripcion = "Router", Costo = 60, Precio = 110, Existencia = 25 },
        new Articulos() { ArticuloId = 10, Descripcion = "Altavoces", Costo = 50, Precio = 90, Existencia = 40 },
        new Articulos() { ArticuloId = 11, Descripcion = "Tarjeta Gráfica", Costo = 300, Precio = 500, Existencia = 10 },
        new Articulos() { ArticuloId = 12, Descripcion = "Laptop", Costo = 800, Precio = 1200, Existencia = 8 },
        new Articulos() { ArticuloId = 13, Descripcion = "Smartphone", Costo = 300, Precio = 500, Existencia = 15 },
        new Articulos() { ArticuloId = 14, Descripcion = "Smartwatch", Costo = 100, Precio = 150, Existencia = 20 },
        new Articulos() { ArticuloId = 15, Descripcion = "Tableta", Costo = 200, Precio = 300, Existencia = 18 }
       });
    }

}


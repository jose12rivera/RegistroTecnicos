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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Articulos>().HasData(new List<Articulos>()
        {
        new Articulos() {ArticuloId = 1, Descripcion = "Refresco", Costo = 15, Precio = 25, Existencia = 24},
        new Articulos() {ArticuloId = 2, Descripcion = "Galletas", Costo = 10, Precio = 20, Existencia = 50},
        new Articulos() {ArticuloId = 3, Descripcion = "Café", Costo = 30, Precio = 45, Existencia = 40},
        new Articulos() {ArticuloId = 4, Descripcion = "Leche", Costo = 20, Precio = 35, Existencia = 60},
        new Articulos() {ArticuloId = 5, Descripcion = "Azúcar", Costo = 8, Precio = 15, Existencia = 100},
        new Articulos() {ArticuloId = 6, Descripcion = "Pan", Costo = 5, Precio = 10, Existencia = 80},
        new Articulos() {ArticuloId = 7, Descripcion = "Jugo de naranja", Costo = 18, Precio = 30, Existencia = 30},
        new Articulos() {ArticuloId = 8, Descripcion = "Cereal", Costo = 25, Precio = 40, Existencia = 45}
        });
    }


}


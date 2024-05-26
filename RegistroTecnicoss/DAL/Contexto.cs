using Microsoft.EntityFrameworkCore;
using RegistroTecnicoss.Modelss;


namespace RegistroTecnicoss.DAL
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options)
            : base(options) { }

       

        public DbSet<Tecnicos> Tecnicos { get; set; }
        public DbSet< TiposTecnicos> TipoTecnico { get; set; }
        public DbSet <IncentivosTecnicos> IncentivosTecnicos { get;set; }
    }
}

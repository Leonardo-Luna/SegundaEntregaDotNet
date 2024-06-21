using Microsoft.EntityFrameworkCore;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion;
namespace SGE.Repositorios;

public class DatosContext : DbContext
{

    public DbSet<Usuario> Usuarios {get; set;}
    public DbSet<Expediente> Expedientes {get; set;}
    public DbSet<Tramite> Tramites {get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("data source=Datos.sqlite");
    }
    
}
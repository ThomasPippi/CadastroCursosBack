using CadastroCursos.DataModels;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using ConfigurationManager = System.Configuration.ConfigurationManager;

namespace CadastroCursos
{
    public class Contexto : DbContext
    {
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        public Contexto()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("User ID=postgres;Password=91504759;Host=localhost;Port=5432;Database=CadastroCursos;Pooling=true;");
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["EntityPostgresql"];
            string retorno = "";

            if(settings != null)
                retorno = settings.ConnectionString;

            optionsBuilder.UseNpgsql(retorno);
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Curso>()
                .HasOne(e => e.endereco);
        }
    }
}

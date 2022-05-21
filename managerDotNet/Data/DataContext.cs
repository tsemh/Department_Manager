using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TestWebAPI.models;

namespace TestWebAPI.Data
{
  public class DataContext : DbContext
  {  
     public DataContext(DbContextOptions<DataContext> options) : base (options) { }        
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Departamento>()
                .HasData(new List<Departamento>(){
                    new Departamento(1, "Marketing", "M"),
                    new Departamento(2, "Financeiro", "F"),
                    new Departamento(3, "Logistica", "L"),
                    new Departamento(4, "Informática", "I"),
                    new Departamento(5, "Recursos Humanos", "RH"),
                });
            
            builder.Entity<Funcionario>()
                .HasData(new List<Funcionario>{
                    new Funcionario(1, "Erica", "Foto", "23.024.232-7", 1),
                    new Funcionario(2, "Fernando", "Foto", "45.737.728-8", 2),
                    new Funcionario(3, "Moises", "Foto", "48.843.809-3", 3),
                    new Funcionario(4, "Alisson", "Foto", "39.428.265-6", 4),
                    new Funcionario(5, "Maicon", "Foto", "39.428.265-6", 5),
                    new Funcionario(6, "Isaya", "Foto", "45.431.451-6", 4)
                });            
        }
  }
}
using CrudApiBackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudApi.Models
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Pessoa> Pessoa { get; set; }

        public virtual DbSet<Tarefa> Tarefas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pessoa>(entity =>
            {
                entity.HasKey(e => e.PessoaId);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Endereco).HasMaxLength(100);
                entity.Property(e => e.Numero).HasMaxLength(100);
                entity.Property(e => e.Cep).HasMaxLength(9);
                entity.Property(e => e.Uf).HasMaxLength(2); 
                entity.Property(e => e.Cidade).HasMaxLength(100); 
                entity.Property(e => e.Sexo).HasMaxLength(100); 

            });

            modelBuilder.Entity<Tarefa>(entity =>
            {
                entity.HasKey(e => e.TarefaId);

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Descricao).HasMaxLength(200);

            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }

}

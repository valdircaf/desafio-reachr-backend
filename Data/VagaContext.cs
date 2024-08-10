using api.Model;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class VagaContext : DbContext
    {
        public VagaContext(DbContextOptions<VagaContext> options) : base(options)
        {
        }

        public DbSet<Vagas> Vagas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var vaga = modelBuilder.Entity<Vagas>();
            vaga.HasKey(x => x.Id);
            vaga.ToTable("tb_vaga");
            // vaga.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
        }
    }
}
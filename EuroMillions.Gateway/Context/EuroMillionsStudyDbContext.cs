using EuroMillions.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace EuroMillions.API.Context;

public partial class EuroMillionsStudyDbContext : DbContext
{
    public EuroMillionsStudyDbContext()
    {
    }

    public EuroMillionsStudyDbContext(DbContextOptions<EuroMillionsStudyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<t_Draw?> t_Draws { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb3_general_ci")
            .HasCharSet("utf8mb3");

        modelBuilder.Entity<t_Draw>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable(tb => tb.HasComment("Table des resultats"));
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

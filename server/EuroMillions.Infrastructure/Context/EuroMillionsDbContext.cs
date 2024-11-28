using EuroMillions.Infrastructure.Entities;

using Microsoft.EntityFrameworkCore;

namespace EuroMillions.Infrastructure.Context;

public partial class EuroMillionsDbContext : DbContext
{
    public EuroMillionsDbContext()
    {
    }

    public EuroMillionsDbContext(DbContextOptions<EuroMillionsDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<T_DRAW> T_DRAWs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<T_DRAW>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PRIMARY");
            entity.Property(e => e.ID).ValueGeneratedOnAdd();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

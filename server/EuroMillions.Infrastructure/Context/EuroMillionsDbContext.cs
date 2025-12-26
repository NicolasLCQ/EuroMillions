using EuroMillions.Infrastructure.Entities;

using Microsoft.EntityFrameworkCore;

namespace EuroMillions.Infrastructure.Context;

public partial class EuroMillionsDbContext : DbContext
{
    public EuroMillionsDbContext() {}

    public EuroMillionsDbContext(DbContextOptions<EuroMillionsDbContext> options)
        : base(options) {}

    public virtual DbSet<T_DRAW> T_DRAWs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<T_DRAW>(entity =>
            {
                entity.ToTable("T_DRAW");

                entity.HasIndex(e => e.YEAR_DRAW_NUMBER, "IX_T_DRAW_YEAR_DRAW_NUMBER").IsUnique();

                entity.Property(e => e.BALL_FIVE).HasColumnType("INT");
                entity.Property(e => e.BALL_FOUR).HasColumnType("INT");
                entity.Property(e => e.BALL_ONE).HasColumnType("INT");
                entity.Property(e => e.BALL_THREE).HasColumnType("INT");
                entity.Property(e => e.BALL_TWO).HasColumnType("INT");
                entity.Property(e => e.DRAW_DATE).HasColumnType("DATETIME");
                entity.Property(e => e.STAR_ONE).HasColumnType("INT");
                entity.Property(e => e.STAR_TWO).HasColumnType("INT");
                entity.Property(e => e.YEAR_DRAW_NUMBER).HasColumnType("INT");
            }
        );

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

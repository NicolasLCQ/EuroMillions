using EuroMillions.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace EuroMillions.Infrastructure.Context;

public partial class EuroMillionsDbContext : DbContext
{
    public EuroMillionsDbContext(DbContextOptions<EuroMillionsDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<T_DRAW> T_DRAWs { get; set; }

    public virtual DbSet<T_DRAW_ADDITIONAL_GAME> T_DRAW_ADDITIONAL_GAMEs { get; set; }

    public virtual DbSet<T_DRAW_INFORMATION> T_DRAW_INFORMATIONs { get; set; }

    public virtual DbSet<T_DRAW_WINNER> T_DRAW_WINNERs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<T_DRAW>(entity =>
        {
            entity.ToTable("T_DRAW");

            entity.Property(e => e.BALL_FIVE).HasColumnType("INT");
            entity.Property(e => e.BALL_FOUR).HasColumnType("INT");
            entity.Property(e => e.BALL_ONE).HasColumnType("INT");
            entity.Property(e => e.BALL_THREE).HasColumnType("INT");
            entity.Property(e => e.BALL_TWO).HasColumnType("INT");
            entity.Property(e => e.STAR_ONE).HasColumnType("INT");
            entity.Property(e => e.STAR_TWO).HasColumnType("INT");
        });

        modelBuilder.Entity<T_DRAW_ADDITIONAL_GAME>(entity =>
        {
            entity.HasKey(e => e.DRAW_ID);

            entity.ToTable("T_DRAW_ADDITIONAL_GAME");

            entity.Property(e => e.DRAW_ID).ValueGeneratedNever();

            entity.HasOne(d => d.DRAW).WithOne(p => p.T_DRAW_ADDITIONAL_GAME).HasForeignKey<T_DRAW_ADDITIONAL_GAME>(d => d.DRAW_ID);
        });

        modelBuilder.Entity<T_DRAW_INFORMATION>(entity =>
        {
            entity.HasKey(e => e.DRAW_ID);

            entity.ToTable("T_DRAW_INFORMATION");

            entity.HasIndex(e => e.YEAR_DRAW_NUMBER, "IX_T_DRAW_INFORMATION_YEAR_DRAW_NUMBER").IsUnique();

            entity.Property(e => e.DRAW_ID).ValueGeneratedNever();
            entity.Property(e => e.DRAW_DATE).HasColumnType("DATETIME");
            entity.Property(e => e.DRAW_NUMBER_IN_CYCLE).HasColumnType("INT");
            entity.Property(e => e.FORCLUSION_DATE).HasColumnType("DATETIME");
            entity.Property(e => e.YEAR_DRAW_NUMBER).HasColumnType("INT");

            entity.HasOne(d => d.DRAW).WithOne(p => p.T_DRAW_INFORMATION).HasForeignKey<T_DRAW_INFORMATION>(d => d.DRAW_ID);
        });

        modelBuilder.Entity<T_DRAW_WINNER>(entity =>
        {
            entity.HasKey(e => e.DRAW_ID);

            entity.ToTable("T_DRAW_WINNER");

            entity.Property(e => e.DRAW_ID).ValueGeneratedNever();

            entity.HasOne(d => d.DRAW).WithOne(p => p.T_DRAW_WINNER).HasForeignKey<T_DRAW_WINNER>(d => d.DRAW_ID);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

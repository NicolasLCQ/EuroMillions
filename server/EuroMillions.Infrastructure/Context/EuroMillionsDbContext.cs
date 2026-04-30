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
    public virtual DbSet<T_DRAW_WINNER> T_DRAW_WINNERs { get; set; }
    public virtual DbSet<T_DRAW_INFORMATION> T_DRAW_INFORMATIONs { get; set; }
    public virtual DbSet<T_DRAW_ADDITIONAL_GAME> T_DRAW_ADDITIONAL_GAMEs { get; set; }

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
            entity.Property(e => e.WINNING_BALLS_IN_ASCENDING_ORDER).HasColumnType("TEXT");
            entity.Property(e => e.WINNING_STARS_IN_ASCENDING_ORDER).HasColumnType("TEXT");

            entity.HasOne(d => d.T_DRAW_WINNER)
                .WithOne(p => p.T_DRAW)
                .HasForeignKey<T_DRAW_WINNER>(p => p.DRAW_ID);

            entity.HasOne(d => d.T_DRAW_INFORMATION)
                .WithOne(p => p.T_DRAW)
                .HasForeignKey<T_DRAW_INFORMATION>(p => p.DRAW_ID);

            entity.HasOne(d => d.T_DRAW_ADDITIONAL_GAME)
                .WithOne(p => p.T_DRAW)
                .HasForeignKey<T_DRAW_ADDITIONAL_GAME>(p => p.DRAW_ID);
        });

        modelBuilder.Entity<T_DRAW_WINNER>(entity =>
        {
            entity.ToTable("T_DRAW_WINNER");

            entity.HasKey(e => e.DRAW_ID);
            entity.Property(e => e.DRAW_ID).HasColumnType("INT");
        });

        modelBuilder.Entity<T_DRAW_INFORMATION>(entity =>
        {
            entity.ToTable("T_DRAW_INFORMATION");

            entity.HasKey(e => e.DRAW_ID);
            entity.HasIndex(e => e.YEAR_DRAW_NUMBER, "IX_T_DRAW_INFORMATION_YEAR_DRAW_NUMBER").IsUnique();
            entity.Property(e => e.DRAW_ID).HasColumnType("INT");
            entity.Property(e => e.YEAR_DRAW_NUMBER).HasColumnType("INT");
            entity.Property(e => e.DRAW_DATE).HasColumnType("DATETIME");
            entity.Property(e => e.DRAW_NUMBER_IN_CYCLE).HasColumnType("INT");
            entity.Property(e => e.FORCLUSION_DATE).HasColumnType("DATETIME");

        });

        modelBuilder.Entity<T_DRAW_ADDITIONAL_GAME>(entity =>
        {
            entity.ToTable("T_DRAW_ADDITIONAL_GAME");

            entity.HasKey(e => e.DRAW_ID);
            entity.Property(e => e.DRAW_ID).HasColumnType("INT");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

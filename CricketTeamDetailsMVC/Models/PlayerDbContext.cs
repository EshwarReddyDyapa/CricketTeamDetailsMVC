using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CricketTeamDetailsMVC.Models;

public partial class PlayerDbContext : DbContext
{
    public PlayerDbContext()
    {
    }

    public PlayerDbContext(DbContextOptions<PlayerDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Player> Players { get; set; }

    public virtual DbSet<PlayerDetail> PlayerDetails { get; set; }

    public DbSet<SpResult> spResults { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionString:PlayerDB");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Player>(entity =>
        {
            entity.HasKey(e => e.PlayerId).HasName("PK__Player__2CDA01F17B4F71CA");

            entity.ToTable("Player");

            entity.Property(e => e.PlayerId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("playerId");
            entity.Property(e => e.PlayerName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("playerName");
            entity.Property(e => e.PlayerRole)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("playerRole");
        });

        modelBuilder.Entity<PlayerDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PlayerDe__3214EC072C6D456B");

            entity.Property(e => e.PlayerHeight)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("playerHeight");
            entity.Property(e => e.PlayerId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("playerId");
            entity.Property(e => e.PlayerLocality)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("playerLocality");
            entity.Property(e => e.PlayerSalary)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("playerSalary");

            entity.HasOne(d => d.Player).WithMany(p => p.PlayerDetails)
                .HasForeignKey(d => d.PlayerId)
                .HasConstraintName("FK__PlayerDet__playe__4BAC3F29");
        });

        OnModelCreatingPartial(modelBuilder);

        //modelBuilder.Entity<SpResult>().HasNoKey().ToView(null);
        /*modelBuilder.Entity<SpResult>(entity =>
        {
            entity.HasKey(e => e.PlayerId);
            entity.ToView(null); // This specifies that the entity does not map to a specific table
        });*/
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

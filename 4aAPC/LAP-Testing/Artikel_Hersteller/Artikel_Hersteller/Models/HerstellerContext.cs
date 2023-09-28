using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Artikel_Hersteller.Models;

public partial class HerstellerContext : DbContext
{
    public HerstellerContext()
    {
    }

    public HerstellerContext(DbContextOptions<HerstellerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Artikel> Artikels { get; set; }

    public virtual DbSet<Hersteller> Herstellers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql("server=localhost;port=3306;database=Hersteller;uid=root;pwd=Test1234", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.24-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8_general_ci")
            .HasCharSet("utf8");

        modelBuilder.Entity<Artikel>(entity =>
        {
            entity.HasKey(e => e.ArtId).HasName("PRIMARY");

            entity.ToTable("artikel");

            entity.Property(e => e.ArtId)
                .HasColumnType("int(11)")
                .HasColumnName("art_id");
            entity.Property(e => e.ArtName)
                .HasMaxLength(45)
                .HasColumnName("art_name");

            entity.HasMany(d => d.Hers).WithMany(p => p.Arts)
                .UsingEntity<Dictionary<string, object>>(
                    "ArtikelHasHersteller",
                    r => r.HasOne<Hersteller>().WithMany()
                        .HasForeignKey("HerId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_artikel_has_hersteller_hersteller1"),
                    l => l.HasOne<Artikel>().WithMany()
                        .HasForeignKey("ArtId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_artikel_has_hersteller_artikel"),
                    j =>
                    {
                        j.HasKey("ArtId", "HerId")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("artikel_has_hersteller");
                        j.HasIndex(new[] { "ArtId" }, "fk_artikel_has_hersteller_artikel_idx");
                        j.HasIndex(new[] { "HerId" }, "fk_artikel_has_hersteller_hersteller1_idx");
                        j.IndexerProperty<int>("ArtId")
                            .HasColumnType("int(11)")
                            .HasColumnName("art_id");
                        j.IndexerProperty<int>("HerId")
                            .HasColumnType("int(11)")
                            .HasColumnName("her_id");
                    });
        });

        modelBuilder.Entity<Hersteller>(entity =>
        {
            entity.HasKey(e => e.HerId).HasName("PRIMARY");

            entity.ToTable("hersteller");

            entity.Property(e => e.HerId)
                .HasColumnType("int(11)")
                .HasColumnName("her_id");
            entity.Property(e => e.HerName)
                .HasMaxLength(45)
                .HasColumnName("her_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

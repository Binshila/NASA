using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NASAWebApp.AppModels;

public partial class NasaContext : DbContext
{
    public NasaContext()
    {
    }

    public NasaContext(DbContextOptions<NasaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<SearchHistory> SearchHistories { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:ConStr");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SearchHistory>(entity =>
        {
            entity.HasKey(e => e.SearchId).HasName("PK__SearchHi__21C535F49C4AE6F3");

            entity.Property(e => e.SearchDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.SearchTerm).HasMaxLength(255);

            entity.HasOne(d => d.User).WithMany(p => p.SearchHistories)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__SearchHis__UserI__3C69FB99");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4CEA77E32B");

            entity.HasIndex(e => e.Email, "UQ__Users__A9D10534AC9D0894").IsUnique();

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FullName).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

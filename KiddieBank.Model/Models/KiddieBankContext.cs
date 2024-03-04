using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace KiddieBank.Model.Models;

public partial class KiddieBankContext : DbContext
{
    public KiddieBankContext()
    {
    }

    public KiddieBankContext(DbContextOptions<KiddieBankContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<Type> Types { get; set; }

    public virtual DbSet<User> Users { get; set; }

    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
    //        => optionsBuilder.UseSqlServer("Integrated Security=SSPI;Initial Catalog=KiddieBank;Data Source=DESKTOP-5S6EPEU\\ERNAN;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.Property(e => e.Note).HasMaxLength(250);

            entity.HasOne(d => d.TypeNavigation).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.Type)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Transactions_Types");

            entity.HasOne(d => d.User).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_Transactions");
        });

        modelBuilder.Entity<Type>(entity =>
        {
            entity.Property(e => e.Type1)
                .HasMaxLength(50)
                .HasColumnName("Type");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

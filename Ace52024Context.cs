using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BankScaffold.Models;

public partial class Ace52024Context : DbContext
{
    public Ace52024Context()
    {
    }

    public Ace52024Context(DbContextOptions<Ace52024Context> options)
        : base(options)
    {
    }

   
    public virtual DbSet<SandhyaSbtransaction> SandhyaSbtransactions { get; set; }

    public virtual DbSet<SandhyasSbaccount> SandhyasSbaccounts { get; set; }

   

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DEVSQL.Corp.local;Database=ACE 5- 2024;Trusted_Connection=True;encrypt=false;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       
        modelBuilder.Entity<SandhyaSbtransaction>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PK_SandhyaSBTransaction_Transactionid");

            entity.ToTable("SandhyaSBTransaction");

            entity.Property(e => e.TransactionId).ValueGeneratedNever();
            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TransactionType)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.AccountNumberNavigation).WithMany(p => p.SandhyaSbtransactions)
                .HasForeignKey(d => d.AccountNumber)
                .HasConstraintName("FK_SBTransaction_SandhyasSBAccount");
        });

        modelBuilder.Entity<SandhyasSbaccount>(entity =>
        {
            entity.HasKey(e => e.AccountNumber).HasName("PK_SandhyasSBAccount_Accountnumber");

            entity.ToTable("SandhyasSBAccount");

            entity.Property(e => e.AccountNumber).ValueGeneratedNever();
            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CurrentBalance).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CustomerAddress)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CustomerName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Computer_Management.Models
{
    public partial class CMContext : DbContext
    {
        public CMContext()
        {
        }

        public CMContext(DbContextOptions<CMContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Computer> Computers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=PC\\SQLEXPRESS;Initial Catalog=CM;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Computer>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ComputerGroup)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ComputerIp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ComputerIP");

                entity.Property(e => e.ComputerLocation)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ComputerMac)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ComputerMAC");

                entity.Property(e => e.ComputerModel)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ComputerName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

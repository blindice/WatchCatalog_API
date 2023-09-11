using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WatchCatalog_API.Model;

namespace WatchCatalog_API.Context
{
    public partial class WatchContext : DbContext
    {
        public virtual DbSet<tbl_watch> tbl_watches { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("name=Default");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tbl_watch>(entity =>
            {
                entity.HasKey(e => e.WatchId)
                    .HasName("PK__tbl_watc__3BA3DAA3319953BA");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

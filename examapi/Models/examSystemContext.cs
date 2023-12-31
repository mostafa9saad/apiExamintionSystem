﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace examapi.Models
{
    public partial class examSystemContext : DbContext
    {
        public examSystemContext()
        {
        }

        public examSystemContext(DbContextOptions<examSystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Answers> Answers { get; set; }
        public virtual DbSet<Exam> Exam { get; set; }
        public virtual DbSet<Questions> Questions { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Test> Test { get; set; }

        //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //        {
        //            if (!optionsBuilder.IsConfigured)
        //            {
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        //                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=examSystem;Integrated Security=True");
        //            }
        //        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answers>(entity =>
            {
                entity.HasOne(d => d.Qes)
                    .WithMany(p => p.Answers)
                    .HasForeignKey(d => d.QesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("c5");
            });

            modelBuilder.Entity<Exam>(entity =>
            {
                entity.HasKey(e => new { e.StdId, e.TestId })
                    .HasName("c2");

                entity.HasOne(d => d.Std)
                    .WithMany(p => p.Exam)
                    .HasForeignKey(d => d.StdId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("c1");

                entity.HasOne(d => d.Test)
                    .WithMany(p => p.Exam)
                    .HasForeignKey(d => d.TestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("c3");
            });

            modelBuilder.Entity<Questions>(entity =>
            {
                entity.HasOne(d => d.Test)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.TestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("c6");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
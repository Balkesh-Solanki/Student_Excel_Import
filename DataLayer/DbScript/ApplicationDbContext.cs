using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace Student_Excel_Data_Import_API.DataLayer.Entities;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Studentdatum> Studentdata { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=ExcelImportDB;user=root;password=Test@123", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.41-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Studentdatum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("studentdata");

            entity.Property(e => e.BalanceReference).HasMaxLength(50);
            entity.Property(e => e.CourseName).HasMaxLength(255);
            entity.Property(e => e.CourseType).HasMaxLength(100);
            entity.Property(e => e.Dob).HasColumnName("DOB");
            entity.Property(e => e.InvoiceNo).HasMaxLength(50);
            entity.Property(e => e.Notes).HasColumnType("text");
            entity.Property(e => e.StudentFees).HasPrecision(10, 2);
            entity.Property(e => e.StudentHourlyRate).HasPrecision(10, 2);
            entity.Property(e => e.StudentName).HasMaxLength(255);
            entity.Property(e => e.StudentStatus).HasMaxLength(50);
            entity.Property(e => e.Subject).HasMaxLength(255);
            entity.Property(e => e.TutorCharge).HasPrecision(10, 2);
            entity.Property(e => e.TutorHourlyRate).HasPrecision(10, 2);
            entity.Property(e => e.TutorName).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

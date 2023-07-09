using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace StudentDatabaseWEBAPI.Models;

public partial class StudentDetailReportContext : DbContext
{
    public StudentDetailReportContext()
    {
    }

    public StudentDetailReportContext(DbContextOptions<StudentDetailReportContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AddressTable> AddressTables { get; set; }

    public virtual DbSet<CountryMaster> CountryMasters { get; set; }

    public virtual DbSet<DistrictMaster> DistrictMasters { get; set; }

    public virtual DbSet<StateMaster> StateMasters { get; set; }

    public virtual DbSet<StudentDetail> StudentDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=BMT-LAP-219;Initial Catalog=StudentDetailReport;Integrated Security = True; Trusted_Connection=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AddressTable>(entity =>
        {
            entity.HasKey(e => e.AddressId).HasName("PK__AddressT__091C2A1B69060316");

            entity.ToTable("AddressTable");

            entity.Property(e => e.AddressId).HasColumnName("AddressID");
            entity.Property(e => e.AddressLine1).HasMaxLength(255);
            entity.Property(e => e.AddressLine2).HasMaxLength(255);
            entity.Property(e => e.City).HasMaxLength(255);
            entity.Property(e => e.CountryId).HasColumnName("CountryID");
            entity.Property(e => e.DistrictId).HasColumnName("DistrictID");
            entity.Property(e => e.StateId).HasColumnName("StateID");
            entity.Property(e => e.StudentId).HasColumnName("StudentID");
        });

        modelBuilder.Entity<CountryMaster>(entity =>
        {
            entity.HasKey(e => e.CountryId).HasName("PK__CountryM__10D160BF9B457C53");

            entity.ToTable("CountryMaster");

            entity.Property(e => e.CountryId)
                .ValueGeneratedNever()
                .HasColumnName("CountryID");
            entity.Property(e => e.CountryName).HasMaxLength(255);
        });

        modelBuilder.Entity<DistrictMaster>(entity =>
        {
            entity.HasKey(e => e.DistrictId).HasName("PK__District__85FDA4A6963505A9");

            entity.ToTable("DistrictMaster");

            entity.Property(e => e.DistrictId)
                .ValueGeneratedNever()
                .HasColumnName("DistrictID");
            entity.Property(e => e.DistrictName).HasMaxLength(255);
            entity.Property(e => e.StateId).HasColumnName("StateID");
        });

        modelBuilder.Entity<StateMaster>(entity =>
        {
            entity.HasKey(e => e.StateId).HasName("PK__StateMas__C3BA3B5AD894886D");

            entity.ToTable("StateMaster");

            entity.Property(e => e.StateId)
                .ValueGeneratedNever()
                .HasColumnName("StateID");
            entity.Property(e => e.CountryId).HasColumnName("CountryID");
            entity.Property(e => e.StateName).HasMaxLength(255);
        });

        modelBuilder.Entity<StudentDetail>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__StudentD__32C52A7948BEF10A");

            entity.Property(e => e.StudentId).HasColumnName("StudentID");
            entity.Property(e => e.DateofBirth).HasColumnType("date");
            entity.Property(e => e.EmailId)
                .HasMaxLength(255)
                .HasColumnName("EmailID");
            entity.Property(e => e.FatherName).HasMaxLength(255);
            entity.Property(e => e.FirstName).HasMaxLength(255);
            entity.Property(e => e.LastName).HasMaxLength(255);
            entity.Property(e => e.MotherName).HasMaxLength(255);
            entity.Property(e => e.ProfilePicture).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PersonnelDepartmentAPI;

public partial class DepartmentPersonnelContext : DbContext
{
    public DepartmentPersonnelContext()
    {
    }

    public DepartmentPersonnelContext(DbContextOptions<DepartmentPersonnelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<InfoWorker> InfoWorkers { get; set; }

    public virtual DbSet<Omission> Omissions { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Sick> Sicks { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Vacation> Vacations { get; set; }

    public virtual DbSet<Worker> Workers { get; set; }

    public virtual DbSet<Working> Workings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-G4Q8TTS;DataBase=DepartmentPersonnel;Trusted_Connection=True;Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<InfoWorker>(entity =>
        {
            entity.HasKey(e => e.IdWorker);

            entity.ToTable("InfoWorker");

            entity.Property(e => e.IdWorker).ValueGeneratedNever();
            entity.Property(e => e.Education).HasMaxLength(50);
            entity.Property(e => e.Inn)
                .HasMaxLength(50)
                .HasColumnName("INN");
            entity.Property(e => e.NumberPassport).HasMaxLength(50);
            entity.Property(e => e.NumberPhone).HasMaxLength(50);
            entity.Property(e => e.SeriesPassport).HasMaxLength(50);
            entity.Property(e => e.Snils)
                .HasMaxLength(50)
                .HasColumnName("SNILS");

            entity.HasOne(d => d.IdWorkerNavigation).WithOne(p => p.InfoWorker)
                .HasForeignKey<InfoWorker>(d => d.IdWorker)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InfoWorker_Worker");
        });

        modelBuilder.Entity<Omission>(entity =>
        {
            entity.ToTable("Omission");

            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.Description).HasMaxLength(50);

            entity.HasOne(d => d.IdWorkerNavigation).WithMany(p => p.Omissions)
                .HasForeignKey(d => d.IdWorker)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Omission_Worker");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.ToTable("Post");

            entity.Property(e => e.Salary).HasColumnType("money");
            entity.Property(e => e.Title).HasMaxLength(50);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Role");

            entity.Property(e => e.RoleTitle).HasMaxLength(50);
        });

        modelBuilder.Entity<Sick>(entity =>
        {
            entity.ToTable("Sick");

            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.Description).HasMaxLength(50);

            entity.HasOne(d => d.IdWorkerNavigation).WithMany(p => p.Sicks)
                .HasForeignKey(d => d.IdWorker)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sick_Worker");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.Login).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
        });

        modelBuilder.Entity<Vacation>(entity =>
        {
            entity.ToTable("Vacation");

            entity.Property(e => e.Date).HasColumnType("date");

            entity.HasOne(d => d.IdWorkerNavigation).WithMany(p => p.Vacations)
                .HasForeignKey(d => d.IdWorker)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Vacation_Worker");
        });

        modelBuilder.Entity<Worker>(entity =>
        {
            entity.ToTable("Worker");

            entity.Property(e => e.Birthday).HasColumnType("date");
            entity.Property(e => e.FamilyStatus).HasMaxLength(50);
            entity.Property(e => e.Gender).HasMaxLength(50);
            entity.Property(e => e.Image).HasColumnType("image");
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Patronymic).HasMaxLength(50);

            entity.HasOne(d => d.IdDirectorNavigation).WithMany(p => p.InverseIdDirectorNavigation)
                .HasForeignKey(d => d.IdDirector)
                .HasConstraintName("FK_Worker_Worker1");

            entity.HasOne(d => d.IdPostNavigation).WithMany(p => p.Workers)
                .HasForeignKey(d => d.IdPost)
                .HasConstraintName("FK_Worker_Post");

            entity.HasOne(d => d.IdRoleNavigation).WithMany(p => p.Workers)
                .HasForeignKey(d => d.IdRole)
                .HasConstraintName("FK_Worker_Role");
        });

        modelBuilder.Entity<Working>(entity =>
        {
            entity.ToTable("Working");

            entity.Property(e => e.Date).HasColumnType("date");

            entity.HasOne(d => d.IdWorkerNavigation).WithMany(p => p.Workings)
                .HasForeignKey(d => d.IdWorker)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Working_Worker");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

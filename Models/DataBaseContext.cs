using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BookingMeeting.Models;

public partial class DataBaseContext : DbContext
{
    public DataBaseContext()
    {
    }

    public DataBaseContext(DbContextOptions<DataBaseContext> options)
        : base(options)
    {
    }

    public static DbSet<Company> Companies { get; set; }

    public static DbSet<Meeting> Meetings { get; set; }

    public static DbSet<Room> Rooms { get; set; }

    public static DbSet<SystemUser> SystemUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-G3APRI2\\SQLEXPRESS;Database=DataBase;Trusted_Connection=True;Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.CompanyId).HasName("PK__Company__2D971C4CE4F4E7C7");

            entity.ToTable("Company");

            entity.Property(e => e.CompanyId)
                .ValueGeneratedNever()
                .HasColumnName("CompanyID");
            entity.Property(e => e.CompanyDescription)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.CompanyLogo).HasColumnType("image");
            entity.Property(e => e.CompanyName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CompayEmail)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<Meeting>(entity =>
        {
            entity.HasKey(e => e.ReservationId).HasName("PK__Meeting__B7EE5F04AE3789B8");

            entity.ToTable("Meeting");

            entity.Property(e => e.ReservationId)
                .ValueGeneratedNever()
                .HasColumnName("ReservationID");
            entity.Property(e => e.EndTime).HasColumnType("datetime");
            entity.Property(e => e.MeetingManagerId).HasColumnName("MeetingManagerID");
            entity.Property(e => e.StartTime).HasColumnType("datetime");

            entity.HasOne(d => d.MeetingManager).WithMany(p => p.Meetings)
                .HasForeignKey(d => d.MeetingManagerId)
                .HasConstraintName("FK__Meeting__Meeting__4222D4EF");

            entity.HasOne(d => d.RelatedRoomNavigation).WithMany(p => p.Meetings)
                .HasForeignKey(d => d.RelatedRoom)
                .HasConstraintName("FK__Meeting__Related__412EB0B6");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.RoomId).HasName("PK__Room__3286391927287A38");

            entity.ToTable("Room");

            entity.Property(e => e.RoomId)
                .ValueGeneratedNever()
                .HasColumnName("RoomID");
            entity.Property(e => e.RoomDescription)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.RoomLocation)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.RelatedCompanyNavigation).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.RelatedCompany)
                .HasConstraintName("FK__Room__RelatedCom__3E52440B");
        });

        modelBuilder.Entity<SystemUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SystemUs__3214EC271E2F56B7");

            entity.ToTable("SystemUser");

            entity.HasIndex(e => e.Password, "UQ__SystemUs__87909B1579AA446B").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Birth).HasColumnType("date");
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(11)
                .IsUnicode(false);
            entity.Property(e => e.Role)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.Company).WithMany(p => p.SystemUsers)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK__SystemUse__Compa__4316F928");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

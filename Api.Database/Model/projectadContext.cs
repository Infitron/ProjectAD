using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Api.Database.Model
{
    public partial class projectadContext : DbContext
    {
        public projectadContext()
        {
        }

        public projectadContext(DbContextOptions<projectadContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ArtisanCategories> ArtisanCategories { get; set; }
        public virtual DbSet<Booking> Booking { get; set; }
        public virtual DbSet<PaymentHistory> PaymentHistory { get; set; }
        public virtual DbSet<Projects> Projects { get; set; }
        public virtual DbSet<Rating> Rating { get; set; }
        public virtual DbSet<Registration> Registration { get; set; }
        public virtual DbSet<UserLogin> UserLogin { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("server=103.108.220.238;database=projectad;user id=dbAd; password=8Y#3iDY:8wCcf8");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:DefaultSchema", "dbAd");

            modelBuilder.Entity<ArtisanCategories>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CategoryDescr)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.ArtisanEmail)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Messages)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MsgDate).HasColumnType("date");

                entity.Property(e => e.UserEmail)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.HasOne(d => d.UserEmailNavigation)
                    .WithMany(p => p.Booking)
                    .HasForeignKey(d => d.UserEmail)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Booking_fk0");
            });

            modelBuilder.Entity<PaymentHistory>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AmountPaid).HasColumnType("money");

                entity.Property(e => e.ArtEmail)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.PayDate).HasColumnType("date");

                entity.Property(e => e.PaymentType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.Property(e => e.UserEmail)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.PaymentHistory)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PaymentHistory_fk0");
            });

            modelBuilder.Entity<Projects>(entity =>
            {
                entity.HasIndex(e => e.ProjectId)
                    .HasName("UQ__Projects__761ABED1A74DDF41")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ArtEmail)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.BookingId).HasColumnName("BookingID");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.Property(e => e.ProjectName)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectStatus)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.UserEmail)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.HasOne(d => d.ArtEmailNavigation)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.ArtEmail)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Projects_fk0");
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.ArtisanEmail)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.JobEndDate).HasColumnType("date");

                entity.Property(e => e.JobStartDate).HasColumnType("date");

                entity.Property(e => e.Rating1).HasColumnName("Rating");

                entity.Property(e => e.Remarks)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserEmail)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.HasOne(d => d.UserEmailNavigation)
                    .WithMany(p => p.Rating)
                    .HasForeignKey(d => d.UserEmail)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Rating_fk0");
            });

            modelBuilder.Entity<Registration>(entity =>
            {
                entity.HasKey(e => e.EmailAddress)
                    .HasName("PK_REGISTRATION");

                entity.HasIndex(e => e.IdcardNo)
                    .HasName("UQ__Registra__7EDFFE55B7CCCD10")
                    .IsUnique();

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.AreaLocation)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.ArtisanCategoryId).HasColumnName("ArtisanCategoryID");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.FullAddress)
                    .IsRequired()
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdcardNo)
                    .IsRequired()
                    .HasColumnName("IDCardNo")
                    .HasMaxLength(40)
                    .IsFixedLength();

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.Picture)
                    .IsRequired()
                    .HasColumnType("image");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.HasOne(d => d.ArtisanCategory)
                    .WithMany(p => p.Registration)
                    .HasForeignKey(d => d.ArtisanCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Registration_fk2");

                entity.HasOne(d => d.EmailAddressNavigation)
                    .WithOne(p => p.Registration)
                    .HasForeignKey<Registration>(d => d.EmailAddress)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Registration_fk0");

                entity.HasOne(d => d.UserTypeNavigation)
                    .WithMany(p => p.Registration)
                    .HasForeignKey(d => d.UserType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Registration_fk1");
            });

            modelBuilder.Entity<UserLogin>(entity =>
            {
                entity.HasKey(e => e.EmailAddress)
                    .HasName("PK_USERLOGIN");

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.CreationDate).HasColumnType("date");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasColumnName("RoleID")
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PK_USERROLE");

                entity.Property(e => e.RoleId)
                    .HasColumnName("RoleID")
                    .ValueGeneratedNever();

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

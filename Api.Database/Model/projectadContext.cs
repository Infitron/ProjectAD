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

        public virtual DbSet<Artisan> Artisan { get; set; }
        public virtual DbSet<ArtisanBankDetails> ArtisanBankDetails { get; set; }
        public virtual DbSet<ArtisanCategories> ArtisanCategories { get; set; }
        public virtual DbSet<ArtisanDashboard> ArtisanDashboard { get; set; }
        public virtual DbSet<Booking> Booking { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<PaymentHistory> PaymentHistory { get; set; }
        public virtual DbSet<Projects> Projects { get; set; }
        public virtual DbSet<Rating> Rating { get; set; }
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
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:DefaultSchema", "dbAd");

            modelBuilder.Entity<Artisan>(entity =>
            {
                entity.HasKey(e => e.EmailAddress)
                    .HasName("PK_ARTISAN");

                entity.HasIndex(e => e.IdcardNo)
                    .HasName("UQ__Artisan__7EDFFE556682FC51")
                    .IsUnique();

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

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

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.IdcardNo)
                    .IsRequired()
                    .HasColumnName("IDCardNo")
                    .HasMaxLength(40);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.PicturePath)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.HasOne(d => d.ArtisanCategory)
                    .WithMany(p => p.Artisan)
                    .HasForeignKey(d => d.ArtisanCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Artisan_Catg");
            });

            modelBuilder.Entity<ArtisanBankDetails>(entity =>
            {
                entity.HasKey(e => e.EmailAddress)
                    .HasName("PK_ARTISANBANKDETAILS");

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.AccountName)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.AccountNumber).HasColumnType("numeric(10, 0)");

                entity.Property(e => e.BankName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Bvn)
                    .HasColumnName("BVN")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.HasOne(d => d.EmailAddressNavigation)
                    .WithOne(p => p.ArtisanBankDetails)
                    .HasForeignKey<ArtisanBankDetails>(d => d.EmailAddress)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ArtisanBankDetails_Artisan");
            });

            modelBuilder.Entity<ArtisanCategories>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CategoryDescr)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ArtisanDashboard>(entity =>
            {
                entity.HasIndex(e => e.EmailAddress)
                    .HasName("UQ__ArtisanD__49A14740F9559EDF")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Comments)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreationDate).HasColumnType("date");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.EmailAddress)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.ProductImagePath)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.EmailAddressNavigation)
                    .WithOne(p => p.ArtisanDashboard)
                    .HasForeignKey<ArtisanDashboard>(d => d.EmailAddress)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ArtisanDashboard_Artisan");
            });

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ArtisanEmail)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.ClientEmail)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Messages)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MsgDate).HasColumnType("date");

                entity.HasOne(d => d.ArtisanEmailNavigation)
                    .WithMany(p => p.Booking)
                    .HasForeignKey(d => d.ArtisanEmail)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Booking_Artisan");

                entity.HasOne(d => d.ClientEmailNavigation)
                    .WithMany(p => p.Booking)
                    .HasForeignKey(d => d.ClientEmail)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Booking_Client");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.EmailAddress)
                    .HasName("PK_CLIENT");

                entity.HasIndex(e => e.IdcardNo)
                    .HasName("UQ__Client__7EDFFE55A80A881B")
                    .IsUnique();

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.IdcardNo)
                    .IsRequired()
                    .HasColumnName("IDCardNo")
                    .HasMaxLength(40);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.PicturePath)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(70)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PaymentHistory>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AmountPaid).HasColumnType("money");

                entity.Property(e => e.ArtisanEmail)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.ClientEmail)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.PayDate).HasColumnType("date");

                entity.Property(e => e.PaymentType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.HasOne(d => d.ArtisanEmailNavigation)
                    .WithMany(p => p.PaymentHistory)
                    .HasForeignKey(d => d.ArtisanEmail)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PH_Artisan");

                entity.HasOne(d => d.ClientEmailNavigation)
                    .WithMany(p => p.PaymentHistory)
                    .HasForeignKey(d => d.ClientEmail)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PH_Client");
            });

            modelBuilder.Entity<Projects>(entity =>
            {
                entity.Property(e => e.ArtisanEmail)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.BookingId).HasColumnName("BookingID");

                entity.Property(e => e.ClientEmail)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.ProjectName)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectStatus)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.ArtisanEmailNavigation)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.ArtisanEmail)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Projects_Artisan");

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.BookingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Projects_Booking");

                entity.HasOne(d => d.ClientEmailNavigation)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.ClientEmail)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Projects_Client");
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ArtisanEmail)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.ClientEmail)
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

                entity.HasOne(d => d.ArtisanEmailNavigation)
                    .WithMany(p => p.Rating)
                    .HasForeignKey(d => d.ArtisanEmail)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rating_Artisan");

                entity.HasOne(d => d.ClientEmailNavigation)
                    .WithMany(p => p.Rating)
                    .HasForeignKey(d => d.ClientEmail)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rating_Client");
            });

            modelBuilder.Entity<UserLogin>(entity =>
            {
                entity.HasKey(e => e.EmailAddress)
                    .HasName("PK_USERLOGIN");

                entity.HasIndex(e => e.UserName)
                    .HasName("UQ__UserLogi__C9F284568AF4CB29")
                    .IsUnique();

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CreationDate).HasColumnType("date");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserLogin)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("UserLogin_fk0");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PK_USERROLE");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });
        }
    }
}

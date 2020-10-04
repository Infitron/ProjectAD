using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Api.Database.Model;

namespace Api.Database.Data
{
    public partial class bluechub_ProjectADContext : DbContext
    {
        public bluechub_ProjectADContext()
        {
        }

        public bluechub_ProjectADContext(DbContextOptions<bluechub_ProjectADContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Article> Article { get; set; }
        public virtual DbSet<Artisan> Artisan { get; set; }
        public virtual DbSet<ArtisanCategories> ArtisanCategories { get; set; }
        public virtual DbSet<ArtisanServices> ArtisanServices { get; set; }
        public virtual DbSet<ArtisanSubCategory> ArtisanSubCategory { get; set; }
        public virtual DbSet<AuditTrail> AuditTrail { get; set; }
        public virtual DbSet<BankCodeLov> BankCodeLov { get; set; }
        public virtual DbSet<BankDetails> BankDetails { get; set; }
        public virtual DbSet<Booking> Booking { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Complaint> Complaint { get; set; }
        public virtual DbSet<Gallary> Gallary { get; set; }
        public virtual DbSet<Lga> Lga { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<Lov> Lov { get; set; }
        public virtual DbSet<PaymentHistory> PaymentHistory { get; set; }
        public virtual DbSet<Projects> Projects { get; set; }
        public virtual DbSet<Quote> Quote { get; set; }
        public virtual DbSet<Rating> Rating { get; set; }
        public virtual DbSet<Services> Services { get; set; }
        public virtual DbSet<State> State { get; set; }
        public virtual DbSet<UserLogin> UserLogin { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("server=192.185.11.167;database=bluechub_ProjectAD;user id=bluechub_dbAd; password=Ux8qz1*2");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:DefaultSchema", "bluechub_dbAd");

            modelBuilder.Entity<Article>(entity =>
            {
                entity.ToTable("Article", "dbo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ApprovalStatusId).HasColumnName("ApprovalStatusID");

                entity.Property(e => e.ArticleBody)
                    .IsRequired()
                    .HasMaxLength(350)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DateApproved).HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.ApprovalStatus)
                    .WithMany(p => p.Article)
                    .HasForeignKey(d => d.ApprovalStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Article_LOV");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Article)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Article_UserLogin");
            });

            modelBuilder.Entity<Artisan>(entity =>
            {
                entity.ToTable("Artisan", "dbo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AboutMe)
                    .HasMaxLength(1500)
                    .IsUnicode(false);

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.ArtisanCategoryId).HasColumnName("ArtisanCategoryID");

                entity.Property(e => e.Code)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.IdcardNo)
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

                entity.Property(e => e.RefererCode)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.AreaLocation)
                    .WithMany(p => p.Artisan)
                    .HasForeignKey(d => d.AreaLocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Artisan_Location");

                entity.HasOne(d => d.ArtisanCategory)
                    .WithMany(p => p.Artisan)
                    .HasForeignKey(d => d.ArtisanCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Artisan_ArtisanCategories");
            });

            modelBuilder.Entity<ArtisanCategories>(entity =>
            {
                entity.ToTable("ArtisanCategories", "dbo");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ArtisanServices>(entity =>
            {
                entity.ToTable("ArtisanServices", "dbo");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Createdon).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Artisan)
                    .WithMany(p => p.ArtisanServices)
                    .HasForeignKey(d => d.ArtisanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ArtisanServices_Artisan");
            });

            modelBuilder.Entity<ArtisanSubCategory>(entity =>
            {
                entity.ToTable("ArtisanSubCategory", "dbo");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CategoryId).HasColumnName("Category_Id");

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.SubCategories).IsRequired();
            });

            modelBuilder.Entity<AuditTrail>(entity =>
            {
                entity.ToTable("AuditTrail", "dbo");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Browser)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedTime)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.Device)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.IpAddress)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Lat)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Long)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.MacAddress)
                    .HasColumnName("Mac_address")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Os)
                    .HasColumnName("OS")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AuditTrail)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AuditTrail_Login");
            });

            modelBuilder.Entity<BankCodeLov>(entity =>
            {
                entity.HasKey(e => e.Bankcode);

                entity.ToTable("BankCodeLOV", "dbo");

                entity.Property(e => e.Bankcode).HasMaxLength(10);

                entity.Property(e => e.BankName)
                    .IsRequired()
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<BankDetails>(entity =>
            {
                entity.ToTable("BankDetails", "dbo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AccountName)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.AccountNumber).HasMaxLength(110);

                entity.Property(e => e.BankCode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Bvn)
                    .IsRequired()
                    .HasColumnName("BVN")
                    .HasMaxLength(11);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("Booking", "dbo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Messages)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MsgDate).HasColumnType("datetime");

                entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

                entity.HasOne(d => d.Artisan)
                    .WithMany(p => p.Booking)
                    .HasForeignKey(d => d.ArtisanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Booking_Artisan");

                entity.HasOne(d => d.Clien)
                    .WithMany(p => p.Booking)
                    .HasForeignKey(d => d.ClienId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Booking_Client");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Client", "dbo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Code).HasMaxLength(150);

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false);

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

                entity.Property(e => e.RefererCode).HasMaxLength(150);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(70)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Complaint>(entity =>
            {
                entity.ToTable("Complaint", "dbo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.DateResolved).HasColumnType("date");

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Complaint)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Complainant_StatusTable");
            });

            modelBuilder.Entity<Gallary>(entity =>
            {
                entity.ToTable("Gallary", "dbo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Descr)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.JobDate).HasColumnType("datetime");

                entity.Property(e => e.JobName)
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.PicturePath)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.Artisan)
                    .WithMany(p => p.Gallary)
                    .HasForeignKey(d => d.ArtisanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Gallary_Artisan");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Gallary)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK_Gallary_Projects");
            });

            modelBuilder.Entity<Lga>(entity =>
            {
                entity.ToTable("LGA", "dbo");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Lga1)
                    .IsRequired()
                    .HasColumnName("LGA")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.State)
                    .WithMany(p => p.Lga)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LGA_State");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("Location", "dbo");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Area)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Lga)
                    .IsRequired()
                    .HasColumnName("LGA")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Location)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Location_LOV");
            });

            modelBuilder.Entity<Lov>(entity =>
            {
                entity.ToTable("LOV", "dbo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PaymentHistory>(entity =>
            {
                entity.ToTable("PaymentHistory", "dbo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AmountPaid).HasColumnType("money");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.PayDate).HasColumnType("date");

                entity.Property(e => e.PaymentType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.HasOne(d => d.Artisan)
                    .WithMany(p => p.PaymentHistory)
                    .HasForeignKey(d => d.ArtisanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PaymentHistory_Artisan");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.PaymentHistory)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PaymentHistory_Client");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.PaymentHistory)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PaymentHistory_Projects");
            });

            modelBuilder.Entity<Projects>(entity =>
            {
                entity.ToTable("Projects", "dbo");

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.ProjectName)
                    .IsRequired()
                    .HasMaxLength(180)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.Artisan)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.ArtisanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Projects_Artisan");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Projects_Client");

                entity.HasOne(d => d.Quote)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.QuoteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Projects_Quote");
            });

            modelBuilder.Entity<Quote>(entity =>
            {
                entity.ToTable("Quote", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Address1)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Descr)
                    .IsRequired()
                    .HasMaxLength(800)
                    .IsUnicode(false);

                entity.Property(e => e.Discount)
                    .HasColumnType("decimal(38, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Item)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.OrderStatusId).HasColumnName("OrderStatus_Id");

                entity.Property(e => e.Price).HasColumnType("decimal(38, 2)");

                entity.Property(e => e.Vat)
                    .HasColumnName("VAT")
                    .HasColumnType("decimal(38, 2)")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.Quote)
                    .HasForeignKey(d => d.BookingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Quote_Booking");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Quote)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Quote_Client");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Quote)
                    .HasForeignKey<Quote>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Quote_Artisan");

                entity.HasOne(d => d.OrderStatus)
                    .WithMany(p => p.Quote)
                    .HasForeignKey(d => d.OrderStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LOV_Quote");
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.ToTable("Rating", "dbo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.JobEndDate).HasColumnType("datetime");

                entity.Property(e => e.JobStartDate).HasColumnType("datetime");

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.Property(e => e.Rating1).HasColumnName("Rating");

                entity.Property(e => e.Remarks)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Artisan)
                    .WithMany(p => p.Rating)
                    .HasForeignKey(d => d.ArtisanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rating_Artisan");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Rating)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rating_Client");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Rating)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK__Rating__Project");
            });

            modelBuilder.Entity<Services>(entity =>
            {
                entity.ToTable("Services", "dbo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.Descriptions)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Image)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ServiceName)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.StateId).HasDefaultValueSql("((1))");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.HasOne(d => d.Artisan)
                    .WithMany(p => p.Services)
                    .HasForeignKey(d => d.ArtisanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Services_Artisan");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Services)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Services_Category");

                entity.HasOne(d => d.Lga)
                    .WithMany(p => p.Services)
                    .HasForeignKey(d => d.LgaId)
                    .HasConstraintName("FK_Services_LGA");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Services)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK_Services_Location");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Services)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Services__Status");

                entity.HasOne(d => d.SubCategory)
                    .WithMany(p => p.Services)
                    .HasForeignKey(d => d.SubCategoryId)
                    .HasConstraintName("FK_Services_ArtisanSubCategory");
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.ToTable("State", "dbo");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserLogin>(entity =>
            {
                entity.ToTable("UserLogin", "dbo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.StatusId).HasDefaultValueSql("((4))");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserLogin)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("UserLogin_fk0");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.UserLogin)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserLogin_LOV");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PK_USERROLE");

                entity.ToTable("UserRole", "dbo");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.CreatedDate).HasColumnType("date");

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

using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Database.Migrations
{
    public partial class initialbankdeaddsaccountnuber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbAd");

            migrationBuilder.CreateTable(
                name: "ArtisanCategories",
                schema: "dbAd",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryName = table.Column<string>(unicode: false, maxLength: 80, nullable: false),
                    SubCategories = table.Column<string>(unicode: false, maxLength: 80, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtisanCategories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BankCodeLOV",
                schema: "dbAd",
                columns: table => new
                {
                    Bankcode = table.Column<string>(maxLength: 60, nullable: false),
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BankName = table.Column<string>(unicode: false, maxLength: 70, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankCodeLOV", x => x.Bankcode);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                schema: "dbAd",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(unicode: false, maxLength: 80, nullable: false),
                    LastName = table.Column<string>(unicode: false, maxLength: 60, nullable: false),
                    PhoneNumber = table.Column<string>(unicode: false, maxLength: 13, nullable: false),
                    PicturePath = table.Column<string>(unicode: false, maxLength: 150, nullable: false),
                    Address = table.Column<string>(unicode: false, maxLength: 150, nullable: false),
                    State = table.Column<string>(unicode: false, maxLength: 70, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "LOV",
                schema: "dbAd",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Status = table.Column<string>(unicode: false, maxLength: 80, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOV", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                schema: "dbAd",
                columns: table => new
                {
                    RoleID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleName = table.Column<string>(unicode: false, maxLength: 60, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERROLE", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "Article",
                schema: "dbAd",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    EmailAddress = table.Column<string>(unicode: false, maxLength: 60, nullable: false),
                    ArticleBody = table.Column<string>(unicode: false, maxLength: 350, nullable: false),
                    ApprovalStatusID = table.Column<int>(nullable: false),
                    DateApproved = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Article", x => x.id);
                    table.ForeignKey(
                        name: "FK_Article_ArticleStatusLOV",
                        column: x => x.ApprovalStatusID,
                        principalSchema: "dbAd",
                        principalTable: "LOV",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Complaint",
                schema: "dbAd",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    EmailId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(unicode: false, maxLength: 250, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: false),
                    StatusID = table.Column<int>(nullable: false),
                    DateResolved = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Complaint", x => x.id);
                    table.ForeignKey(
                        name: "FK_Complainant_StatusTable",
                        column: x => x.StatusID,
                        principalSchema: "dbAd",
                        principalTable: "LOV",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                schema: "dbAd",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    State = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    LGA = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    Area = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    StatusId = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Location_LOV",
                        column: x => x.ID,
                        principalSchema: "dbAd",
                        principalTable: "LOV",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserLogin",
                schema: "dbAd",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    RoleID = table.Column<int>(nullable: false),
                    UserName = table.Column<string>(unicode: false, maxLength: 80, nullable: false),
                    StatusId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogin", x => x.id);
                    table.ForeignKey(
                        name: "UserLogin_fk0",
                        column: x => x.RoleID,
                        principalSchema: "dbAd",
                        principalTable: "UserRole",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserLogin_LOV",
                        column: x => x.StatusId,
                        principalSchema: "dbAd",
                        principalTable: "LOV",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Artisan",
                schema: "dbAd",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(unicode: false, maxLength: 80, nullable: false),
                    LastName = table.Column<string>(unicode: false, maxLength: 60, nullable: false),
                    PhoneNumber = table.Column<string>(unicode: false, maxLength: 13, nullable: false),
                    AreaLocation = table.Column<string>(unicode: false, maxLength: 60, nullable: false),
                    IDCardNo = table.Column<string>(maxLength: 40, nullable: true),
                    PicturePath = table.Column<string>(unicode: false, maxLength: 150, nullable: false),
                    Address = table.Column<string>(unicode: false, maxLength: 150, nullable: false),
                    ArtisanCategoryID = table.Column<int>(nullable: false),
                    StateId = table.Column<int>(nullable: false),
                    AboutMe = table.Column<string>(unicode: false, maxLength: 1500, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artisan", x => x.id);
                    table.ForeignKey(
                        name: "FK_Artisan_Catg",
                        column: x => x.ArtisanCategoryID,
                        principalSchema: "dbAd",
                        principalTable: "ArtisanCategories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Artisan_Location",
                        column: x => x.StateId,
                        principalSchema: "dbAd",
                        principalTable: "Location",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ArtisanServices",
                schema: "dbAd",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArtisanId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 250, nullable: false),
                    Description = table.Column<string>(unicode: false, maxLength: 8000, nullable: false),
                    Status = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    Createdon = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtisanServices", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ArtisanServices_Artisan",
                        column: x => x.ArtisanId,
                        principalSchema: "dbAd",
                        principalTable: "Artisan",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BankDetails",
                schema: "dbAd",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArtisanId = table.Column<int>(nullable: false),
                    AccountName = table.Column<string>(unicode: false, maxLength: 80, nullable: false),
                    AccountNumber = table.Column<string>(nullable: true),
                    BankCode = table.Column<string>(maxLength: 60, nullable: false),
                    BVN = table.Column<long>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankDetails", x => x.id);
                    table.ForeignKey(
                        name: "FK_BankDetails_Artisan",
                        column: x => x.ArtisanId,
                        principalSchema: "dbAd",
                        principalTable: "Artisan",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BankDetails_BankDetails",
                        column: x => x.BankCode,
                        principalSchema: "dbAd",
                        principalTable: "BankCodeLOV",
                        principalColumn: "Bankcode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                schema: "dbAd",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClienId = table.Column<int>(nullable: false),
                    ArtisanId = table.Column<int>(nullable: false),
                    Messages = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    MsgDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    MsgTime = table.Column<TimeSpan>(nullable: false),
                    ServiceID = table.Column<int>(nullable: true),
                    QuoteId = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.id);
                    table.ForeignKey(
                        name: "FK_Booking_Artisan",
                        column: x => x.ArtisanId,
                        principalSchema: "dbAd",
                        principalTable: "Artisan",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Booking_Client",
                        column: x => x.ClienId,
                        principalSchema: "dbAd",
                        principalTable: "Client",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                schema: "dbAd",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArtisanId = table.Column<int>(nullable: false),
                    ServiceName = table.Column<string>(unicode: false, maxLength: 150, nullable: false),
                    Descriptions = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    StatusID = table.Column<int>(nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.id);
                    table.ForeignKey(
                        name: "FK_Services_Artisan",
                        column: x => x.ArtisanId,
                        principalSchema: "dbAd",
                        principalTable: "Artisan",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Services__Status",
                        column: x => x.StatusID,
                        principalSchema: "dbAd",
                        principalTable: "LOV",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Quote",
                schema: "dbAd",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArtisanId = table.Column<int>(nullable: false),
                    ClientId = table.Column<int>(nullable: false),
                    Item = table.Column<string>(unicode: false, maxLength: 80, nullable: false),
                    Descr = table.Column<string>(unicode: false, maxLength: 800, nullable: false),
                    Quantity = table.Column<double>(nullable: false),
                    Price = table.Column<decimal>(type: "decimal(38, 2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(38, 2)", nullable: true, defaultValueSql: "((0))"),
                    VAT = table.Column<decimal>(type: "decimal(38, 2)", nullable: true, defaultValueSql: "((0))"),
                    Address1 = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    BookingId = table.Column<int>(nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    OrderStatus_Id = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quote", x => x.id);
                    table.ForeignKey(
                        name: "FK_Quote_Booking",
                        column: x => x.BookingId,
                        principalSchema: "dbAd",
                        principalTable: "Booking",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Quote_Client",
                        column: x => x.ClientId,
                        principalSchema: "dbAd",
                        principalTable: "Client",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Quote_Artisan",
                        column: x => x.id,
                        principalSchema: "dbAd",
                        principalTable: "Artisan",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__LOV_Quote",
                        column: x => x.OrderStatus_Id,
                        principalSchema: "dbAd",
                        principalTable: "LOV",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                schema: "dbAd",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArtisanId = table.Column<int>(nullable: false),
                    ClientId = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    StatusId = table.Column<int>(nullable: false),
                    ProjectName = table.Column<string>(unicode: false, maxLength: 180, nullable: false),
                    QuoteId = table.Column<int>(nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_Artisan",
                        column: x => x.ArtisanId,
                        principalSchema: "dbAd",
                        principalTable: "Artisan",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Projects_Client",
                        column: x => x.ClientId,
                        principalSchema: "dbAd",
                        principalTable: "Client",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Projects_Quote",
                        column: x => x.QuoteId,
                        principalSchema: "dbAd",
                        principalTable: "Quote",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Gallary",
                schema: "dbAd",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArtisanId = table.Column<int>(nullable: false),
                    JobName = table.Column<string>(unicode: false, maxLength: 120, nullable: true),
                    Descr = table.Column<string>(unicode: false, maxLength: 500, nullable: true),
                    PicturePath = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    JobDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ProjectId = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gallary", x => x.id);
                    table.ForeignKey(
                        name: "FK_Gallary_Artisan",
                        column: x => x.ArtisanId,
                        principalSchema: "dbAd",
                        principalTable: "Artisan",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Gallary_Projects",
                        column: x => x.ProjectId,
                        principalSchema: "dbAd",
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PaymentHistory",
                schema: "dbAd",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProjectID = table.Column<int>(nullable: false),
                    ArtisanId = table.Column<int>(nullable: false),
                    AmountPaid = table.Column<decimal>(type: "money", nullable: false),
                    PayDate = table.Column<DateTime>(type: "date", nullable: false),
                    PaymentType = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    ClientId = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentHistory", x => x.id);
                    table.ForeignKey(
                        name: "FK_PaymentHistory_Artisan",
                        column: x => x.ArtisanId,
                        principalSchema: "dbAd",
                        principalTable: "Artisan",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PaymentHistory_Client",
                        column: x => x.ClientId,
                        principalSchema: "dbAd",
                        principalTable: "Client",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PaymentHistory_Projects",
                        column: x => x.ProjectID,
                        principalSchema: "dbAd",
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rating",
                schema: "dbAd",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClientId = table.Column<int>(nullable: false),
                    ArtisanId = table.Column<int>(nullable: false),
                    JobStartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    JobEndDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Description = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    Remarks = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    Rating = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ProjectID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.id);
                    table.ForeignKey(
                        name: "FK_Rating_Artisan",
                        column: x => x.ArtisanId,
                        principalSchema: "dbAd",
                        principalTable: "Artisan",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rating_Client",
                        column: x => x.ClientId,
                        principalSchema: "dbAd",
                        principalTable: "Client",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Rating__Project",
                        column: x => x.ProjectID,
                        principalSchema: "dbAd",
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Article_ApprovalStatusID",
                schema: "dbAd",
                table: "Article",
                column: "ApprovalStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Article_EmailAddress",
                schema: "dbAd",
                table: "Article",
                column: "EmailAddress");

            migrationBuilder.CreateIndex(
                name: "IX_Artisan_ArtisanCategoryID",
                schema: "dbAd",
                table: "Artisan",
                column: "ArtisanCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Artisan_StateId",
                schema: "dbAd",
                table: "Artisan",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "EmailUnique",
                schema: "dbAd",
                table: "Artisan",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ArtisanServices_ArtisanId",
                schema: "dbAd",
                table: "ArtisanServices",
                column: "ArtisanId");

            migrationBuilder.CreateIndex(
                name: "IX_BankCodeLOV",
                schema: "dbAd",
                table: "BankCodeLOV",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BankDetails_ArtisanId",
                schema: "dbAd",
                table: "BankDetails",
                column: "ArtisanId");

            migrationBuilder.CreateIndex(
                name: "IX_BankDetails_BankCode",
                schema: "dbAd",
                table: "BankDetails",
                column: "BankCode");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_ArtisanEmail",
                schema: "dbAd",
                table: "Booking",
                column: "ArtisanId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_ClientEmail",
                schema: "dbAd",
                table: "Booking",
                column: "ClienId");

            migrationBuilder.CreateIndex(
                name: "C_EmailUnique",
                schema: "dbAd",
                table: "Client",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Complainant_ArtisanEmail",
                schema: "dbAd",
                table: "Complaint",
                column: "EmailId");

            migrationBuilder.CreateIndex(
                name: "IX_Complainant_StatusID",
                schema: "dbAd",
                table: "Complaint",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Gallary_ArtisanId",
                schema: "dbAd",
                table: "Gallary",
                column: "ArtisanId");

            migrationBuilder.CreateIndex(
                name: "IX_Gallary_ProjectId",
                schema: "dbAd",
                table: "Gallary",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "UQ__ArticleS__3A15923FE8A1903C",
                schema: "dbAd",
                table: "LOV",
                column: "Status",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PaymentHistory_ArtisanEmail",
                schema: "dbAd",
                table: "PaymentHistory",
                column: "ArtisanId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentHistory_ClientEmail",
                schema: "dbAd",
                table: "PaymentHistory",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentHistory_ProjectID",
                schema: "dbAd",
                table: "PaymentHistory",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ArtisanId",
                schema: "dbAd",
                table: "Projects",
                column: "ArtisanId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ClientId",
                schema: "dbAd",
                table: "Projects",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_BookingID",
                schema: "dbAd",
                table: "Projects",
                column: "QuoteId");

            migrationBuilder.CreateIndex(
                name: "IX_Quote_ArtisanEmail",
                schema: "dbAd",
                table: "Quote",
                column: "ArtisanId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Quote_ProjectID",
                schema: "dbAd",
                table: "Quote",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_Quote_ClientId",
                schema: "dbAd",
                table: "Quote",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Quote_OrderStatus_Id",
                schema: "dbAd",
                table: "Quote",
                column: "OrderStatus_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_ArtisanEmail",
                schema: "dbAd",
                table: "Rating",
                column: "ArtisanId");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_ClientEmail",
                schema: "dbAd",
                table: "Rating",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_ProjectID",
                schema: "dbAd",
                table: "Rating",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Services_ArtisanId",
                schema: "dbAd",
                table: "Services",
                column: "ArtisanId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_StatusID",
                schema: "dbAd",
                table: "Services",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogin_RoleID",
                schema: "dbAd",
                table: "UserLogin",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogin_StatusId",
                schema: "dbAd",
                table: "UserLogin",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "UQ__UserLogi__C9F284568AF4CB29",
                schema: "dbAd",
                table: "UserLogin",
                column: "UserName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Article",
                schema: "dbAd");

            migrationBuilder.DropTable(
                name: "ArtisanServices",
                schema: "dbAd");

            migrationBuilder.DropTable(
                name: "BankDetails",
                schema: "dbAd");

            migrationBuilder.DropTable(
                name: "Complaint",
                schema: "dbAd");

            migrationBuilder.DropTable(
                name: "Gallary",
                schema: "dbAd");

            migrationBuilder.DropTable(
                name: "PaymentHistory",
                schema: "dbAd");

            migrationBuilder.DropTable(
                name: "Rating",
                schema: "dbAd");

            migrationBuilder.DropTable(
                name: "Services",
                schema: "dbAd");

            migrationBuilder.DropTable(
                name: "UserLogin",
                schema: "dbAd");

            migrationBuilder.DropTable(
                name: "BankCodeLOV",
                schema: "dbAd");

            migrationBuilder.DropTable(
                name: "Projects",
                schema: "dbAd");

            migrationBuilder.DropTable(
                name: "UserRole",
                schema: "dbAd");

            migrationBuilder.DropTable(
                name: "Quote",
                schema: "dbAd");

            migrationBuilder.DropTable(
                name: "Booking",
                schema: "dbAd");

            migrationBuilder.DropTable(
                name: "Artisan",
                schema: "dbAd");

            migrationBuilder.DropTable(
                name: "Client",
                schema: "dbAd");

            migrationBuilder.DropTable(
                name: "ArtisanCategories",
                schema: "dbAd");

            migrationBuilder.DropTable(
                name: "Location",
                schema: "dbAd");

            migrationBuilder.DropTable(
                name: "LOV",
                schema: "dbAd");
        }
    }
}

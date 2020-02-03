using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Database.Migrations
{
    public partial class inituserloginaltered : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbAd");

            migrationBuilder.CreateTable(
                name: "ArticleStatusLOV",
                schema: "dbAd",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Status = table.Column<string>(unicode: false, maxLength: 80, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleStatusLOV", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ArtisanCategories",
                schema: "dbAd",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryName = table.Column<string>(unicode: false, maxLength: 80, nullable: false),
                    CategoryDescr = table.Column<string>(unicode: false, maxLength: 250, nullable: false),
                    SubCategories = table.Column<string>(unicode: false, maxLength: 80, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtisanCategories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ArtisanServices",
                schema: "dbAd",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArtisanID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 250, nullable: false),
                    Description = table.Column<string>(unicode: false, maxLength: 8000, nullable: false),
                    Status = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    Createdon = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtisanServices", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                schema: "dbAd",
                columns: table => new
                {
                    EmailAddress = table.Column<string>(unicode: false, maxLength: 60, nullable: false),
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(unicode: false, maxLength: 80, nullable: false),
                    LastName = table.Column<string>(unicode: false, maxLength: 60, nullable: false),
                    PhoneNumber = table.Column<string>(unicode: false, maxLength: 13, nullable: false),
                    IDCardNo = table.Column<string>(maxLength: 80, nullable: true),
                    PicturePath = table.Column<string>(unicode: false, maxLength: 150, nullable: false),
                    Address = table.Column<string>(unicode: false, maxLength: 150, nullable: false),
                    State = table.Column<string>(unicode: false, maxLength: 70, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLIENT", x => x.EmailAddress);
                });

            migrationBuilder.CreateTable(
                name: "ComplianStatusLOV",
                schema: "dbAd",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Status = table.Column<string>(unicode: false, maxLength: 80, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplianStatusLOV", x => x.id);
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
                    Status = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "QuoteStatus_LOV",
                schema: "dbAd",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Status = table.Column<string>(unicode: false, maxLength: 80, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuoteStatus_LOV", x => x.id);
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
                name: "Artisan",
                schema: "dbAd",
                columns: table => new
                {
                    EmailAddress = table.Column<string>(unicode: false, maxLength: 60, nullable: false),
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(unicode: false, maxLength: 80, nullable: false),
                    LastName = table.Column<string>(unicode: false, maxLength: 60, nullable: false),
                    PhoneNumber = table.Column<string>(unicode: false, maxLength: 13, nullable: false),
                    AreaLocation = table.Column<string>(unicode: false, maxLength: 60, nullable: false),
                    IDCardNo = table.Column<string>(maxLength: 40, nullable: true),
                    PicturePath = table.Column<string>(unicode: false, maxLength: 150, nullable: false),
                    Address = table.Column<string>(unicode: false, maxLength: 150, nullable: false),
                    ArtisanCategoryID = table.Column<int>(nullable: false),
                    State = table.Column<string>(unicode: false, maxLength: 70, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ARTISAN", x => x.EmailAddress);
                    table.ForeignKey(
                        name: "FK_Artisan_Catg",
                        column: x => x.ArtisanCategoryID,
                        principalSchema: "dbAd",
                        principalTable: "ArtisanCategories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserLogin",
                schema: "dbAd",
                columns: table => new
                {
                    EmailAddress = table.Column<string>(unicode: false, maxLength: 60, nullable: false),
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
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Password = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "date", nullable: false),
                    RoleID = table.Column<int>(nullable: false),
                    UserName = table.Column<string>(unicode: false, maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERLOGIN", x => x.EmailAddress);
                    table.ForeignKey(
                        name: "UserLogin_fk0",
                        column: x => x.RoleID,
                        principalSchema: "dbAd",
                        principalTable: "UserRole",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ArtisanBankDetails",
                schema: "dbAd",
                columns: table => new
                {
                    EmailAddress = table.Column<string>(unicode: false, maxLength: 60, nullable: false),
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountName = table.Column<string>(unicode: false, maxLength: 80, nullable: false),
                    AccountNumber = table.Column<decimal>(type: "numeric(10, 0)", nullable: false),
                    BankName = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    BVN = table.Column<decimal>(type: "numeric(18, 0)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ARTISANBANKDETAILS", x => x.EmailAddress);
                    table.ForeignKey(
                        name: "FK_ArtisanBankDetails_Artisan",
                        column: x => x.EmailAddress,
                        principalSchema: "dbAd",
                        principalTable: "Artisan",
                        principalColumn: "EmailAddress",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ArtisanDashboard",
                schema: "dbAd",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmailAddress = table.Column<string>(unicode: false, maxLength: 60, nullable: false),
                    ProductImagePath = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    Comments = table.Column<string>(unicode: false, maxLength: 700, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtisanDashboard", x => x.id);
                    table.ForeignKey(
                        name: "FK_ArtisanDashboard_Artisan",
                        column: x => x.EmailAddress,
                        principalSchema: "dbAd",
                        principalTable: "Artisan",
                        principalColumn: "EmailAddress",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                schema: "dbAd",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClientEmail = table.Column<string>(unicode: false, maxLength: 60, nullable: false),
                    ArtisanEmail = table.Column<string>(unicode: false, maxLength: 60, nullable: false),
                    Messages = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    MsgDate = table.Column<DateTime>(type: "date", nullable: false),
                    MsgTime = table.Column<TimeSpan>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.id);
                    table.ForeignKey(
                        name: "FK_Booking_Artisan",
                        column: x => x.ArtisanEmail,
                        principalSchema: "dbAd",
                        principalTable: "Artisan",
                        principalColumn: "EmailAddress",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Booking_Client",
                        column: x => x.ClientEmail,
                        principalSchema: "dbAd",
                        principalTable: "Client",
                        principalColumn: "EmailAddress",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Complainant",
                schema: "dbAd",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    ArtisanEmail = table.Column<string>(unicode: false, maxLength: 60, nullable: false),
                    Description = table.Column<string>(unicode: false, maxLength: 250, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: false),
                    StatusID = table.Column<int>(nullable: false),
                    DateResolved = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Complainant", x => x.id);
                    table.ForeignKey(
                        name: "FK__Complaina__Artis__54CB950F",
                        column: x => x.ArtisanEmail,
                        principalSchema: "dbAd",
                        principalTable: "Artisan",
                        principalColumn: "EmailAddress",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Complainant_StatusTable",
                        column: x => x.StatusID,
                        principalSchema: "dbAd",
                        principalTable: "ComplianStatusLOV",
                        principalColumn: "id",
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
                    ArtisanEmail = table.Column<string>(unicode: false, maxLength: 60, nullable: false),
                    AmountPaid = table.Column<decimal>(type: "money", nullable: false),
                    PayDate = table.Column<DateTime>(type: "date", nullable: false),
                    PaymentType = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    ClientEmail = table.Column<string>(unicode: false, maxLength: 60, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentHistory", x => x.id);
                    table.ForeignKey(
                        name: "FK_PH_Artisan",
                        column: x => x.ArtisanEmail,
                        principalSchema: "dbAd",
                        principalTable: "Artisan",
                        principalColumn: "EmailAddress",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PH_Client",
                        column: x => x.ClientEmail,
                        principalSchema: "dbAd",
                        principalTable: "Client",
                        principalColumn: "EmailAddress",
                        onDelete: ReferentialAction.Restrict);
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
                        principalTable: "ArticleStatusLOV",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Article_UserLogin",
                        column: x => x.EmailAddress,
                        principalSchema: "dbAd",
                        principalTable: "UserLogin",
                        principalColumn: "EmailAddress",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                schema: "dbAd",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArtisanEmail = table.Column<string>(unicode: false, maxLength: 60, nullable: false),
                    ClientEmail = table.Column<string>(unicode: false, maxLength: 60, nullable: false),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "date", nullable: false),
                    ProjectStatus = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    ProjectName = table.Column<string>(unicode: false, maxLength: 80, nullable: false),
                    BookingID = table.Column<int>(nullable: false),
                    CreationDate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_Booking",
                        column: x => x.BookingID,
                        principalSchema: "dbAd",
                        principalTable: "Booking",
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
                    ArtisanEmail = table.Column<string>(unicode: false, maxLength: 60, nullable: false),
                    Item = table.Column<string>(unicode: false, maxLength: 80, nullable: false),
                    Descr = table.Column<string>(unicode: false, maxLength: 80, nullable: false),
                    Quantity = table.Column<double>(nullable: false),
                    Price = table.Column<decimal>(type: "decimal(38, 2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(38, 2)", nullable: true, defaultValueSql: "((0))"),
                    VAT = table.Column<decimal>(type: "decimal(38, 2)", nullable: true, defaultValueSql: "((0))"),
                    Address1 = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    ProjectID = table.Column<int>(nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    OrderStatus_Id = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quote", x => x.id);
                    table.ForeignKey(
                        name: "FK__Quote__ArtisanEm__78D3EB5B",
                        column: x => x.ArtisanEmail,
                        principalSchema: "dbAd",
                        principalTable: "Artisan",
                        principalColumn: "EmailAddress",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Quote__OrderStat__7CA47C3F",
                        column: x => x.OrderStatus_Id,
                        principalSchema: "dbAd",
                        principalTable: "QuoteStatus_LOV",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Quote__ProjectID__7BB05806",
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
                    ClientEmail = table.Column<string>(unicode: false, maxLength: 60, nullable: false),
                    ArtisanEmail = table.Column<string>(unicode: false, maxLength: 60, nullable: false),
                    JobStartDate = table.Column<DateTime>(type: "date", nullable: false),
                    JobEndDate = table.Column<DateTime>(type: "date", nullable: false),
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
                        column: x => x.ArtisanEmail,
                        principalSchema: "dbAd",
                        principalTable: "Artisan",
                        principalColumn: "EmailAddress",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rating_Client",
                        column: x => x.ClientEmail,
                        principalSchema: "dbAd",
                        principalTable: "Client",
                        principalColumn: "EmailAddress",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Rating__ProjectI__04459E07",
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
                name: "UQ__ArticleS__3A15923FE8A1903C",
                schema: "dbAd",
                table: "ArticleStatusLOV",
                column: "Status",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Artisan_ArtisanCategoryID",
                schema: "dbAd",
                table: "Artisan",
                column: "ArtisanCategoryID");

            migrationBuilder.CreateIndex(
                name: "UQ__Artisan__7EDFFE556682FC51",
                schema: "dbAd",
                table: "Artisan",
                column: "IDCardNo",
                unique: true,
                filter: "[IDCardNo] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ__ArtisanD__49A14740F9559EDF",
                schema: "dbAd",
                table: "ArtisanDashboard",
                column: "EmailAddress",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Booking_ArtisanEmail",
                schema: "dbAd",
                table: "Booking",
                column: "ArtisanEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_ClientEmail",
                schema: "dbAd",
                table: "Booking",
                column: "ClientEmail");

            migrationBuilder.CreateIndex(
                name: "UQ__Client__7EDFFE55A80A881B",
                schema: "dbAd",
                table: "Client",
                column: "IDCardNo",
                unique: true,
                filter: "[IDCardNo] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Complainant_ArtisanEmail",
                schema: "dbAd",
                table: "Complainant",
                column: "ArtisanEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Complainant_StatusID",
                schema: "dbAd",
                table: "Complainant",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_StatusTable",
                schema: "dbAd",
                table: "ComplianStatusLOV",
                column: "Status",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PaymentHistory_ArtisanEmail",
                schema: "dbAd",
                table: "PaymentHistory",
                column: "ArtisanEmail");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentHistory_ClientEmail",
                schema: "dbAd",
                table: "PaymentHistory",
                column: "ClientEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_BookingID",
                schema: "dbAd",
                table: "Projects",
                column: "BookingID");

            migrationBuilder.CreateIndex(
                name: "IX_Quote_ArtisanEmail",
                schema: "dbAd",
                table: "Quote",
                column: "ArtisanEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Quote_OrderStatus_Id",
                schema: "dbAd",
                table: "Quote",
                column: "OrderStatus_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Quote_ProjectID",
                schema: "dbAd",
                table: "Quote",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_ArtisanEmail",
                schema: "dbAd",
                table: "Rating",
                column: "ArtisanEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_ClientEmail",
                schema: "dbAd",
                table: "Rating",
                column: "ClientEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_ProjectID",
                schema: "dbAd",
                table: "Rating",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogin_RoleID",
                schema: "dbAd",
                table: "UserLogin",
                column: "RoleID");

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
                name: "ArtisanBankDetails",
                schema: "dbAd");

            migrationBuilder.DropTable(
                name: "ArtisanDashboard",
                schema: "dbAd");

            migrationBuilder.DropTable(
                name: "ArtisanServices",
                schema: "dbAd");

            migrationBuilder.DropTable(
                name: "Complainant",
                schema: "dbAd");

            migrationBuilder.DropTable(
                name: "Location",
                schema: "dbAd");

            migrationBuilder.DropTable(
                name: "PaymentHistory",
                schema: "dbAd");

            migrationBuilder.DropTable(
                name: "Quote",
                schema: "dbAd");

            migrationBuilder.DropTable(
                name: "Rating",
                schema: "dbAd");

            migrationBuilder.DropTable(
                name: "ArticleStatusLOV",
                schema: "dbAd");

            migrationBuilder.DropTable(
                name: "UserLogin",
                schema: "dbAd");

            migrationBuilder.DropTable(
                name: "ComplianStatusLOV",
                schema: "dbAd");

            migrationBuilder.DropTable(
                name: "QuoteStatus_LOV",
                schema: "dbAd");

            migrationBuilder.DropTable(
                name: "Projects",
                schema: "dbAd");

            migrationBuilder.DropTable(
                name: "UserRole",
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
        }
    }
}

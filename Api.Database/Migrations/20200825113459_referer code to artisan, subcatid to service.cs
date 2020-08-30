using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Database.Migrations
{
    public partial class referercodetoartisansubcatidtoservice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Article_ArticleStatusLOV",
                schema: "dbAd",
                table: "Article");

            migrationBuilder.DropForeignKey(
                name: "FK_Artisan_Catg",
                schema: "dbAd",
                table: "Artisan");

            migrationBuilder.DropForeignKey(
                name: "FK_BankDetails_Artisan",
                schema: "dbAd",
                table: "BankDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_BankDetails_BankDetails",
                schema: "dbAd",
                table: "BankDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Location_LOV",
                schema: "dbAd",
                table: "Location");

            migrationBuilder.DropIndex(
                name: "IX_BankDetails_ArtisanId",
                schema: "dbAd",
                table: "BankDetails");

            migrationBuilder.DropIndex(
                name: "IX_BankDetails_BankCode",
                schema: "dbAd",
                table: "BankDetails");

            migrationBuilder.DropIndex(
                name: "IX_Article_EmailAddress",
                schema: "dbAd",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "SubCategories",
                schema: "dbAd",
                table: "ArtisanCategories");

            migrationBuilder.DropColumn(
                name: "AreaLocation",
                schema: "dbAd",
                table: "Artisan");

            migrationBuilder.DropColumn(
                name: "EmailAddress",
                schema: "dbAd",
                table: "Article");

            migrationBuilder.RenameColumn(
                name: "StateId",
                schema: "dbAd",
                table: "Artisan",
                newName: "AreaLocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Artisan_StateId",
                schema: "dbAd",
                table: "Artisan",
                newName: "IX_Artisan_AreaLocationId");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                schema: "dbAd",
                table: "UserLogin",
                nullable: false,
                defaultValueSql: "((4))",
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                schema: "dbAd",
                table: "Services",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                schema: "dbAd",
                table: "Services",
                unicode: false,
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LgaId",
                schema: "dbAd",
                table: "Services",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                schema: "dbAd",
                table: "Services",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubCategoryId",
                schema: "dbAd",
                table: "Services",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                schema: "dbAd",
                table: "Location",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "dbAd",
                table: "BankDetails",
                type: "datetime",
                nullable: false,
                defaultValueSql: "(getdate())",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BVN",
                schema: "dbAd",
                table: "BankDetails",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<string>(
                name: "BankCode",
                schema: "dbAd",
                table: "BankDetails",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 60);

            migrationBuilder.AlterColumn<string>(
                name: "AccountNumber",
                schema: "dbAd",
                table: "BankDetails",
                maxLength: 110,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "dbAd",
                table: "BankCodeLOV",
                type: "datetime",
                nullable: false,
                defaultValueSql: "(getdate())",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Bankcode",
                schema: "dbAd",
                table: "BankCodeLOV",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 60);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "dbAd",
                table: "ArtisanCategories",
                unicode: false,
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RefererCode",
                schema: "dbAd",
                table: "Artisan",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                schema: "dbAd",
                table: "Artisan",
                unicode: false,
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                schema: "dbAd",
                table: "Article",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ArtisanSubCategory",
                schema: "dbAd",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    SubCategories = table.Column<string>(nullable: false),
                    Descr = table.Column<string>(nullable: true),
                    Category_Id = table.Column<int>(nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtisanSubCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuditTrail",
                schema: "dbAd",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    IpAddress = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    OS = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Lat = table.Column<string>(unicode: false, maxLength: 150, nullable: true),
                    Long = table.Column<string>(unicode: false, maxLength: 150, nullable: true),
                    Mac_address = table.Column<string>(unicode: false, maxLength: 150, nullable: true),
                    Browser = table.Column<string>(unicode: false, maxLength: 70, nullable: true),
                    Device = table.Column<string>(unicode: false, maxLength: 150, nullable: true),
                    CreatedTime = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditTrail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuditTrail_Login",
                        column: x => x.UserId,
                        principalSchema: "dbAd",
                        principalTable: "UserLogin",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "State",
                schema: "dbAd",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LGA",
                schema: "dbAd",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    LGA = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    StateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LGA", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LGA_State",
                        column: x => x.StateId,
                        principalSchema: "dbAd",
                        principalTable: "State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Services_CategoryId",
                schema: "dbAd",
                table: "Services",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_LgaId",
                schema: "dbAd",
                table: "Services",
                column: "LgaId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_LocationId",
                schema: "dbAd",
                table: "Services",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_SubCategoryId",
                schema: "dbAd",
                table: "Services",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Location_StatusId",
                schema: "dbAd",
                table: "Location",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Article_EmailAddress",
                schema: "dbAd",
                table: "Article",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AuditTrail_UserId",
                schema: "dbAd",
                table: "AuditTrail",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LGA_StateId",
                schema: "dbAd",
                table: "LGA",
                column: "StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Article_LOV",
                schema: "dbAd",
                table: "Article",
                column: "ApprovalStatusID",
                principalSchema: "dbAd",
                principalTable: "LOV",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Article_UserLogin",
                schema: "dbAd",
                table: "Article",
                column: "UserId",
                principalSchema: "dbAd",
                principalTable: "UserLogin",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Artisan_ArtisanCategories",
                schema: "dbAd",
                table: "Artisan",
                column: "ArtisanCategoryID",
                principalSchema: "dbAd",
                principalTable: "ArtisanCategories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Location_LOV",
                schema: "dbAd",
                table: "Location",
                column: "StatusId",
                principalSchema: "dbAd",
                principalTable: "LOV",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Category",
                schema: "dbAd",
                table: "Services",
                column: "CategoryId",
                principalSchema: "dbAd",
                principalTable: "ArtisanCategories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_LGA",
                schema: "dbAd",
                table: "Services",
                column: "LgaId",
                principalSchema: "dbAd",
                principalTable: "LGA",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Location",
                schema: "dbAd",
                table: "Services",
                column: "LocationId",
                principalSchema: "dbAd",
                principalTable: "Location",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_ArtisanSubCategory_SubCategoryId",
                schema: "dbAd",
                table: "Services",
                column: "SubCategoryId",
                principalSchema: "dbAd",
                principalTable: "ArtisanSubCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Article_LOV",
                schema: "dbAd",
                table: "Article");

            migrationBuilder.DropForeignKey(
                name: "FK_Article_UserLogin",
                schema: "dbAd",
                table: "Article");

            migrationBuilder.DropForeignKey(
                name: "FK_Artisan_ArtisanCategories",
                schema: "dbAd",
                table: "Artisan");

            migrationBuilder.DropForeignKey(
                name: "FK_Location_LOV",
                schema: "dbAd",
                table: "Location");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Category",
                schema: "dbAd",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_LGA",
                schema: "dbAd",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Location",
                schema: "dbAd",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_ArtisanSubCategory_SubCategoryId",
                schema: "dbAd",
                table: "Services");

            migrationBuilder.DropTable(
                name: "ArtisanSubCategory",
                schema: "dbAd");

            migrationBuilder.DropTable(
                name: "AuditTrail",
                schema: "dbAd");

            migrationBuilder.DropTable(
                name: "LGA",
                schema: "dbAd");

            migrationBuilder.DropTable(
                name: "State",
                schema: "dbAd");

            migrationBuilder.DropIndex(
                name: "IX_Services_CategoryId",
                schema: "dbAd",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_LgaId",
                schema: "dbAd",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_LocationId",
                schema: "dbAd",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_SubCategoryId",
                schema: "dbAd",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Location_StatusId",
                schema: "dbAd",
                table: "Location");

            migrationBuilder.DropIndex(
                name: "IX_Article_EmailAddress",
                schema: "dbAd",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                schema: "dbAd",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "Image",
                schema: "dbAd",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "LgaId",
                schema: "dbAd",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "LocationId",
                schema: "dbAd",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "SubCategoryId",
                schema: "dbAd",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "dbAd",
                table: "ArtisanCategories");

            migrationBuilder.DropColumn(
                name: "RefererCode",
                schema: "dbAd",
                table: "Artisan");

            migrationBuilder.DropColumn(
                name: "State",
                schema: "dbAd",
                table: "Artisan");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "dbAd",
                table: "Article");

            migrationBuilder.RenameColumn(
                name: "AreaLocationId",
                schema: "dbAd",
                table: "Artisan",
                newName: "StateId");

            migrationBuilder.RenameIndex(
                name: "IX_Artisan_AreaLocationId",
                schema: "dbAd",
                table: "Artisan",
                newName: "IX_Artisan_StateId");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                schema: "dbAd",
                table: "UserLogin",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValueSql: "((4))");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                schema: "dbAd",
                table: "Location",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "dbAd",
                table: "BankDetails",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "(getdate())");

            migrationBuilder.AlterColumn<long>(
                name: "BVN",
                schema: "dbAd",
                table: "BankDetails",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 11);

            migrationBuilder.AlterColumn<string>(
                name: "BankCode",
                schema: "dbAd",
                table: "BankDetails",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "AccountNumber",
                schema: "dbAd",
                table: "BankDetails",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 110,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "dbAd",
                table: "BankCodeLOV",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "(getdate())");

            migrationBuilder.AlterColumn<string>(
                name: "Bankcode",
                schema: "dbAd",
                table: "BankCodeLOV",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 10);

            migrationBuilder.AddColumn<string>(
                name: "SubCategories",
                schema: "dbAd",
                table: "ArtisanCategories",
                unicode: false,
                maxLength: 80,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AreaLocation",
                schema: "dbAd",
                table: "Artisan",
                unicode: false,
                maxLength: 60,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                schema: "dbAd",
                table: "Article",
                unicode: false,
                maxLength: 60,
                nullable: false,
                defaultValue: "");

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
                name: "IX_Article_EmailAddress",
                schema: "dbAd",
                table: "Article",
                column: "EmailAddress");

            migrationBuilder.AddForeignKey(
                name: "FK_Article_ArticleStatusLOV",
                schema: "dbAd",
                table: "Article",
                column: "ApprovalStatusID",
                principalSchema: "dbAd",
                principalTable: "LOV",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Artisan_Catg",
                schema: "dbAd",
                table: "Artisan",
                column: "ArtisanCategoryID",
                principalSchema: "dbAd",
                principalTable: "ArtisanCategories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BankDetails_Artisan",
                schema: "dbAd",
                table: "BankDetails",
                column: "ArtisanId",
                principalSchema: "dbAd",
                principalTable: "Artisan",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BankDetails_BankDetails",
                schema: "dbAd",
                table: "BankDetails",
                column: "BankCode",
                principalSchema: "dbAd",
                principalTable: "BankCodeLOV",
                principalColumn: "Bankcode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Location_LOV",
                schema: "dbAd",
                table: "Location",
                column: "ID",
                principalSchema: "dbAd",
                principalTable: "LOV",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

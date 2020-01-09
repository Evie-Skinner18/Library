using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Library.Migrations
{
    public partial class AddOtherInitialModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LibraryCardId",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LocalLibraryBranchId",
                table: "Customers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LibraryBranches",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    Address = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    DateOpened = table.Column<DateTime>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibraryBranches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LibraryCards",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FeesOwed = table.Column<decimal>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibraryCards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LibraryItemStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ItemName = table.Column<string>(nullable: true),
                    StatusDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibraryItemStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BranchHours",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BranchId = table.Column<int>(nullable: true),
                    DayOfWeek = table.Column<int>(nullable: false),
                    OpenTime = table.Column<int>(nullable: false),
                    CloseTime = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchHours", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BranchHours_LibraryBranches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "LibraryBranches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LibraryItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    ItemStatusId = table.Column<int>(nullable: false),
                    Cost = table.Column<decimal>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    NumberOfCopies = table.Column<int>(nullable: false),
                    LocationId = table.Column<int>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    ISBN = table.Column<string>(nullable: true),
                    Author = table.Column<string>(nullable: true),
                    Artist = table.Column<string>(nullable: true),
                    MusicGenre = table.Column<string>(nullable: true),
                    Director = table.Column<string>(nullable: true),
                    FilmGenre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibraryItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LibraryItems_LibraryItemStatuses_ItemStatusId",
                        column: x => x.ItemStatusId,
                        principalTable: "LibraryItemStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LibraryItems_LibraryBranches_LocationId",
                        column: x => x.LocationId,
                        principalTable: "LibraryBranches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CheckoutHistories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ItemId = table.Column<int>(nullable: false),
                    LibraryCardId = table.Column<int>(nullable: true),
                    DateCheckedOut = table.Column<DateTime>(nullable: false),
                    DateCheckedIn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckoutHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CheckoutHistories_LibraryItems_ItemId",
                        column: x => x.ItemId,
                        principalTable: "LibraryItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CheckoutHistories_LibraryCards_LibraryCardId",
                        column: x => x.LibraryCardId,
                        principalTable: "LibraryCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Checkouts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ItemId = table.Column<int>(nullable: false),
                    LibraryCardId = table.Column<int>(nullable: true),
                    BorrowingDate = table.Column<DateTime>(nullable: false),
                    DueDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Checkouts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Checkouts_LibraryItems_ItemId",
                        column: x => x.ItemId,
                        principalTable: "LibraryItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Checkouts_LibraryCards_LibraryCardId",
                        column: x => x.LibraryCardId,
                        principalTable: "LibraryCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reserves",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ItemId = table.Column<int>(nullable: true),
                    LibraryCardId = table.Column<int>(nullable: true),
                    DateReserved = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reserves_LibraryItems_ItemId",
                        column: x => x.ItemId,
                        principalTable: "LibraryItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reserves_LibraryCards_LibraryCardId",
                        column: x => x.LibraryCardId,
                        principalTable: "LibraryCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_LibraryCardId",
                table: "Customers",
                column: "LibraryCardId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_LocalLibraryBranchId",
                table: "Customers",
                column: "LocalLibraryBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchHours_BranchId",
                table: "BranchHours",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckoutHistories_ItemId",
                table: "CheckoutHistories",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckoutHistories_LibraryCardId",
                table: "CheckoutHistories",
                column: "LibraryCardId");

            migrationBuilder.CreateIndex(
                name: "IX_Checkouts_ItemId",
                table: "Checkouts",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Checkouts_LibraryCardId",
                table: "Checkouts",
                column: "LibraryCardId");

            migrationBuilder.CreateIndex(
                name: "IX_LibraryItems_ItemStatusId",
                table: "LibraryItems",
                column: "ItemStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_LibraryItems_LocationId",
                table: "LibraryItems",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Reserves_ItemId",
                table: "Reserves",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Reserves_LibraryCardId",
                table: "Reserves",
                column: "LibraryCardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_LibraryCards_LibraryCardId",
                table: "Customers",
                column: "LibraryCardId",
                principalTable: "LibraryCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_LibraryBranches_LocalLibraryBranchId",
                table: "Customers",
                column: "LocalLibraryBranchId",
                principalTable: "LibraryBranches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_LibraryCards_LibraryCardId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_LibraryBranches_LocalLibraryBranchId",
                table: "Customers");

            migrationBuilder.DropTable(
                name: "BranchHours");

            migrationBuilder.DropTable(
                name: "CheckoutHistories");

            migrationBuilder.DropTable(
                name: "Checkouts");

            migrationBuilder.DropTable(
                name: "Reserves");

            migrationBuilder.DropTable(
                name: "LibraryItems");

            migrationBuilder.DropTable(
                name: "LibraryCards");

            migrationBuilder.DropTable(
                name: "LibraryItemStatuses");

            migrationBuilder.DropTable(
                name: "LibraryBranches");

            migrationBuilder.DropIndex(
                name: "IX_Customers_LibraryCardId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_LocalLibraryBranchId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "LibraryCardId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "LocalLibraryBranchId",
                table: "Customers");
        }
    }
}

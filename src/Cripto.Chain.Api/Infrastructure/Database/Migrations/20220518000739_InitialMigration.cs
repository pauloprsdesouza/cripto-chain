using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Cripto.Chain.Api.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "criptochain");

            migrationBuilder.CreateTable(
                name: "asset",
                schema: "criptochain",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Currency = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_asset", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "customer",
                schema: "criptochain",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "wallet",
                schema: "criptochain",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CustomerId = table.Column<int>(nullable: false),
                    AssetId = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_wallet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_wallet_asset_AssetId",
                        column: x => x.AssetId,
                        principalSchema: "criptochain",
                        principalTable: "asset",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_wallet_customer_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "criptochain",
                        principalTable: "customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "transaction",
                schema: "criptochain",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreditWalletId = table.Column<int>(nullable: false),
                    DebitWalletId = table.Column<int>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_transaction_wallet_CreditWalletId",
                        column: x => x.CreditWalletId,
                        principalSchema: "criptochain",
                        principalTable: "wallet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_transaction_wallet_DebitWalletId",
                        column: x => x.DebitWalletId,
                        principalSchema: "criptochain",
                        principalTable: "wallet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_transaction_CreditWalletId",
                schema: "criptochain",
                table: "transaction",
                column: "CreditWalletId");

            migrationBuilder.CreateIndex(
                name: "IX_transaction_DebitWalletId",
                schema: "criptochain",
                table: "transaction",
                column: "DebitWalletId");

            migrationBuilder.CreateIndex(
                name: "IX_wallet_AssetId",
                schema: "criptochain",
                table: "wallet",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_wallet_CustomerId",
                schema: "criptochain",
                table: "wallet",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "transaction",
                schema: "criptochain");

            migrationBuilder.DropTable(
                name: "wallet",
                schema: "criptochain");

            migrationBuilder.DropTable(
                name: "asset",
                schema: "criptochain");

            migrationBuilder.DropTable(
                name: "customer",
                schema: "criptochain");
        }
    }
}

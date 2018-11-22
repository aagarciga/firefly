using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Firefly.DAL.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "contractproductsupplementpric_contractproductsupplementpric_seq");

            migrationBuilder.CreateTable(
                name: "ContactTitle",
                columns: table => new
                {
                    ContactTitleId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactTitle", x => x.ContactTitleId);
                });

            migrationBuilder.CreateTable(
                name: "Language",
                columns: table => new
                {
                    LanguageId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.LanguageId);
                });

            migrationBuilder.CreateTable(
                name: "Price",
                columns: table => new
                {
                    PriceId = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CostPrice = table.Column<decimal>(type: "numeric(15,6)", nullable: true, defaultValueSql: "0.00"),
                    SalesPrice = table.Column<decimal>(type: "numeric(15,6)", nullable: true, defaultValueSql: "0.00"),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "date", nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Price", x => x.PriceId);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsArchived = table.Column<bool>(nullable: false),
                    ProductType = table.Column<int>(nullable: false),
                    Category = table.Column<string>(nullable: true),
                    CanBeSold = table.Column<bool>(nullable: false),
                    CanBePurchased = table.Column<bool>(nullable: false),
                    InternalReference = table.Column<string>(nullable: true),
                    SalesPrice = table.Column<decimal>(type: "numeric(15,6)", nullable: true),
                    CustomerTaxes = table.Column<decimal>(type: "numeric(15,6)", nullable: true),
                    Cost = table.Column<decimal>(type: "numeric(15,6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "SupplementCategory",
                columns: table => new
                {
                    SupplementCategoryId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    IsArchived = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplementCategory", x => x.SupplementCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    ContactId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: true),
                    ParentId = table.Column<int>(nullable: false),
                    ContactTitleId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    LanguageId = table.Column<int>(nullable: false),
                    ContactType = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    IsArchived = table.Column<bool>(nullable: false),
                    IsACompany = table.Column<bool>(nullable: false),
                    Street1 = table.Column<string>(nullable: true),
                    Street2 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Zip = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    TaxId = table.Column<string>(nullable: true),
                    JobPosition = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Website = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.ContactId);
                    table.ForeignKey(
                        name: "fk_contact_contacttitle",
                        column: x => x.ContactTitleId,
                        principalTable: "ContactTitle",
                        principalColumn: "ContactTitleId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "fk_contact_languaje",
                        column: x => x.LanguageId,
                        principalTable: "Language",
                        principalColumn: "LanguageId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "fk_parectcontact",
                        column: x => x.ParentId,
                        principalTable: "Contact",
                        principalColumn: "ContactId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Supplement",
                columns: table => new
                {
                    SupplementId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsArchived = table.Column<bool>(nullable: false),
                    SupplementCategoryId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplement", x => x.SupplementId);
                    table.ForeignKey(
                        name: "fk_supplement_supplementcategory",
                        column: x => x.SupplementCategoryId,
                        principalTable: "SupplementCategory",
                        principalColumn: "SupplementCategoryId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Contract",
                columns: table => new
                {
                    ContractId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    IsClosed = table.Column<bool>(nullable: false),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "date", nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    IsArchived = table.Column<bool>(nullable: false),
                    ContactId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contract", x => x.ContractId);
                    table.ForeignKey(
                        name: "fk_contract_contact",
                        column: x => x.ContactId,
                        principalTable: "Contact",
                        principalColumn: "ContactId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "ContractProduct",
                columns: table => new
                {
                    ContractProductId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ContractId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractProduct", x => x.ContractProductId);
                    table.ForeignKey(
                        name: "fk_contractproduct_contract",
                        column: x => x.ContractId,
                        principalTable: "Contract",
                        principalColumn: "ContractId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "fk_contractproduct_product",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "ContractProductPrice",
                columns: table => new
                {
                    ContractProductPriceId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ContractProductId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    PriceId = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractProductPrice", x => x.ContractProductPriceId);
                    table.ForeignKey(
                        name: "contractproductprice_contractproduct",
                        column: x => x.ContractProductId,
                        principalTable: "ContractProduct",
                        principalColumn: "ContractProductId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "fk_contractproductprice_price",
                        column: x => x.PriceId,
                        principalTable: "Price",
                        principalColumn: "PriceId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "ContractProductSupplement",
                columns: table => new
                {
                    ContractProductSupplementId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    SupplementId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ContractProductId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractProductSupplement", x => x.ContractProductSupplementId);
                    table.ForeignKey(
                        name: "fk_contractproductsupplement_contractproduct",
                        column: x => x.ContractProductId,
                        principalTable: "ContractProduct",
                        principalColumn: "ContractProductId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "fk_contractproductsupplement_supplement",
                        column: x => x.SupplementId,
                        principalTable: "Supplement",
                        principalColumn: "SupplementId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "ContractProductSupplementPrice",
                columns: table => new
                {
                    ContractProductSupplementPriceId = table.Column<int>(nullable: false, defaultValueSql: "nextval('contractproductsupplementpric_contractproductsupplementpric_seq'::regclass)"),
                    ContractProductSupplementId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    PriceId = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractProductSupplementPrice", x => x.ContractProductSupplementPriceId);
                    table.ForeignKey(
                        name: "fk_contractproductsupplementprice_contractproductsupplement",
                        column: x => x.ContractProductSupplementId,
                        principalTable: "ContractProductSupplement",
                        principalColumn: "ContractProductSupplementId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "fk_contractproductsupplementprice_price",
                        column: x => x.PriceId,
                        principalTable: "Price",
                        principalColumn: "PriceId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contact_ContactTitleId",
                table: "Contact",
                column: "ContactTitleId");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_LanguageId",
                table: "Contact",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_ParentId",
                table: "Contact",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Contract_ContactId",
                table: "Contract",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractProduct_ContractId",
                table: "ContractProduct",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractProduct_ProductId",
                table: "ContractProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractProductPrice_ContractProductId",
                table: "ContractProductPrice",
                column: "ContractProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractProductPrice_PriceId",
                table: "ContractProductPrice",
                column: "PriceId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractProductSupplement_ContractProductId",
                table: "ContractProductSupplement",
                column: "ContractProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractProductSupplement_SupplementId",
                table: "ContractProductSupplement",
                column: "SupplementId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractProductSupplementPrice_ContractProductSupplementId",
                table: "ContractProductSupplementPrice",
                column: "ContractProductSupplementId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractProductSupplementPrice_PriceId",
                table: "ContractProductSupplementPrice",
                column: "PriceId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplement_SupplementCategoryId",
                table: "Supplement",
                column: "SupplementCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContractProductPrice");

            migrationBuilder.DropTable(
                name: "ContractProductSupplementPrice");

            migrationBuilder.DropTable(
                name: "ContractProductSupplement");

            migrationBuilder.DropTable(
                name: "Price");

            migrationBuilder.DropTable(
                name: "ContractProduct");

            migrationBuilder.DropTable(
                name: "Supplement");

            migrationBuilder.DropTable(
                name: "Contract");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "SupplementCategory");

            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "ContactTitle");

            migrationBuilder.DropTable(
                name: "Language");

            migrationBuilder.DropSequence(
                name: "contractproductsupplementpric_contractproductsupplementpric_seq");
        }
    }
}

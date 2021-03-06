﻿// <auto-generated />
using System;
using Firefly.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Firefly.DAL.Migrations
{
    [DbContext(typeof(PostgreSQLContext))]
    partial class PostgreSQLContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("Relational:Sequence:.contractproductsupplementpric_contractproductsupplementpric_seq", "'contractproductsupplementpric_contractproductsupplementpric_seq', '', '1', '1', '', '', 'Int64', 'False'");

            modelBuilder.Entity("Firefly.DAL.Model.Base.Contact", b =>
                {
                    b.Property<int>("ContactId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ContactId");

                    b.Property<string>("City")
                        .HasColumnName("City");

                    b.Property<int>("ContactTitleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ContactTitleId");

                    b.Property<int>("ContactType")
                        .HasColumnName("ContactType");

                    b.Property<string>("Country")
                        .HasColumnName("Country");

                    b.Property<string>("CreatedBy")
                        .HasColumnName("CreatedBy");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnName("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email");

                    b.Property<bool>("IsACompany");

                    b.Property<bool>("IsArchived");

                    b.Property<string>("JobPosition");

                    b.Property<int>("LanguageId");

                    b.Property<string>("Mobile");

                    b.Property<string>("Name");

                    b.Property<string>("Note");

                    b.Property<int>("ParentId");

                    b.Property<string>("Phone");

                    b.Property<string>("State");

                    b.Property<string>("Street1");

                    b.Property<string>("Street2");

                    b.Property<string>("TaxId");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime>("UpdatedDate");

                    b.Property<string>("Website")
                        .HasColumnName("Website");

                    b.Property<string>("Zip")
                        .HasColumnName("Zip");

                    b.HasKey("ContactId");

                    b.HasIndex("ContactTitleId");

                    b.HasIndex("LanguageId");

                    b.HasIndex("ParentId");

                    b.ToTable("Contact");
                });

            modelBuilder.Entity("Firefly.DAL.Model.Base.ContactTitle", b =>
                {
                    b.Property<int>("ContactTitleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ContactTitleId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name");

                    b.HasKey("ContactTitleId");

                    b.ToTable("ContactTitle");
                });

            modelBuilder.Entity("Firefly.DAL.Model.Base.Contract", b =>
                {
                    b.Property<int>("ContractId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ContractId");

                    b.Property<int>("ContactId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ContactId");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("EndDate")
                        .HasColumnName("EndDate")
                        .HasColumnType("date");

                    b.Property<bool>("IsArchived");

                    b.Property<bool>("IsClosed")
                        .HasColumnName("IsClosed");

                    b.Property<DateTime>("StartDate")
                        .HasColumnName("StartDate")
                        .HasColumnType("date");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("ContractId");

                    b.HasIndex("ContactId");

                    b.ToTable("Contract");
                });

            modelBuilder.Entity("Firefly.DAL.Model.Base.ContractProduct", b =>
                {
                    b.Property<int>("ContractProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ContractProductId");

                    b.Property<int>("ContractId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ContractId");

                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ProductId");

                    b.HasKey("ContractProductId");

                    b.HasIndex("ContractId");

                    b.HasIndex("ProductId");

                    b.ToTable("ContractProduct");
                });

            modelBuilder.Entity("Firefly.DAL.Model.Base.ContractProductPrice", b =>
                {
                    b.Property<int>("ContractProductPriceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ContractProductPriceId");

                    b.Property<int>("ContractProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ContractProductId");

                    b.Property<long>("PriceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("PriceId");

                    b.HasKey("ContractProductPriceId");

                    b.HasIndex("ContractProductId");

                    b.HasIndex("PriceId");

                    b.ToTable("ContractProductPrice");
                });

            modelBuilder.Entity("Firefly.DAL.Model.Base.ContractProductSupplement", b =>
                {
                    b.Property<int>("ContractProductSupplementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ContractProductSupplementId");

                    b.Property<int>("ContractProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ContractProductId");

                    b.Property<int>("SupplementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("SupplementId");

                    b.HasKey("ContractProductSupplementId");

                    b.HasIndex("ContractProductId");

                    b.HasIndex("SupplementId");

                    b.ToTable("ContractProductSupplement");
                });

            modelBuilder.Entity("Firefly.DAL.Model.Base.ContractProductSupplementPrice", b =>
                {
                    b.Property<int>("ContractProductSupplementPriceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ContractProductSupplementPriceId")
                        .HasDefaultValueSql("nextval('contractproductsupplementpric_contractproductsupplementpric_seq'::regclass)");

                    b.Property<int>("ContractProductSupplementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ContractProductSupplementId");

                    b.Property<long>("PriceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("PriceId");

                    b.HasKey("ContractProductSupplementPriceId");

                    b.HasIndex("ContractProductSupplementId");

                    b.HasIndex("PriceId");

                    b.ToTable("ContractProductSupplementPrice");
                });

            modelBuilder.Entity("Firefly.DAL.Model.Base.Language", b =>
                {
                    b.Property<int>("LanguageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("LanguageId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name");

                    b.HasKey("LanguageId");

                    b.ToTable("Language");
                });

            modelBuilder.Entity("Firefly.DAL.Model.Base.Price", b =>
                {
                    b.Property<long>("PriceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("PriceId");

                    b.Property<decimal?>("CostPrice")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CostPrice")
                        .HasColumnType("numeric(15,6)")
                        .HasDefaultValueSql("0.00");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("EndDate")
                        .HasColumnName("EndDate")
                        .HasColumnType("date");

                    b.Property<decimal?>("SalesPrice")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("SalesPrice")
                        .HasColumnType("numeric(15,6)")
                        .HasDefaultValueSql("0.00");

                    b.Property<DateTime>("StartDate")
                        .HasColumnName("StartDate")
                        .HasColumnType("date");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("PriceId");

                    b.ToTable("Price");
                });

            modelBuilder.Entity("Firefly.DAL.Model.Base.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ProductId");

                    b.Property<bool>("CanBePurchased")
                        .HasColumnName("CanBePurchased");

                    b.Property<bool>("CanBeSold")
                        .HasColumnName("CanBeSold");

                    b.Property<string>("Category")
                        .HasColumnName("Category");

                    b.Property<decimal?>("Cost")
                        .HasColumnName("Cost")
                        .HasColumnType("numeric(15,6)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnName("CreatedBy");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnName("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal?>("CustomerTaxes")
                        .HasColumnName("CustomerTaxes")
                        .HasColumnType("numeric(15,6)");

                    b.Property<string>("InternalReference")
                        .HasColumnName("InternalReference");

                    b.Property<bool>("IsArchived");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name");

                    b.Property<int>("ProductType")
                        .HasColumnName("ProductType");

                    b.Property<decimal?>("SalesPrice")
                        .HasColumnName("SalesPrice")
                        .HasColumnType("numeric(15,6)");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasColumnName("UpdatedBy");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnName("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("ProductId");

                    b.ToTable("Product");

                    b.HasDiscriminator<int>("ProductType");
                });

            modelBuilder.Entity("Firefly.DAL.Model.Base.Supplement", b =>
                {
                    b.Property<int>("SupplementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("SupplementId");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnName("CreatedBy");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnName("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsArchived");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name");

                    b.Property<int>("SupplementCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("SupplementCategoryId");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasColumnName("UpdatedBy");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnName("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("SupplementId");

                    b.HasIndex("SupplementCategoryId");

                    b.ToTable("Supplement");
                });

            modelBuilder.Entity("Firefly.DAL.Model.Base.SupplementCategory", b =>
                {
                    b.Property<int>("SupplementCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("SupplementCategoryId");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("IsArchived");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("SupplementCategoryId");

                    b.ToTable("SupplementCategory");
                });

            modelBuilder.Entity("Firefly.DAL.Model.Consumable", b =>
                {
                    b.HasBaseType("Firefly.DAL.Model.Base.Product");


                    b.ToTable("Consumable");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("Firefly.DAL.Model.Room", b =>
                {
                    b.HasBaseType("Firefly.DAL.Model.Base.Product");


                    b.ToTable("Room");

                    b.HasDiscriminator().HasValue(4);
                });

            modelBuilder.Entity("Firefly.DAL.Model.Service", b =>
                {
                    b.HasBaseType("Firefly.DAL.Model.Base.Product");


                    b.ToTable("Service");

                    b.HasDiscriminator().HasValue(2);
                });

            modelBuilder.Entity("Firefly.DAL.Model.Stockable", b =>
                {
                    b.HasBaseType("Firefly.DAL.Model.Base.Product");


                    b.ToTable("Stockable");

                    b.HasDiscriminator().HasValue(3);
                });

            modelBuilder.Entity("Firefly.DAL.Model.Base.Contact", b =>
                {
                    b.HasOne("Firefly.DAL.Model.Base.ContactTitle", "ContactTitle")
                        .WithMany("Contacts")
                        .HasForeignKey("ContactTitleId")
                        .HasConstraintName("fk_contact_contacttitle")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Firefly.DAL.Model.Base.Language", "Language")
                        .WithMany("Contacts")
                        .HasForeignKey("LanguageId")
                        .HasConstraintName("fk_contact_languaje")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Firefly.DAL.Model.Base.Contact", "Parent")
                        .WithMany("Contacts")
                        .HasForeignKey("ParentId")
                        .HasConstraintName("fk_parectcontact");
                });

            modelBuilder.Entity("Firefly.DAL.Model.Base.Contract", b =>
                {
                    b.HasOne("Firefly.DAL.Model.Base.Contact", "Contact")
                        .WithMany("Contracts")
                        .HasForeignKey("ContactId")
                        .HasConstraintName("fk_contract_contact")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("Firefly.DAL.Model.Base.ContractProduct", b =>
                {
                    b.HasOne("Firefly.DAL.Model.Base.Contract", "Contract")
                        .WithMany("ContractProducts")
                        .HasForeignKey("ContractId")
                        .HasConstraintName("fk_contractproduct_contract")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Firefly.DAL.Model.Base.Product", "Product")
                        .WithMany("ContractProducts")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("fk_contractproduct_product")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("Firefly.DAL.Model.Base.ContractProductPrice", b =>
                {
                    b.HasOne("Firefly.DAL.Model.Base.ContractProduct", "ContractProduct")
                        .WithMany("ContractProductPrices")
                        .HasForeignKey("ContractProductId")
                        .HasConstraintName("contractproductprice_contractproduct")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Firefly.DAL.Model.Base.Price", "Price")
                        .WithMany("ContractProductPrices")
                        .HasForeignKey("PriceId")
                        .HasConstraintName("fk_contractproductprice_price")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("Firefly.DAL.Model.Base.ContractProductSupplement", b =>
                {
                    b.HasOne("Firefly.DAL.Model.Base.ContractProduct", "ContractProduct")
                        .WithMany("ContractProductSupplements")
                        .HasForeignKey("ContractProductId")
                        .HasConstraintName("fk_contractproductsupplement_contractproduct")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Firefly.DAL.Model.Base.Supplement", "Supplement")
                        .WithMany("ContractProductSupplements")
                        .HasForeignKey("SupplementId")
                        .HasConstraintName("fk_contractproductsupplement_supplement")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("Firefly.DAL.Model.Base.ContractProductSupplementPrice", b =>
                {
                    b.HasOne("Firefly.DAL.Model.Base.ContractProductSupplement", "ContractProductSupplement")
                        .WithMany("ContractProductSupplementPrices")
                        .HasForeignKey("ContractProductSupplementId")
                        .HasConstraintName("fk_contractproductsupplementprice_contractproductsupplement")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Firefly.DAL.Model.Base.Price", "Price")
                        .WithMany("ContractProductSupplementPrices")
                        .HasForeignKey("PriceId")
                        .HasConstraintName("fk_contractproductsupplementprice_price")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("Firefly.DAL.Model.Base.Supplement", b =>
                {
                    b.HasOne("Firefly.DAL.Model.Base.SupplementCategory", "SupplementCategory")
                        .WithMany("Supplements")
                        .HasForeignKey("SupplementCategoryId")
                        .HasConstraintName("fk_supplement_supplementcategory")
                        .OnDelete(DeleteBehavior.SetNull);
                });
#pragma warning restore 612, 618
        }
    }
}

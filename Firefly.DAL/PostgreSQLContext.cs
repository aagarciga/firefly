using Firefly.DAL.Model;
using Firefly.DAL.Model.Base;
using Firefly.DAL.Model.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Firefly.DAL
{
    public partial class PostgreSQLContext : DbContext
    {
        public PostgreSQLContext()
        {

        }

        public PostgreSQLContext(DbContextOptions<PostgreSQLContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<ContactTitle> ContactTitles { get; set; }
        public virtual DbSet<Contract> Contracts { get; set; }
        public virtual DbSet<ContractProduct> ContractProducts { get; set; }
        public virtual DbSet<ContractProductPrice> ContractProductPrices { get; set; }
        public virtual DbSet<ContractProductSupplement> ContractProductSupplements { get; set; }
        public virtual DbSet<ContractProductSupplementPrice> ContractProductSupplementPrices { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<Price> Prices { get; set; }        
        public virtual DbSet<Supplement> Supplements { get; set; }
        public virtual DbSet<SupplementCategory> SupplementCategories { get; set; }
        // Alex: Product is an abstract Class so the we put here the implementations instead
        //public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Consumable> Consumables { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<Stockable> Stockables { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // To protect potentially sensitive information in your connection string, 
            // you should move it out of source code. 
            // See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseNpgsql("Host=localhost;Database=Turmundo;Username=openpg;Password=openpgpwd");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Contact Model Building
            modelBuilder.Entity<Contact>(entity =>
            {
                entity.ToTable("Contact");
                entity.Property(e => e.ContactId).HasColumnName("ContactId");
                entity.Property(e => e.City).HasColumnName("City");
                entity.Property(e => e.ContactTitleId)
                    .HasColumnName("ContactTitleId")
                    .ValueGeneratedOnAdd();
                entity.Property(e => e.ContactType).HasColumnName("ContactType");
                entity.Property(e => e.Country).HasColumnName("Country");
                entity.Property(e => e.CreatedBy).HasColumnName("CreatedBy");
                entity.Property(e => e.CreatedDate)
                    .HasColumnName("CreatedDate")
                    .HasColumnType("timestamp with time zone");
                entity.Property(e => e.Website).HasColumnName("Website");
                entity.Property(e => e.Zip).HasColumnName("Zip");
                entity.HasOne(d => d.ContactTitle)
                    .WithMany(p => p.Contacts)
                    .HasForeignKey(d => d.ContactTitleId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("fk_contact_contacttitle");
                entity.HasOne(d => d.Language)
                    .WithMany(p => p.Contacts)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("fk_contact_languaje");
                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.Contacts)
                    .HasForeignKey(d => d.ParentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_parectcontact");
            });
            #endregion

            #region Contact Title Model Building
            modelBuilder.Entity<ContactTitle>(entity =>
            {
                entity.ToTable("ContactTitle");
                entity.Property(e => e.ContactTitleId).HasColumnName("ContactTitleId");
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("Name");
            });
            #endregion

            #region Contract Model Building
            modelBuilder.Entity<Contract>(entity =>
            {
                entity.ToTable("Contract");
                entity.Property(e => e.ContractId).HasColumnName("ContractId");
                entity.Property(e => e.ContactId)
                    .HasColumnName("ContactId")
                    .ValueGeneratedOnAdd();
                entity.Property(e => e.StartDate)
                    .HasColumnName("StartDate")
                    .HasColumnType("date");
                entity.Property(e => e.EndDate)
                    .HasColumnName("EndDate")
                    .HasColumnType("date");
                entity.Property(e => e.IsClosed).HasColumnName("IsClosed");                
                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.Contracts)
                    .HasForeignKey(d => d.ContactId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("fk_contract_contact");
            });
            #endregion

            #region Contract Product Model Building
            modelBuilder.Entity<ContractProduct>(entity =>
            {
                entity.ToTable("ContractProduct");
                entity.Property(e => e.ContractProductId).HasColumnName("ContractProductId");
                entity.Property(e => e.ContractId)
                    .HasColumnName("ContractId")
                    .ValueGeneratedOnAdd();
                entity.Property(e => e.ProductId)
                    .HasColumnName("ProductId")
                    .ValueGeneratedOnAdd();
                entity.HasOne(d => d.Contract)
                    .WithMany(p => p.ContractProducts)
                    .HasForeignKey(d => d.ContractId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("fk_contractproduct_contract");
                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ContractProducts)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("fk_contractproduct_product");
            });
            #endregion

            #region Contract Product Price Model Building
            modelBuilder.Entity<ContractProductPrice>(entity =>
            {
                entity.ToTable("ContractProductPrice");
                entity.Property(e => e.ContractProductPriceId).HasColumnName("ContractProductPriceId");
                entity.Property(e => e.ContractProductId)
                    .HasColumnName("ContractProductId")
                    .ValueGeneratedOnAdd();
                entity.Property(e => e.PriceId)
                    .HasColumnName("PriceId")
                    .ValueGeneratedOnAdd();
                entity.HasOne(d => d.ContractProduct)
                    .WithMany(p => p.ContractProductPrices)
                    .HasForeignKey(d => d.ContractProductId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("contractproductprice_contractproduct");
                entity.HasOne(d => d.Price)
                    .WithMany(p => p.ContractProductPrices)
                    .HasForeignKey(d => d.PriceId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("fk_contractproductprice_price");
            });
            #endregion

            #region Contract Product Supplement Model Building
            modelBuilder.Entity<ContractProductSupplement>(entity =>
            {
                entity.ToTable("ContractProductSupplement");
                entity.Property(e => e.ContractProductSupplementId).HasColumnName("ContractProductSupplementId");
                entity.Property(e => e.ContractProductId)
                    .HasColumnName("ContractProductId")
                    .ValueGeneratedOnAdd();
                entity.Property(e => e.SupplementId)
                    .HasColumnName("SupplementId")
                    .ValueGeneratedOnAdd();
                entity.HasOne(d => d.ContractProduct)
                    .WithMany(p => p.ContractProductSupplements)
                    .HasForeignKey(d => d.ContractProductId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("fk_contractproductsupplement_contractproduct");
                entity.HasOne(d => d.Supplement)
                    .WithMany(p => p.ContractProductSupplements)
                    .HasForeignKey(d => d.SupplementId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("fk_contractproductsupplement_supplement");
            });
            #endregion

            #region Contract Product Supplement Price Model Building
            modelBuilder.Entity<ContractProductSupplementPrice>(entity =>
            {
                entity.ToTable("ContractProductSupplementPrice");
                entity.Property(e => e.ContractProductSupplementPriceId)
                    .HasColumnName("ContractProductSupplementPriceId")
                    .HasDefaultValueSql("nextval('contractproductsupplementpric_contractproductsupplementpric_seq'::regclass)");
                entity.Property(e => e.ContractProductSupplementId)
                    .HasColumnName("ContractProductSupplementId")
                    .ValueGeneratedOnAdd();
                entity.Property(e => e.PriceId)
                    .HasColumnName("PriceId")
                    .ValueGeneratedOnAdd();
                entity.HasOne(d => d.ContractProductSupplement)
                    .WithMany(p => p.ContractProductSupplementPrices)
                    .HasForeignKey(d => d.ContractProductSupplementId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("fk_contractproductsupplementprice_contractproductsupplement");
                entity.HasOne(d => d.Price)
                    .WithMany(p => p.ContractProductSupplementPrices)
                    .HasForeignKey(d => d.PriceId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("fk_contractproductsupplementprice_price");
            });
            #endregion

            #region Language Model Building
            modelBuilder.Entity<Language>(entity =>
            {
                entity.ToTable("Language");
                entity.Property(e => e.LanguageId).HasColumnName("LanguageId");
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("Name");
            });
            #endregion

            #region Price Model Building
            modelBuilder.Entity<Price>(entity =>
            {
                entity.ToTable("Price");
                entity.Property(e => e.PriceId).HasColumnName("PriceId");
                entity.Property(e => e.CostPrice)
                    .HasColumnName("CostPrice")
                    .HasColumnType("numeric(15,6)")
                    .HasDefaultValueSql("0.00");
                entity.Property(e => e.StartDate)
                    .HasColumnName("StartDate")
                    .HasColumnType("date");
                entity.Property(e => e.EndDate)
                    .HasColumnName("EndDate")
                    .HasColumnType("date");
                entity.Property(e => e.SalesPrice)
                    .HasColumnName("SalesPrice")
                    .HasColumnType("numeric(15,6)")
                    .HasDefaultValueSql("0.00");                
            });
            #endregion

            #region Product Model Building
            modelBuilder.Entity<Product>(entity =>
            {
                #region Product Hierarchy Relationship
                entity.ToTable("Product")
                    .HasDiscriminator<int>("ProductType")
                    .HasValue<Consumable>((int)ProductType.Consumable)
                    .HasValue<Room>((int)ProductType.Room)
                    .HasValue<Service>((int)ProductType.Service)
                    .HasValue<Stockable>((int)ProductType.Storable);
                #endregion
                entity.Property(e => e.ProductId).HasColumnName("ProductId");
                entity.Property(e => e.CanBePurchased).HasColumnName("CanBePurchased");
                entity.Property(e => e.CanBeSold).HasColumnName("CanBeSold");
                entity.Property(e => e.Category).HasColumnName("Category");
                entity.Property(e => e.Cost)
                    .HasColumnName("Cost")
                    .HasColumnType("numeric(15,6)");
                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("CreatedBy");
                entity.Property(e => e.CreatedDate)
                    .HasColumnName("CreatedDate")
                    .HasColumnType("timestamp with time zone");
                entity.Property(e => e.CustomerTaxes)
                    .HasColumnName("CustomerTaxes")
                    .HasColumnType("numeric(15,6)");
                entity.Property(e => e.InternalReference).HasColumnName("InternalReference");
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("Name");
                entity.Property(e => e.ProductType).HasColumnName("ProductType");
                entity.Property(e => e.SalesPrice)
                    .HasColumnName("SalesPrice")
                    .HasColumnType("numeric(15,6)");
                entity.Property(e => e.UpdatedBy)
                    .IsRequired()
                    .HasColumnName("UpdatedBy");
                entity.Property(e => e.UpdatedDate)
                    .HasColumnName("UpdatedDate")
                    .HasColumnType("timestamp with time zone");
            });
            #endregion

            #region Supplement Model Building
            modelBuilder.Entity<Supplement>(entity =>
            {
                entity.ToTable("Supplement");
                entity.Property(e => e.SupplementId).HasColumnName("SupplementId");
                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("CreatedBy");
                entity.Property(e => e.CreatedDate)
                    .HasColumnName("CreatedDate")
                    .HasColumnType("timestamp with time zone");
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("Name");
                entity.Property(e => e.SupplementCategoryId)
                    .HasColumnName("SupplementCategoryId")
                    .ValueGeneratedOnAdd();
                entity.Property(e => e.UpdatedBy)
                    .IsRequired()
                    .HasColumnName("UpdatedBy");
                entity.Property(e => e.UpdatedDate)
                    .HasColumnName("UpdatedDate")
                    .HasColumnType("timestamp with time zone");
                entity.HasOne(d => d.SupplementCategory)
                    .WithMany(p => p.Supplements)
                    .HasForeignKey(d => d.SupplementCategoryId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("fk_supplement_supplementcategory");
            });
            #endregion

            #region Supplement Category Model Building
            modelBuilder.Entity<SupplementCategory>(entity =>
            {
                entity.ToTable("SupplementCategory");
                entity.Property(e => e.SupplementCategoryId).HasColumnName("SupplementCategoryId");
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("Name");
            });
            #endregion

            modelBuilder.HasSequence("contractproductsupplementpric_contractproductsupplementpric_seq");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ООО_Ткани.Models
{
    public partial class db_demoexalov5Context : DbContext
    {
        public static db_demoexalov5Context DbContext { get; private set; } = new db_demoexalov5Context();

        public db_demoexalov5Context()
        {
        }

        public db_demoexalov5Context(DbContextOptions<db_demoexalov5Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Cities> Cities { get; set; }
        public virtual DbSet<Manufracturer> Manufracturer { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Orderproduct> Orderproduct { get; set; }
        public virtual DbSet<Pickuppoint> Pickuppoint { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Productunit> Productunit { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Suppliers> Suppliers { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=localhost;user=root;database=db_demoexalov5;password=1234", x => x.ServerVersion("8.0.25-mysql")).UseLazyLoadingProxies();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.IdCategory)
                    .HasName("PRIMARY");

                entity.ToTable("category");

                entity.Property(e => e.IdCategory).HasColumnName("idCategory");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Cities>(entity =>
            {
                entity.HasKey(e => e.IdCities)
                    .HasName("PRIMARY");

                entity.ToTable("cities");

                entity.Property(e => e.IdCities).HasColumnName("idCities");

                entity.Property(e => e.CityName)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Manufracturer>(entity =>
            {
                entity.HasKey(e => e.IdManufracturer)
                    .HasName("PRIMARY");

                entity.ToTable("manufracturer");

                entity.Property(e => e.IdManufracturer).HasColumnName("idManufracturer");

                entity.Property(e => e.ManufracturerName)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("order");

                entity.HasIndex(e => e.OrderStatusId)
                    .HasName("Order_Status_FK_idx");

                entity.HasIndex(e => e.OrderUserId)
                    .HasName("Order_User_FK_idx");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.OrderCode)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.OrderDeliveryDate).HasColumnType("datetime");

                entity.Property(e => e.OrderPickupPoint)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.OrderStatusId).HasColumnName("OrderStatusID");

                entity.Property(e => e.OrderUserId).HasColumnName("OrderUserID");

                entity.HasOne(d => d.OrderStatus)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.OrderStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Order_Status_FK");

                entity.HasOne(d => d.OrderUser)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.OrderUserId)
                    .HasConstraintName("Order_User_FK");
            });

            modelBuilder.Entity<Orderproduct>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.ProductArticleNumber })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("orderproduct");

                entity.HasIndex(e => e.ProductArticleNumber)
                    .HasName("ProductArticleNumber");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.ProductArticleNumber)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Count).HasColumnName("count");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Orderproduct)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("orderproduct_ibfk_1");

                entity.HasOne(d => d.ProductArticleNumberNavigation)
                    .WithMany(p => p.Orderproduct)
                    .HasForeignKey(d => d.ProductArticleNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("orderproduct_ibfk_2");
            });

            modelBuilder.Entity<Pickuppoint>(entity =>
            {
                entity.HasKey(e => e.IdPickupPoint)
                    .HasName("PRIMARY");

                entity.ToTable("pickuppoint");

                entity.HasIndex(e => e.IdCitiy)
                    .HasName("PickupPoint_Cities_FK_idx");

                entity.Property(e => e.IdPickupPoint).HasColumnName("idPickupPoint");

                entity.Property(e => e.IdCitiy).HasColumnName("idCitiy");

                entity.Property(e => e.Index)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.IdCitiyNavigation)
                    .WithMany(p => p.Pickuppoint)
                    .HasForeignKey(d => d.IdCitiy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PickupPoint_Cities_FK");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProductArticleNumber)
                    .HasName("PRIMARY");

                entity.ToTable("product");

                entity.HasIndex(e => e.ProductCategoryId)
                    .HasName("Product_Category_FK_idx");

                entity.HasIndex(e => e.ProductManufacturerId)
                    .HasName("Product_Manufracturer_FK_idx");

                entity.HasIndex(e => e.ProductSupplierId)
                    .HasName("Product_Supplier_FK_idx");

                entity.HasIndex(e => e.ProductUnitId)
                    .HasName("Product_Unit_FK_idx");

                entity.Property(e => e.ProductArticleNumber)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ProductCategoryId).HasColumnName("ProductCategoryID");

                entity.Property(e => e.ProductCost).HasColumnType("decimal(19,4)");

                entity.Property(e => e.ProductDescription)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.ProductManufacturerId).HasColumnName("ProductManufacturerID");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.ProductPhoto)
                    .IsRequired()
                    .HasColumnType("varchar(150)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.ProductSupplierId).HasColumnName("ProductSupplierID");

                entity.Property(e => e.ProductUnitId).HasColumnName("ProductUnitID");

                entity.HasOne(d => d.ProductCategory)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.ProductCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Product_Category_FK");

                entity.HasOne(d => d.ProductManufacturer)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.ProductManufacturerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Product_Manufracturer_FK");

                entity.HasOne(d => d.ProductSupplier)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.ProductSupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Product_Supplier_FK");

                entity.HasOne(d => d.ProductUnit)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.ProductUnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Product_Unit_FK");
            });

            modelBuilder.Entity<Productunit>(entity =>
            {
                entity.HasKey(e => e.IdProductUnit)
                    .HasName("PRIMARY");

                entity.ToTable("productunit");

                entity.Property(e => e.IdProductUnit).HasColumnName("idProductUnit");

                entity.Property(e => e.UnitName)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("role");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.HasKey(e => e.IdStatus)
                    .HasName("PRIMARY");

                entity.ToTable("status");

                entity.Property(e => e.IdStatus).HasColumnName("idStatus");

                entity.Property(e => e.StatusName)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Suppliers>(entity =>
            {
                entity.HasKey(e => e.IdSuppliers)
                    .HasName("PRIMARY");

                entity.ToTable("suppliers");

                entity.Property(e => e.IdSuppliers).HasColumnName("idSuppliers");

                entity.Property(e => e.SupplierName)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.HasIndex(e => e.UserRole)
                    .HasName("UserRole");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.UserLogin)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.UserPatronymic)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.UserSurname)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.UserRoleNavigation)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.UserRole)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_ibfk_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

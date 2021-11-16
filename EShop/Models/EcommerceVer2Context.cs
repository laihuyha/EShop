using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace EShop.Models
{
    public partial class EcommerceVer2Context : DbContext
    {
        public EcommerceVer2Context()
        {
        }

        public EcommerceVer2Context(DbContextOptions<EcommerceVer2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Attribute> Attributes { get; set; }
        public virtual DbSet<AttributePrice> AttributePrices { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Shipper> Shippers { get; set; }
        public virtual DbSet<TransactStatus> TransactStatuses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=EcommerceVer2;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("Account");

                entity.HasIndex(e => e.CartId, "IX_Account_CartID");

                entity.HasIndex(e => e.RoleId, "IX_Account_RoleId");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.CartId).HasColumnName("CartID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.LastLogin).HasColumnType("datetime");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Cart)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.CartId)
                    .HasConstraintName("FK_Account_Cart1");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_Account_Roles");
            });

            modelBuilder.Entity<Attribute>(entity =>
            {
                entity.ToTable("Attribute");

                entity.Property(e => e.AttributeId).HasColumnName("AttributeID");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<AttributePrice>(entity =>
            {
                entity.HasIndex(e => e.AttributeId, "IX_AttributePrices_AttributeID");

                entity.HasIndex(e => e.ProductId, "IX_AttributePrices_ProductID");

                entity.Property(e => e.AttributePriceId).HasColumnName("AttributePriceID");

                entity.Property(e => e.AttributeId).HasColumnName("AttributeID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.HasOne(d => d.Attribute)
                    .WithMany(p => p.AttributePrices)
                    .HasForeignKey(d => d.AttributeId)
                    .HasConstraintName("FK_AttributePrices_Attribute");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.AttributePrices)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_AttributePrices_Product");
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.ToTable("Cart");

                entity.Property(e => e.CartId).HasColumnName("CartID");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.CateId);

                entity.ToTable("Category");

                entity.Property(e => e.CateId).HasColumnName("CateID");

                entity.Property(e => e.Alias).HasMaxLength(250);

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Cover).HasMaxLength(255);

                entity.Property(e => e.Descriptions).HasMaxLength(250);

                entity.Property(e => e.IsPublished)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.ThumbImg).HasMaxLength(250);

                entity.Property(e => e.Title).HasMaxLength(200);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustommerId);

                entity.Property(e => e.CustommerId).HasColumnName("CustommerID");

                entity.Property(e => e.Avatar).HasMaxLength(250);

                entity.Property(e => e.BirthDay).HasColumnType("datetime");

                entity.Property(e => e.CartId).HasColumnName("CartID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.LastLogin).HasColumnType("datetime");

                entity.Property(e => e.Phone)
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.HasOne(d => d.Cart)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.CartId)
                    .HasConstraintName("FK_Customers_Cart");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.HasIndex(e => e.CustomerId, "IX_Order_CustomerID");

                entity.HasIndex(e => e.TransactionStatusId, "IX_Order_TransactionStatusID");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('0001-01-01T00:00:00.000')");

                entity.Property(e => e.PaymentDate).HasColumnType("datetime");

                entity.Property(e => e.PaymentId).HasColumnName("PaymentID");

                entity.Property(e => e.ShipDate).HasColumnType("datetime");

                entity.Property(e => e.TransactionStatusId).HasColumnName("TransactionStatusID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Order_Customers");

                entity.HasOne(d => d.TransactionStatus)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.TransactionStatusId)
                    .HasConstraintName("FK_Order_TransactStatus");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasIndex(e => e.OrderId, "IX_OrderDetails_OrderID");

                entity.Property(e => e.OrderDetailId).HasColumnName("OrderDetailID");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.Shipdate).HasColumnType("datetime");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_OrderDetails_Order");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_OrderDetails_Product");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.HasIndex(e => e.CateId, "IX_Product_CateID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.CateId).HasColumnName("CateID");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.Descriptions).HasMaxLength(255);

                entity.Property(e => e.Homeflag)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.ShortDesc).HasMaxLength(255);

                entity.HasOne(d => d.Cate)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CateId)
                    .HasConstraintName("FK_Product_Category");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Descriptions)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.RoleName).HasMaxLength(50);
            });

            modelBuilder.Entity<Shipper>(entity =>
            {
                entity.ToTable("Shipper");

                entity.Property(e => e.ShipperId).HasColumnName("ShipperID");

                entity.Property(e => e.Company).HasMaxLength(255);

                entity.Property(e => e.Phone)
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.Shipdate).HasColumnType("datetime");

                entity.Property(e => e.ShipperName).HasMaxLength(200);
            });

            modelBuilder.Entity<TransactStatus>(entity =>
            {
                entity.HasKey(e => e.TransactionStatusId);

                entity.ToTable("TransactStatus");

                entity.Property(e => e.TransactionStatusId)
                    .ValueGeneratedNever()
                    .HasColumnName("TransactionStatusID");

                entity.Property(e => e.Descriptions).HasMaxLength(50);

                entity.Property(e => e.Status).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

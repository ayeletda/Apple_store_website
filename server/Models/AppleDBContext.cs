using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace server.Models
{
    public partial class AppleDBContext : DbContext
    {
        public AppleDBContext()
        {
        }

        public AppleDBContext(DbContextOptions<AppleDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MacIpadIphoneProduct> MacIpadIphoneProducts { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Sale> Sales { get; set; } = null!;
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; } = null!;
        public virtual DbSet<ShoppingCartProduct> ShoppingCartProducts { get; set; } = null!;
        public virtual DbSet<ShoppingHistory> ShoppingHistories { get; set; } = null!;
        public virtual DbSet<ShoppingHistoryProduct> ShoppingHistoryProducts { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<WatchAirpodsProduct> WatchAirpodsProducts { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=AppleDB;Trusted_Connection=False;password=<YourStrong@Passw0rd>;user=SA;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MacIpadIphoneProduct>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Color)
                    .HasMaxLength(50)
                    .HasColumnName("color");

                entity.Property(e => e.Memory)
                    .HasMaxLength(50)
                    .HasColumnName("memory");

                entity.Property(e => e.ProductId).HasColumnName("productId");

                entity.Property(e => e.ScreenSize)
                    .HasMaxLength(50)
                    .HasColumnName("screenSize");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.MacIpadIphoneProducts)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MacIpadIp__produ__3D5E1FD2");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Category)
                    .HasMaxLength(50)
                    .HasColumnName("category");

                entity.Property(e => e.Details)
                    .HasMaxLength(1000)
                    .HasColumnName("details");

                entity.Property(e => e.NameProduct)
                    .HasMaxLength(50)
                    .HasColumnName("nameProduct");

                entity.Property(e => e.NewFlag).HasColumnName("newFlag");

                entity.Property(e => e.PictureUrl)
                    .HasMaxLength(1000)
                    .HasColumnName("pictureURL");

                entity.Property(e => e.Price).HasColumnName("price");
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ProductId).HasColumnName("productId");

                entity.Property(e => e.SalePrice).HasColumnName("salePrice");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Sales__productId__4316F928");
            });

            modelBuilder.Entity<ShoppingCart>(entity =>
            {
                entity.ToTable("ShoppingCart");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AllProductsAmount).HasColumnName("allProductsAmount");

                entity.Property(e => e.FinalPrice).HasColumnName("finalPrice");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ShoppingCarts)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ShoppingC__userI__45F365D3");
            });

            modelBuilder.Entity<ShoppingCartProduct>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ProductAmount).HasColumnName("productAmount");

                entity.Property(e => e.ProductId).HasColumnName("productId");

                entity.Property(e => e.ShoppingCartId).HasColumnName("shoppingCartId");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ShoppingCartProducts)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ShoppingC__produ__49C3F6B7");

                entity.HasOne(d => d.ShoppingCart)
                    .WithMany(p => p.ShoppingCartProducts)
                    .HasForeignKey(d => d.ShoppingCartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ShoppingC__shopp__48CFD27E");
            });

            modelBuilder.Entity<ShoppingHistory>(entity =>
            {
                entity.ToTable("ShoppingHistory");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AllProductsAmount).HasColumnName("allProductsAmount");

                entity.Property(e => e.FinalPrice).HasColumnName("finalPrice");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ShoppingHistories)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ShoppingH__userI__4CA06362");
            });

            modelBuilder.Entity<ShoppingHistoryProduct>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ProductAmount).HasColumnName("productAmount");

                entity.Property(e => e.ProductId).HasColumnName("productId");

                entity.Property(e => e.ShoppingHistoryId).HasColumnName("shoppingHistoryId");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ShoppingHistoryProducts)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ShoppingH__produ__5070F446");

                entity.HasOne(d => d.ShoppingHistory)
                    .WithMany(p => p.ShoppingHistoryProducts)
                    .HasForeignKey(d => d.ShoppingHistoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ShoppingH__shopp__4F7CD00D");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Username, "UQ__Users__F3DBC572EAF56AC3")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Birthday)
                    .HasColumnType("date")
                    .HasColumnName("birthday")
                    .HasDefaultValueSql("(CONVERT([date],getdate(),(105)))");

                entity.Property(e => e.FisrtName)
                    .HasMaxLength(50)
                    .HasColumnName("fisrtName");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .HasColumnName("lastName");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(15)
                    .HasColumnName("phoneNumber");

                entity.Property(e => e.Token)
                    .HasMaxLength(200)
                    .HasColumnName("token");

                entity.Property(e => e.UserPassword)
                    .HasMaxLength(50)
                    .HasColumnName("userPassword");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<WatchAirpodsProduct>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Color)
                    .HasMaxLength(50)
                    .HasColumnName("color");

                entity.Property(e => e.ProductId).HasColumnName("productId");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.WatchAirpodsProducts)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__WatchAirp__produ__403A8C7D");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

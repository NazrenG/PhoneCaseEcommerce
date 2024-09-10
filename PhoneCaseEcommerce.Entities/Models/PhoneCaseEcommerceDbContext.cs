using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PhoneCaseEcommerce.Entities.Models;

public partial class PhoneCaseEcommerceDbContext : DbContext
{
    public PhoneCaseEcommerceDbContext()
    {
    }

    public PhoneCaseEcommerceDbContext(DbContextOptions<PhoneCaseEcommerceDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<Color> Colors { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Favorite> Favorites { get; set; }

    public virtual DbSet<Model> Models { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<PhoneCase> PhoneCases { get; set; }

    public virtual DbSet<PhoneColor> PhoneColors { get; set; }

    public virtual DbSet<PhotoImage> PhotoImages { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserImage> UserImages { get; set; }

    public virtual DbSet<Vendor> Vendors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PhoneCaseECommerceDB;Integrated Security=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cart__3214EC071F8C1D69");

            entity.ToTable("Cart");

            entity.Property(e => e.Quantity).HasDefaultValue(0);

            entity.HasOne(d => d.PhoneCase).WithMany(p => p.Carts)
                .HasForeignKey(d => d.PhoneCaseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Cart__PhoneCaseI__5FB337D6");

            entity.HasOne(d => d.User).WithMany(p => p.Carts)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Cart__UserId__5EBF139D");
        });

        modelBuilder.Entity<Color>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Colors__3214EC07A5C8477E");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Comments__3214EC07155F73D1");

            entity.HasOne(d => d.PhoneCase).WithMany(p => p.Comments)
                .HasForeignKey(d => d.PhoneCaseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Comments__PhoneC__5165187F");

            entity.HasOne(d => d.User).WithMany(p => p.Comments)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Comments__UserId__52593CB8");
        });

        modelBuilder.Entity<Favorite>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Favorite__3214EC0798DA10ED");

            entity.HasOne(d => d.PhoneCase).WithMany(p => p.Favorites)
                .HasForeignKey(d => d.PhoneCaseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Favorites__Phone__5535A963");
        });

        modelBuilder.Entity<Model>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Models__3214EC07E0721634");

            entity.HasOne(d => d.Vendor).WithMany(p => p.Models)
                .HasForeignKey(d => d.VendorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Models__VendorId__3A81B327");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Orders__3214EC07D8C9EBC5");

            entity.Property(e => e.OrderStatus).HasMaxLength(50);
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrderDet__3214EC07C711508A");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderDeta__Order__59FA5E80");

            entity.HasOne(d => d.PhoneCase).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.PhoneCaseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderDeta__Phone__5AEE82B9");
        });

        modelBuilder.Entity<PhoneCase>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PhoneCas__3214EC07D9FE143C");

            entity.Property(e => e.Premium)
                .HasMaxLength(20)
                .HasDefaultValue("Simple");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.SellCount).HasDefaultValue(0);

            entity.HasOne(d => d.Model).WithMany(p => p.PhoneCases)
                .HasForeignKey(d => d.ModelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PhoneCase__Model__46E78A0C");

            entity.HasOne(d => d.User).WithMany(p => p.PhoneCases)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PhoneCase__UserI__47DBAE45");

            entity.HasOne(d => d.Vendor).WithMany(p => p.PhoneCases)
                .HasForeignKey(d => d.VendorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PhoneCase__Vendo__45F365D3");
        });

        modelBuilder.Entity<PhoneColor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PhoneCol__3214EC07F31D0FEE");

            entity.HasOne(d => d.Color).WithMany(p => p.PhoneColors)
                .HasForeignKey(d => d.ColorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PhoneColo__Color__4E88ABD4");

            entity.HasOne(d => d.PhoneCase).WithMany(p => p.PhoneColors)
                .HasForeignKey(d => d.PhoneCaseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PhoneColo__Phone__4D94879B");
        });

        modelBuilder.Entity<PhotoImage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PhotoIma__3214EC0787A656C9");

            entity.HasOne(d => d.PhoneCase).WithMany(p => p.PhotoImages)
                .HasForeignKey(d => d.PhoneCaseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PhotoImag__Phone__4AB81AF0");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC07B9C0DEFC");

            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UserImage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserImag__3214EC078C88E55D");

            entity.HasOne(d => d.User).WithMany(p => p.UserImages)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UserImage__UserI__403A8C7D");
        });

        modelBuilder.Entity<Vendor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Vendors__3214EC0792E6B697");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

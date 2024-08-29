using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DotnetStockApi.Models;

//DbContext จะเจนตารางเท่าที่มีในโมเดล
//IdentityDbContext<IdentityUser> จะเจนตารางเท่าที่มีในโมเดลและอีก7ตารางไปด้วย
public partial class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Product> Products { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder); //เพื่อที่่ว่าครั้งแรกที่ยังไม่ถูกเจน จะได้ไม่ต้องแจ้งเตือนอะไรออกมา
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Categoryid).HasName("PK__category__23CDE590E7291D82");

            entity.ToTable("category");

            entity.Property(e => e.Categoryid)
                .ValueGeneratedNever()
                .HasColumnName("categoryid");
            entity.Property(e => e.Categoryname)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("categoryname");
            entity.Property(e => e.Categorystatus).HasColumnName("categorystatus");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Productid).HasName("PK__product__2D172D32F33AA539");

            entity.ToTable("product");

            entity.Property(e => e.Productid)
                .ValueGeneratedNever()
                .HasColumnName("productid");
            entity.Property(e => e.Categoryid).HasColumnName("categoryid");
            entity.Property(e => e.Createddate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createddate");
            entity.Property(e => e.Modifieddate)
                .HasColumnType("datetime")
                .HasColumnName("modifieddate");
            entity.Property(e => e.Productname)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("productname");
            entity.Property(e => e.Productpicture)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasColumnName("productpicture");
            entity.Property(e => e.Unitinstock).HasColumnName("unitinstock");
            entity.Property(e => e.Unitprice)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("unitprice");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

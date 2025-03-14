﻿using Microsoft.EntityFrameworkCore;
using OnlineShop.entities;
using System.Net;

namespace OnlineShop.Data
{
    public class ApplicationDbContext : DbContext

    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
       : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<SellerInfo> SellerInfos { get; set; }
        public DbSet<ProductImages> ProductImages { get; set; }
      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId);
            
            modelBuilder.Entity<Product>()
                .HasOne(p => p.ProductCategory)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);
            
            modelBuilder.Entity<Product>() //todo:relation many to many,
               .HasOne(u => u.Brand)
               .WithMany(r => r.Products)
               .HasForeignKey(u => u.BrandId);


            modelBuilder.Entity<SellerInfo>()
               .HasOne(u => u.User)
               .WithMany(r => r.SellerInfos)
               .HasForeignKey(u => u.UserId);

            modelBuilder.Entity<ProductImages>()
                .HasOne(u => u.Product)
                .WithMany(r => r.ProductImages)
                .HasForeignKey(u => u.ProductId);

            base.OnModelCreating(modelBuilder);
        }
       

    }

}

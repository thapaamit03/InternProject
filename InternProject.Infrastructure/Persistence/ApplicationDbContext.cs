using InternProject.Domain.Models;
using InternProject.Infrastructure.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Text;

    namespace InternProject.Infrastructure.Data
    {
        public class ApplicationDbContext:IdentityDbContext<ApplicationUser>
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
            {
            
            }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Cart> Carts { get; set; }

        public DbSet<CartItem> CartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<RefreshToken>()
                .HasOne<ApplicationUser>()
                .WithMany()
                .HasForeignKey(x => x.UserId);

            builder.Entity<Product>()
               .HasOne(x => x.Category)
               .WithMany(x => x.Products)
               .HasForeignKey(x => x.CategoryId);

            builder.Entity<Product>()
                .Property(p => p.Price)
                .HasPrecision(10, 2);

            builder.Entity<Cart>()
                .HasMany(c => c.CartItems)
                .WithOne(ci => ci.Cart)
                .HasForeignKey(ci => ci.CartId);
        }
        }
    }

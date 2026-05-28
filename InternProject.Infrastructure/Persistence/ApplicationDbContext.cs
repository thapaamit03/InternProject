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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<RefreshToken>()
                .HasOne<ApplicationUser>()
                .WithMany()
                .HasForeignKey(x => x.UserId);
        }
        }
    }

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer
{
    public class StorageContext: DbContext
    {
        public StorageContext(DbContextOptions<StorageContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Schema> Schemas { get; set; }
        public DbSet<Stitch> Stitches { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<SchemaStitch> SchemaStitches { get; set; }
        public DbSet<SchemaImage> SchemaImages { get; set; }
        public DbSet<SchemaFile> SchemaFiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .ToTable("Users")
                .HasKey(c => c.Id);
            modelBuilder.Entity<User>()
                .Property(c => c.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Role>()
                .ToTable("Roles")
                .Property(c => c.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Role>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<UserRole>()
                .ToTable("UserRoles")
                .HasKey(c => new { c.UserId, c.RoleId });
            modelBuilder.Entity<UserRole>()
                .HasOne(c => c.User)
                .WithMany(c => c.UserRoles)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<UserRole>()
                .HasOne(c => c.Role)
                .WithMany(c => c.UserRoles)
                .HasForeignKey(c => c.RoleId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Schema>()
                .ToTable("Schemas")
                .HasKey(c => c.Id);
            modelBuilder.Entity<Schema>()
                .Property(c => c.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Schema>()
                .HasMany(c => c.Files)
                .WithOne()
                .HasForeignKey(c => c.SchemaId);
            modelBuilder.Entity<Schema>()
                .HasMany(c => c.Images)
                .WithOne()
                .HasForeignKey(c => c.SchemaId);
            modelBuilder.Entity<Schema>()
                .HasOne(c => c.Author)
                .WithMany()
                .HasForeignKey(c => c.AuthorId);

            modelBuilder.Entity<Stitch>()
                .ToTable("Stitches")
                .HasKey(c => c.Id);
            modelBuilder.Entity<Stitch>()
                .Property(c => c.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<SchemaStitch>()
                .ToTable("SchemaStitch")
                .HasKey(c => new { c.SchemaId, c.StitchId });
            modelBuilder.Entity<SchemaStitch>()
                .HasOne(c => c.Schema)
                .WithMany(c => c.SchemaStitches)
                .HasForeignKey(c => c.SchemaId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<SchemaStitch>()
                .HasOne(c => c.Stitch)
                .WithMany(c => c.SchemaStitches)
                .HasForeignKey(c => c.StitchId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Category>()
                .ToTable("Categories")
                .HasKey(c => c.Id);
            modelBuilder.Entity<Category>()
                .Property(c => c.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<SchemaCategory>()
                .ToTable("SchemaCategory")
                .HasKey(c => new { c.SchemaId, c.CategoryId });
            modelBuilder.Entity<SchemaCategory>()
                .HasOne(c => c.Schema)
                .WithMany(c => c.SchemaCategories)
                .HasForeignKey(c => c.SchemaId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<SchemaCategory>()
                .HasOne(c => c.Category)
                .WithMany(c => c.SchemaCategories)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SchemaFile>()
                .ToTable("SchemaFiles")
                .HasKey(c => c.Id);
            modelBuilder.Entity<SchemaFile>()
                .Property(c => c.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<SchemaImage>()
                .ToTable("SchemaImages")
                .HasKey(c => c.Id);
            modelBuilder.Entity<SchemaFile>()
                .Property(c => c.Id)
                .ValueGeneratedOnAdd();
        }
    }
}

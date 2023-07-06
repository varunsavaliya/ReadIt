using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ReadIt.Models;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbBlog> TbBlogs { get; set; }

    public virtual DbSet<TbBlogMedium> TbBlogMedia { get; set; }

    public virtual DbSet<TbCategory> TbCategories { get; set; }

    public virtual DbSet<TbComment> TbComments { get; set; }

    public virtual DbSet<TbUser> TbUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:ReadIt");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbBlog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Blog");

            entity.ToTable("tbBlogs");

            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description)
                .IsRequired()
                .IsUnicode(false);
            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            entity.Property(e => e.Tags).IsUnicode(false);
            entity.Property(e => e.Title)
                .IsRequired()
                .IsUnicode(false);
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

            entity.HasOne(d => d.Category).WithMany(p => p.TbBlogs)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Category_CategoryId");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.TbBlogs)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_UserId");
        });

        modelBuilder.Entity<TbBlogMedium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_BlogMedia");

            entity.ToTable("tbBlogMedia");

            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            entity.Property(e => e.MediaPath)
                .IsRequired()
                .IsUnicode(false);
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

            entity.HasOne(d => d.Blog).WithMany(p => p.TbBlogMedia)
                .HasForeignKey(d => d.BlogId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tbBlogMedia_tbBlog_Id");
        });

        modelBuilder.Entity<TbCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Categories");

            entity.ToTable("tbCategories");

            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
        });

        modelBuilder.Entity<TbComment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Comments");

            entity.ToTable("tbComments");

            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IsActive)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Text)
                .IsRequired()
                .IsUnicode(false);
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.Website)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("website");

            entity.HasOne(d => d.Blog).WithMany(p => p.TbComments)
                .HasForeignKey(d => d.BlogId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Blog_BlogId");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.TbComments)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK_Comments_User_UserId");
        });

        modelBuilder.Entity<TbUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Users");

            entity.ToTable("tbUsers");

            entity.Property(e => e.Avatar).IsUnicode(false);
            entity.Property(e => e.Bio).IsUnicode(false);
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email)
                .IsRequired()
                .IsUnicode(false);
            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

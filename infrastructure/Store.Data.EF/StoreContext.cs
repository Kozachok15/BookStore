using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Store.Entities;

namespace Store.Data.EF
{
    public partial class StoreContext : DbContext
    {
        public StoreContext()
        {
        }

        public StoreContext(DbContextOptions<StoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AuthorEF> Authors { get; set; } = null!;
        public virtual DbSet<BookEF> Books { get; set; } = null!;
        public virtual DbSet<ClientEF> Clients { get; set; } = null!;
        public virtual DbSet<OrderEF> Orders { get; set; } = null!;
        public virtual DbSet<OrderBookEF> OrderBooks { get; set; } = null!;
        public virtual DbSet<PublisherEF> Publishers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-23SNJ6U\\SQLEXPRESS; Initial Catalog=Store; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuthorEF>(entity =>
            {
                entity.ToTable("Author");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FullName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("full_name");
            });

            modelBuilder.Entity<Entities.BookEF>(entity =>
            {
                entity.ToTable("Book");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AuthorId).HasColumnName("author_id");

                entity.Property<string>(e => e.DescriptionOf)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("description_of");

                entity.Property<byte[]>(e => e.ImageOf).HasColumnName("image_of");

                entity.Property(e => e.IsbnOf)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("isbn_of");

                entity.Property(e => e.PriceOf)
                    .HasColumnType("decimal(16, 2)")
                    .HasColumnName("price_of");

                entity.Property(e => e.PublisherId).HasColumnName("publisher_id");

                entity.Property(e => e.TitleOf)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("title_of");

                entity.Property(e => e.GenreOf)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("genre_of");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Book__author_id__4D94879B");

                entity.HasOne(d => d.Publisher)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.PublisherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Book__publisher___4E88ABD4");
            });

            modelBuilder.Entity<ClientEF>(entity =>
            {
                entity.ToTable("Client");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Adres)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("adres");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("firstName");

                entity.Property(e => e.LastName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("lastName");

                entity.Property(e => e.Phone).HasColumnName("phone");
            });

            modelBuilder.Entity<OrderEF>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("date")
                    .HasColumnName("create_date");

                entity.Property(e => e.Status)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders__client_i__534D60F1");
            });

            modelBuilder.Entity<OrderBookEF>(entity =>
            {
                entity.ToTable("OrderBook");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BookId).HasColumnName("book_id");

                entity.Property(e => e.CountOf).HasColumnName("count_of");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.OrderBooks)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderBook__book___5629CD9C");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderBooks)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderBook__order__571DF1D5");
            });

            modelBuilder.Entity<PublisherEF>(entity =>
            {
                entity.ToTable("Publisher");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.NameOf)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("name_of");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

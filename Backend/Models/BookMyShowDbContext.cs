using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BookMyShow.Models
{
    public partial class BookMyShowDbContext : DbContext
    {
        public BookMyShowDbContext()
        {
        }

        public BookMyShowDbContext(DbContextOptions<BookMyShowDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MovieDetail> MovieDetails { get; set; } = null!;
        public virtual DbSet<MovieShowsList> MovieShowsLists { get; set; } = null!;
        public virtual DbSet<SeatDetail> SeatDetails { get; set; } = null!;
        public virtual DbSet<Theatre> Theatres { get; set; } = null!;
        public virtual DbSet<Ticket> Tickets { get; set; } = null!;
        public virtual DbSet<UserDetail> UserDetails { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=IRON-MAN\\SQLEXPRESS;Database=BookMyShowDb;User ID=Rahman;Password=123456789;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieDetail>(entity =>
            {
                entity.ToTable("MovieDetail");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Duration)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Genre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Language)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Poster)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.CoverPhoto)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Rating)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ReleaseDate).HasColumnType("date");

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MovieShowsList>(entity =>
            {
                entity.ToTable("MovieShowsList");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.EndTime).HasColumnType("date");

                entity.Property(e => e.StartTime).HasColumnType("date");
            });

            modelBuilder.Entity<SeatDetail>(entity =>
            {
                entity.ToTable("SeatDetail");

                entity.Property(e => e.SeatNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SeatType)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Theatre>(entity =>
            {
                entity.ToTable("Theatre");

                entity.Property(e => e.Address)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.ToTable("Ticket");

                entity.Property(e => e.ShowTime).HasColumnType("date");
            });

            modelBuilder.Entity<UserDetail>(entity =>
            {
                entity.ToTable("UserDetail");

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(13)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

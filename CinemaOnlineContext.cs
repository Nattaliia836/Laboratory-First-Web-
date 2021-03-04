using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebApplication2
{
    public partial class CinemaOnlineContext : DbContext
    {
        public CinemaOnlineContext()
        {
        }

        public CinemaOnlineContext(DbContextOptions<CinemaOnlineContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actor> Actors { get; set; }
        public virtual DbSet<ActorPlay> ActorPlays { get; set; }
        public virtual DbSet<Creator> Creators { get; set; }
        public virtual DbSet<CreattionFilm> CreattionFilms { get; set; }
        public virtual DbSet<Film> Films { get; set; }
        public virtual DbSet<Response> Responses { get; set; }
        public virtual DbSet<Selection> Selections { get; set; }
        public virtual DbSet<SortSelection> SortSelections { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server= DESKTOP-S9I2UP3; Database=CinemaOnline; Trusted_Connection=True; ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Actor>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.BirthDate)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Info).HasColumnType("text");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<ActorPlay>(entity =>
            {
                entity.ToTable("ActorPlay");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsFixedLength(true);

                entity.HasOne(d => d.Actor)
                    .WithMany(p => p.ActorPlays)
                    .HasForeignKey(d => d.ActorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActorPlay_Actors");

                entity.HasOne(d => d.Film)
                    .WithMany(p => p.ActorPlays)
                    .HasForeignKey(d => d.FilmId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActorPlay_Films");
            });

            modelBuilder.Entity<Creator>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Info).HasColumnType("text");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<CreattionFilm>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Profession)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.HasOne(d => d.Creator)
                    .WithMany(p => p.CreattionFilms)
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CreattionFilms_Creators");

                entity.HasOne(d => d.Film)
                    .WithMany(p => p.CreattionFilms)
                    .HasForeignKey(d => d.FilmId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CreattionFilms_Films");
            });

            modelBuilder.Entity<Film>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Duration)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsFixedLength(true);

                entity.Property(e => e.YearRelease)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Response>(entity =>
            {
                entity.ToTable("Response");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DataResponse)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsFixedLength(true);

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsFixedLength(true);

                entity.HasOne(d => d.Film)
                    .WithMany(p => p.Responses)
                    .HasForeignKey(d => d.FilmId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Response_Films");
            });

            modelBuilder.Entity<Selection>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Info)
                    .HasMaxLength(300)
                    .IsFixedLength(true);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<SortSelection>(entity =>
            {
                entity.ToTable("SortSelection");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Genre)
                    .HasMaxLength(50)
                    .IsFixedLength(true);

                entity.Property(e => e.SortingInfo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsFixedLength(true);

                entity.HasOne(d => d.Film)
                    .WithMany(p => p.SortSelections)
                    .HasForeignKey(d => d.FilmId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SortSelection_Films");

                entity.HasOne(d => d.Selection)
                    .WithMany(p => p.SortSelections)
                    .HasForeignKey(d => d.SelectionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SortSelection_Selections");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

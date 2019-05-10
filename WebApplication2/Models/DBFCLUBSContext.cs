using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication2.Models
{
    public partial class DBFCLUBSContext : DbContext
    {
        public DBFCLUBSContext()
        {
        }

        public DBFCLUBSContext(DbContextOptions<DBFCLUBSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ClubHasTitle> ClubHasTitle { get; set; }
        public virtual DbSet<Clubs> Clubs { get; set; }
        public virtual DbSet<Contracts> Contracts { get; set; }
        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<Federations> Federations { get; set; }
        public virtual DbSet<Leagues> Leagues { get; set; }
        public virtual DbSet<PlayerHasTitle> PlayerHasTitle { get; set; }
        public virtual DbSet<Players> Players { get; set; }
        public virtual DbSet<Titles> Titles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-4KNP2S4\\SQLEXPRESS;Database=DBFCLUBS;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<ClubHasTitle>(entity =>
            {
                entity.HasKey(e => e.ClubAndTitleId);

                entity.Property(e => e.ClubAndTitleId)
                    .HasColumnName("ClubAndTitleID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ClubId).HasColumnName("ClubID");

                entity.Property(e => e.DateOfAcquisition)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.TitleId).HasColumnName("TitleID");

                entity.HasOne(d => d.Club)
                    .WithMany(p => p.ClubHasTitle)
                    .HasForeignKey(d => d.ClubId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClubHasTitle_Club");

                entity.HasOne(d => d.Title)
                    .WithMany(p => p.ClubHasTitle)
                    .HasForeignKey(d => d.TitleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClubHasTitle_Title");
            });

            modelBuilder.Entity<Clubs>(entity =>
            {
                entity.HasKey(e => e.ClubId);

                entity.Property(e => e.ClubId).HasColumnName("ClubID");

                entity.Property(e => e.ClubName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.LeagueId).HasColumnName("LeagueID");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.League)
                    .WithMany(p => p.Clubs)
                    .HasForeignKey(d => d.LeagueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Clubs_Leagues");
            });

            modelBuilder.Entity<Contracts>(entity =>
            {
                entity.HasKey(e => e.ContractId);

                entity.Property(e => e.ContractId)
                    .HasColumnName("ContractID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AnnualSalary).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.ClubId).HasColumnName("ClubID");

                entity.Property(e => e.PlayerId).HasColumnName("PlayerID");

                entity.Property(e => e.ValidFrom).HasColumnType("date");

                entity.Property(e => e.ValidUntill).HasColumnType("date");

                entity.HasOne(d => d.Club)
                    .WithMany(p => p.Contracts)
                    .HasForeignKey(d => d.ClubId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Contracts_Clubs");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.Contracts)
                    .HasForeignKey(d => d.PlayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Contracts_Players");
            });

            modelBuilder.Entity<Countries>(entity =>
            {
                entity.HasKey(e => e.CountryId);

                entity.Property(e => e.CountryId)
                    .HasColumnName("CountryID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Countryname)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Federations>(entity =>
            {
                entity.HasKey(e => e.FederationId);

                entity.Property(e => e.FederationId)
                    .HasColumnName("FederationID")
                    .ValueGeneratedNever();

                entity.Property(e => e.FederationName)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Leagues>(entity =>
            {
                entity.HasKey(e => e.LeagueId);

                entity.Property(e => e.LeagueId).HasColumnName("LeagueID");

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.LeagueName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.NumberOfClplaces).HasColumnName("NumberOfCLPlaces");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Leagues)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Leagues_Countries");
            });

            modelBuilder.Entity<PlayerHasTitle>(entity =>
            {
                entity.HasKey(e => e.PlayerAndTitleId);

                entity.Property(e => e.PlayerAndTitleId)
                    .HasColumnName("PlayerAndTitleID")
                    .ValueGeneratedNever();

                entity.Property(e => e.DateOfAcquisition)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.PlayerId).HasColumnName("PlayerID");

                entity.Property(e => e.TitleId).HasColumnName("TitleID");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.PlayerHasTitle)
                    .HasForeignKey(d => d.PlayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PlayerHasTitle_Player");

                entity.HasOne(d => d.Title)
                    .WithMany(p => p.PlayerHasTitle)
                    .HasForeignKey(d => d.TitleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PlayerHasTitle_Title");
            });

            modelBuilder.Entity<Players>(entity =>
            {
                entity.HasKey(e => e.PlayerId);

                entity.Property(e => e.PlayerId).HasColumnName("PlayerID");

                entity.Property(e => e.ContractId).HasColumnName("ContractID");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.HeightCm).HasColumnName("HeightCM");

                entity.Property(e => e.PlayerName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Titles>(entity =>
            {
                entity.HasKey(e => e.TitleId);

                entity.Property(e => e.TitleId).HasColumnName("TitleID");

                entity.Property(e => e.FederationId).HasColumnName("FederationID");

                entity.Property(e => e.TitleName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.Federation)
                    .WithMany(p => p.Titles)
                    .HasForeignKey(d => d.FederationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Titles_Federation");
            });
        }
    }
}

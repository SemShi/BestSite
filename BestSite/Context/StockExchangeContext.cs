using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BestSite
{
    public partial class StockExchangeContext : DbContext
    {
        public StockExchangeContext()
        {
        }

        public StockExchangeContext(DbContextOptions<StockExchangeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Sharecertificate> Sharecertificates { get; set; } = null!;
        public virtual DbSet<Shareholder> Shareholders { get; set; } = null!;
        public virtual DbSet<Shareinfo> Shareinfos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=StockExchange;Username=postgres;Password=123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sharecertificate>(entity =>
            {
                entity.HasKey(e => e.ScId)
                    .HasName("sharecertificates_pkey");

                entity.ToTable("sharecertificates");

                entity.Property(e => e.ScId)
                    .HasColumnName("sc_id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.BuySharecount).HasColumnName("buy_sharecount");

                entity.Property(e => e.Buyinfo)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("buyinfo");

                entity.Property(e => e.Priceforone)
                    .HasPrecision(10, 2)
                    .HasColumnName("priceforone");

                entity.Property(e => e.Shareholderid).HasColumnName("shareholderid");

                entity.Property(e => e.Shareinfoid).HasColumnName("shareinfoid");

                entity.Property(e => e.Totalprice)
                    .HasPrecision(10, 2)
                    .HasColumnName("totalprice");

                entity.HasOne(d => d.Shareholder)
                    .WithMany(p => p.Sharecertificates)
                    .HasForeignKey(d => d.Shareholderid)
                    .HasConstraintName("sharecertificates_shareholderid_fkey");

                entity.HasOne(d => d.Shareinfo)
                    .WithMany(p => p.Sharecertificates)
                    .HasForeignKey(d => d.Shareinfoid)
                    .HasConstraintName("sharecertificates_shareinfoid_fkey");
            });

            modelBuilder.Entity<Shareholder>(entity =>
            {
                entity.HasKey(e => e.ShId)
                    .HasName("shareholder_pkey");

                entity.ToTable("shareholder");

                entity.Property(e => e.ShId)
                    .HasColumnName("sh_id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.BirthDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("birth_date");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .HasColumnName("city");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .HasColumnName("last_name");

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(50)
                    .HasColumnName("middle_name");

                entity.Property(e => e.PassportNumber)
                    .HasMaxLength(6)
                    .HasColumnName("passport_number")
                    .IsFixedLength();

                entity.Property(e => e.PassportSerial)
                    .HasMaxLength(5)
                    .HasColumnName("passport_serial")
                    .IsFixedLength();

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(11)
                    .HasColumnName("phone_number")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Shareinfo>(entity =>
            {
                entity.HasKey(e => e.SiId)
                    .HasName("shareinfo_pkey");

                entity.ToTable("shareinfo");

                entity.Property(e => e.SiId)
                    .HasColumnName("si_id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Issuer)
                    .HasMaxLength(50)
                    .HasColumnName("issuer");

                entity.Property(e => e.ShareAuthorizedcapital)
                    .HasPrecision(15, 2)
                    .HasColumnName("share_authorizedcapital");

                entity.Property(e => e.Sharecount).HasColumnName("sharecount");

                entity.Property(e => e.Shareissuedate)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("shareissuedate");

                entity.Property(e => e.Sharetype)
                    .HasMaxLength(25)
                    .HasColumnName("sharetype");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace UserServices.Models
{
    public partial class UserDbContext : DbContext
    {
        public UserDbContext()
        {
        }

        public UserDbContext(DbContextOptions<UserDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BookFlight> BookFlight { get; set; }
        public virtual DbSet<Flights> Flights { get; set; }
        public virtual DbSet<TicketBookingDetails> TicketBookingDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=ctsdotnet55;Database=UserDb;user id=sa; password=pass@word1;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookFlight>(entity =>
            {
                entity.HasKey(e => e.Userid);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.Meal)
                    .IsRequired()
                    .HasMaxLength(77);

                entity.Property(e => e.NOfSeats).HasColumnName("N_of_Seats");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Pnr).HasColumnName("PNR");
            });

            modelBuilder.Entity<Flights>(entity =>
            {
                entity.HasKey(e => e.FlightNo);

                entity.Property(e => e.Destination)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.DicountPrice)
                    .HasColumnName("Dicount_price")
                    .HasColumnType("money");

                entity.Property(e => e.FDate)
                    .IsRequired()
                    .HasColumnName("F_Date")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FTime)
                    .IsRequired()
                    .HasColumnName("F_Time")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FlightName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Oneway)
                    .HasColumnName("oneway")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.OnewayPrice)
                    .HasColumnName("oneway_price")
                    .HasColumnType("money");

                entity.Property(e => e.RoundTrip)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.RoundtripPrice)
                    .HasColumnName("Roundtrip_price")
                    .HasColumnType("money");

                entity.Property(e => e.Source)
                    .IsRequired()
                    .HasColumnName("source")
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using UserServices.Models;

namespace UserServices
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

        public virtual DbSet<TicketBookingDetails> TicketBookingDetails { get; set; }
        public virtual DbSet<BookFlight> BookFlight { get; set; }
        public virtual DbSet<Flights> Flights { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server= ctsdotnet55;Database =UserDb;User Id= sa; Password=pass@word1;");
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

            modelBuilder.Entity<TicketBookingDetails>(entity =>
            {
                entity.HasKey(e => e.Userid);

                entity.Property(e => e.Destination)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.EndDatrTime)
                    .IsRequired()
                    .HasColumnName("End_Datr_Time")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.FlightName)
                    .IsRequired()
                    .HasColumnName("Flight_name")
                    .HasMaxLength(100);

                entity.Property(e => e.FlightNo).HasColumnName("Flight_No");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasColumnName("gender")
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100);

                entity.Property(e => e.Phone).HasColumnName("phone");

                entity.Property(e => e.Pnr).HasColumnName("PNR");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("money");

                entity.Property(e => e.SeatNo).HasColumnName("Seat_No");

                entity.Property(e => e.Source)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.StartDateTime)
                    .IsRequired()
                    .HasColumnName("Start_Date_Time")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}

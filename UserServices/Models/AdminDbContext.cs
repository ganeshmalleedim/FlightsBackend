using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace UserServices.Models
{
    public partial class AdminDbContext : DbContext
    {
        public AdminDbContext()
        {
        }

        public AdminDbContext(DbContextOptions<AdminDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AddDetailsOfAirLine> AddDetailsOfAirLine { get; set; }
        public virtual DbSet<AdminLogin> AdminLogin { get; set; }
        public virtual DbSet<UserDetails> UserDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=ctsdotnet55;Database=AdminDb;user id=sa; password=pass@word1;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AddDetailsOfAirLine>(entity =>
            {
                entity.HasKey(e => e.FlightNo);

                entity.ToTable("Add_details_of_AirLine");

                entity.Property(e => e.FlightNo).HasColumnName("Flight_No");

                entity.Property(e => e.Destination)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.EndDateTime)
                    .IsRequired()
                    .HasColumnName("End_date_time")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FlightLogo)
                    .HasColumnName("Flight_Logo")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FlightName)
                    .IsRequired()
                    .HasColumnName("Flight_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.InstrumentsUsed)
                    .IsRequired()
                    .HasColumnName("Instruments_Used")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MealNonVeg)
                    .HasColumnName("Meal_Non_veg")
                    .HasMaxLength(100);

                entity.Property(e => e.MealVeg)
                    .HasColumnName("Meal_veg")
                    .HasMaxLength(100);

                entity.Property(e => e.NoOfRows).HasColumnName("No_of_Rows");

                entity.Property(e => e.OnewayPrice)
                    .HasColumnName("Oneway_Price")
                    .HasColumnType("money");

                entity.Property(e => e.RoundtripPrice)
                    .HasColumnName("Roundtrip_Price")
                    .HasColumnType("money");

                entity.Property(e => e.SheduleDays)
                    .IsRequired()
                    .HasColumnName("Shedule_Days")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Source)
                    .IsRequired()
                    .HasColumnName("Source_")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StartDateTime)
                    .IsRequired()
                    .HasColumnName("Start_date_time")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TotalNoOfBusinessClassSeats).HasColumnName("Total_no_of_BusinessClass_Seats");

                entity.Property(e => e.TotalNoOfNonBusinessClassSeats).HasColumnName("Total_no_of_non_BusinessClass_Seats");
            });

            modelBuilder.Entity<AdminLogin>(entity =>
            {
                entity.HasKey(e => e.Adminid);

                entity.Property(e => e.AdminName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.AdminPassword)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.AdminUn)
                    .IsRequired()
                    .HasColumnName("AdminUN")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<UserDetails>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(100);
            });
        }
    }
}

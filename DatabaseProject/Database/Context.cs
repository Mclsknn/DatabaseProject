using DatabaseProject.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject.Database
{
    public class Context : DbContext
    {
        public DbSet<CarDetail> CarDetails { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<DeliveryDetail> DeliveryDetails { get; set; }
      //  public DbSet<DeliveryDetailsCities> DeliveryDetailsCities { get; set; }
      //  public DbSet<DeliveryDetailsCountries> DeliveryDetailsCountries { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<LoadDetail> LoadDetails { get; set; }
        public DbSet<TyreDetail> TyreDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=MUSTAFA\\SQLEXPRESS ; Database=LogisticsDB ; Integrated Security=yes");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarDetail>().HasOne<DeliveryDetail>(x => x.DeliveryDetail)
                                            .WithOne(x => x.CarDetail)
                                            .HasForeignKey<DeliveryDetail>(x=> x.CarDetailID);
                                            

            modelBuilder.Entity<CarDetail>().HasMany(x=> x.TyreDetails)
                                            .WithOne(X=> X.CarDetail)
                                            .HasForeignKey(x=> x.CarID)
                                            .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<City>().HasOne(x => x.Country)
                                       .WithMany(x => x.Cities)
                                       .HasForeignKey(x => x.CountryID)
                                       .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Driver>().HasOne(x => x.DeliveryDetail)
                                         .WithMany(x => x.Drivers)
                                         .HasForeignKey(x => x.DeliveryDetailID)
                                         .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<LoadDetail>().HasOne(x => x.DeliveryDetail)
                                             .WithMany(x => x.LoadDetails)
                                             .HasForeignKey(x => x.DeliveryDetailID)
                                             .OnDelete(DeleteBehavior.SetNull);



            modelBuilder.Entity<DeliveryDetail>().HasOne(x => x.CityDeparture)
                                                 .WithMany(x => x.DeliveryDepartureCities)
                                                 .HasForeignKey(x => x.CityDepartureId)
                                                 .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<DeliveryDetail>().HasOne(x => x.CityDestination)
                                                 .WithMany(x => x.DeliveryDestinationCities)
                                                 .HasForeignKey(x => x.CityDestinationId)
                                                 .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<DeliveryDetail>().HasOne(x => x.CountryDeparture)
                                                 .WithMany(x => x.DeliveryDepartureCountries)
                                                 .HasForeignKey(x => x.CountryDepartureId)
                                                 .OnDelete(DeleteBehavior.ClientSetNull);


            modelBuilder.Entity<DeliveryDetail>().HasOne(x => x.CountryDestination)
                                               .WithMany(x => x.DeliveryDestinationCountries)
                                               .HasForeignKey(x => x.CountryDestinationId)
                                               .OnDelete(DeleteBehavior.ClientSetNull);
                                              

        }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using Wirtrack.Domain.Entities;

namespace Wirtrack.AccessData
{
    public static class InitialDataSeeding
    {
        public static void Seeding(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicles>()
                .HasData(
                   new Vehicles { Id = 1, Type = "car", CarLicense = "AAA000", Model = "Peugeot 208", IsDeleted = false, LastModified = DateTime.UtcNow },
                   new Vehicles { Id = 2, Type = "truck", CarLicense = "AAA001", Model = "Mercedes Benz", IsDeleted = false, LastModified = DateTime.UtcNow },
                   new Vehicles { Id = 3, Type = "motorcycle", CarLicense = "AAA002", Model = "Honda CG 125", IsDeleted = false, LastModified = DateTime.UtcNow }
                );

            modelBuilder.Entity<Cities>()
                .HasData(
                   new Cities { Id = 1, Name = "Palermo", CountryCode = "AR", IsDeleted = false, LastModified = DateTime.UtcNow },
                   new Cities { Id = 2, Name = "Belgrano", CountryCode = "AR", IsDeleted = false, LastModified = DateTime.UtcNow },
                   new Cities { Id = 3, Name = "Balvanera", CountryCode = "AR", IsDeleted = false, LastModified = DateTime.UtcNow },
                   new Cities { Id = 4, Name = "Retiro", CountryCode = "AR", IsDeleted = false, LastModified = DateTime.UtcNow },
                   new Cities { Id = 5, Name = "Avellaneda", CountryCode = "AR", IsDeleted = false, LastModified = DateTime.UtcNow },
                   new Cities { Id = 6, Name = "Quilmes", CountryCode = "AR", IsDeleted = false, LastModified = DateTime.UtcNow },
                   new Cities { Id = 7, Name = "Berazategui", CountryCode = "AR", IsDeleted = false, LastModified = DateTime.UtcNow }
                 );

            modelBuilder.Entity<Trips>()
               .HasData(
                  new Trips { Id = 1, IdDestinationCity = 1, IdVehicle = 1, DateTrip = new DateTime(2022, 09, 13, 10, 0, 0), IdStatus = 1,IsDeleted = false, LastModified = DateTime.UtcNow },
                  new Trips { Id = 2, IdDestinationCity = 3, IdVehicle = 2, DateTrip = new DateTime(2022, 09, 14, 10, 0, 0), IdStatus = 1, IsDeleted = false, LastModified = DateTime.UtcNow },
                  new Trips { Id = 3, IdDestinationCity = 4, IdVehicle = 2, DateTrip = new DateTime(2022, 09, 15, 10, 0, 0), IdStatus = 1, IsDeleted = false, LastModified = DateTime.UtcNow },
                  new Trips { Id = 4, IdDestinationCity = 1, IdVehicle = 3, DateTrip = new DateTime(2022, 09, 16, 10, 0, 0), IdStatus = 1, IsDeleted = false, LastModified = DateTime.UtcNow },
                  new Trips { Id = 5, IdDestinationCity = 5, IdVehicle = 3, DateTrip = new DateTime(2022, 09, 17, 10, 0, 0), IdStatus = 1, IsDeleted = false, LastModified = DateTime.UtcNow },
                  new Trips { Id = 6, IdDestinationCity = 1, IdVehicle = 2, DateTrip = new DateTime(2022, 09, 18, 10, 0, 0), IdStatus = 1, IsDeleted = false, LastModified = DateTime.UtcNow },
                  new Trips { Id = 7, IdDestinationCity = 1, IdVehicle = 1, DateTrip = new DateTime(2022, 09, 19, 10, 0, 0), IdStatus = 1, IsDeleted = false, LastModified = DateTime.UtcNow }
                );
        }
    }
}
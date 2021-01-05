using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;

namespace MyValueConverter
{
    public class SampleDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "SampleDb");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var DateToIntConverter = new ValueConverter<DateTime, int>(
                            v => int.Parse(v.Year.ToString("00") + v.Month.ToString("00") + v.Day.ToString("00")),
                            v => new DateTime(GetDateParts(v).Year, GetDateParts(v).Month, GetDateParts(v).Day));

            modelBuilder
                .Entity<SampleModel>()
                .Property(e => e.RegisterationDate)
                .HasConversion(DateToIntConverter);
        }

        private static (int Year, int Month, int Day) GetDateParts(int date)
        {
            int year = int.Parse(date.ToString().Substring(0, 2));
            int month = int.Parse(date.ToString().Substring(2, 2));
            int day = int.Parse(date.ToString().Substring(4, 2));

            return (year, month, day);
        }
    }
}

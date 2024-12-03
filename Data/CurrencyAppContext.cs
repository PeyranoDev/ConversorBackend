using Common.Enums;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class CurrencyAppContext : DbContext
    {
        public CurrencyAppContext(DbContextOptions<CurrencyAppContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Conversion> Conversions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Subscription>()
                .HasMany(s => s.Users)
                .WithOne(u => u.UserSubscription)
                .HasForeignKey(u => u.SubscriptionId);

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Subscription>().HasData(
           new Subscription
           {
               Id = 1,
               Type = SubscriptionTypeEnum.Free,
               ConversionLimit = 10
           },
           new Subscription
           {
               Id = 2,
               Type = SubscriptionTypeEnum.Trial,
               ConversionLimit = 100
           },
           new Subscription
           {
               Id = 3,
               Type = SubscriptionTypeEnum.Pro,
               ConversionLimit = null // Sin límite
           }
       );

            modelBuilder.Entity<Currency>().HasData(
                new Currency
                {
                    Id = 1,
                    Code = "ARS",
                    Legend = "Peso Argentino",
                    Symbol = "$",
                    ConvertibilityIndex = 0.002m
                },
                new Currency
                {
                    Id = 2,
                    Code = "EUR",
                    Legend = "Euro",
                    Symbol = "€",
                    ConvertibilityIndex = 1.09m
                },
                new Currency
                {
                    Id = 3,
                    Code = "Kc",
                    Legend = "Corona Checa",
                    Symbol = "Kč",
                    ConvertibilityIndex = 0.043m
                },
                new Currency
                {
                    Id = 4,
                    Code = "USD",
                    Legend = "Dólar Americano",
                    Symbol = "$",
                    ConvertibilityIndex = 1.00m
                }
            );
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrenciesProject.Data.Context
{
    public class MasterContext : DbContext
    {
        public DbSet<Dates> Dates { get; set; }
        public DbSet<Currency> Currencies { get; set; }

        public MasterContext(DbContextOptions<MasterContext> options) : base(options)
        {

        }
        public MasterContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("PostgreUri"));

        /// <summary>
        /// Model ilişkileri ve keyleri 6belirlenir
        /// </summary>
        /// <param name="builder"></param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Dates>()
                .HasKey(x => x.Date);
            builder.Entity<Currency>()
                .HasKey(x => x.CurrencyId);
            builder.Entity<Currency>()
                .HasOne(p => p.DatesModel)
                .WithMany(a => a.Currency)
                .HasForeignKey(x => x.Date);
        }
    }
}


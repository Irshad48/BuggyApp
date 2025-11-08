using BuggyAppAPI.Models;
using Microsoft.EntityFrameworkCore;


namespace BuggyAppAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Invoice>()
                .HasMany(i => i.InvoiceItems)
                .WithOne(ii => ii.Invoice)
                .HasForeignKey(ii => ii.InvoiceID);
        }
    }

}


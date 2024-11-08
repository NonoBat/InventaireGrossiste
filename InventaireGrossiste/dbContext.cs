using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventaireGrossiste.Models;
using Microsoft.EntityFrameworkCore;


namespace InventaireGrossiste
{
    public class ApplicationDbContext : DbContext
    {

        public DbSet<Category> Categories { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Commande> Commandes { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=..\..\..\Files\librairie1.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Commande>()
                .HasKey(c => new { c.IdClient, c.IdProduct });

            modelBuilder.Entity<Commande>()
                .HasOne(c => c.Client)
                .WithMany()
                .HasForeignKey(c => c.IdClient);

            modelBuilder.Entity<Commande>()
                .HasOne(c => c.Product)
                .WithMany()
                .HasForeignKey(c => c.IdProduct);
        }
    }
}
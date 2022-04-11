using Microsoft.EntityFrameworkCore;
using PS.Data.Configuration;
using PS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PS.Data
{
    public class PSContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Biological> Biologicals { get; set; }
        public DbSet<Chemical> Chemicals { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Achat> Achat { get; set; }
        public DbSet<Client> Client { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
                                        Initial Catalog=ProductStoreDB;
                                        Integrated Security=true;
                                        MultipleActiveResultSets=True");
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().ToTable("MyCategories").HasKey(c => c.CategoryId);
            modelBuilder.Entity<Category>().Property(c => c.Name).IsRequired().HasMaxLength(50);
            //modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            
            //configuring Inheritence Table Per Type
            modelBuilder.Entity<Chemical>().ToTable("chemical");
            modelBuilder.Entity<Biological>().ToTable("biological");

            //config table porteuse Achat PK
            modelBuilder.Entity<Achat>().HasKey(a=> new {a.ClientFK, a.ProductFK ,a.DateAchat });

            //gloal model config
            var properties = modelBuilder.Model.GetEntityTypes().
                SelectMany(e => e.GetProperties())
                .Where(p => p.Name.StartsWith("Name")
                    && p.ClrType == typeof(String)
                );

            foreach (var p in properties)
            {
                p.SetColumnName("MyName");
            }

            //global model config string type columns to be required
            /*var stringProperties = modelBuilder.Model.GetEntityTypes().
                SelectMany(e => e.GetProperties())
                .Where(p => p.ClrType == typeof(String)
                );
            foreach (var p in stringProperties)
            {
                p.IsNullable = false;
            }*/

            base.OnModelCreating(modelBuilder);//override configuration
        }
    }
}

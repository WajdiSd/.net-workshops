using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PS.Domain;
using System;
using System.Collections.Generic;
using System.Text;


namespace PS.Data.Configuration
{
    class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            //configuring many to many relationship
            builder.HasMany(p => p.Providers).WithMany(p => p.Products)
                .UsingEntity(t => t.ToTable("Providings"));
            
            //configuring 0 to 1 => * relation
            builder.HasOne(p => p.Category).WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryFK).OnDelete(DeleteBehavior.Cascade);

            //configuring 1 to 1 => * relation
            //builder.HasOne(p => p.Category).WithMany(c => c.Products)
            //.HasForeignKey(p => p.CategoryFK).IsRequired(true).OnDelete(DeleteBehavior.Cascade);

            //configuring Inheritence Table Per Hierarchy
            /*builder.HasDiscriminator<int>("isBiological").
                HasValue<Product>(0).
                HasValue<Biological>(1).
                HasValue<Chemical>(2);*/

            //configuring Inheritence Table Per Type
        }
    }
}
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace order.queryservices
{
    public partial class queryDbContext : DbContext
    {
        public queryDbContext()
        {
        }

        public queryDbContext(DbContextOptions<queryDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderAddress> OrderAddress { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=ordermanager;Integrated Security=True;Pooling=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.AddressLine1)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.AddressLine2)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.OrderNumber)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<OrderAddress>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.OrderAddress)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderAddress_ToTable_1");
            });
        }
    }
}

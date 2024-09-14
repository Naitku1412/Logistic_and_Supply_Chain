﻿using Backend.Model;
using Microsoft.EntityFrameworkCore;

namespace Backend.Context
{
    public class DeliveryDbContext : DbContext
    {
        public DeliveryDbContext(DbContextOptions options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);
        }
        public DbSet<User> users { get; set; }
        public DbSet<User_Types> users_types { get; set; }
        public DbSet<PermissionXuserType> permissionsXuser { get; set; }
        public DbSet<Permissions> permissions { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<Order_Detail> orders_detail { get; set; }
        public DbSet<Order_Status_Type> orders_status { get; set; }
        public DbSet<Order_Tracking> orders_tracking { get; set; }
        public DbSet<Dealer> dealers { get; set; }
        public DbSet<Order_Tracking_Type> order_tracking_types { get; set; }
    }
}

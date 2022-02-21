using System;
using System.Collections.Generic;
using WEBAPIMVC.Models;
using Pomelo.EntityFrameworkCore.MySql;
using Microsoft.EntityFrameworkCore;

namespace WEBAPIMVC.Data
{
    public class MyDbContext : DbContext
    {

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accounts>();
            modelBuilder.Entity<Meter_Readings>();
        }

        public DbSet<Meter_Readings> Meter_Readings { get; set; }
        public DbSet<Accounts> Accounts { get; set; }

    }

}

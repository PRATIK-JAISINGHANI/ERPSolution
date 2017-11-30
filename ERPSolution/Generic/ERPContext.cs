﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ERPSolution.Models
{
    public class ERPContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<UserMaster> UserMaster { get; set;}

        public DbSet<Identity> Identity { get; set; }

        public DbSet<SecureData> SecureData { get; set; }
    }
}
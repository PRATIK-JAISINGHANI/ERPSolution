
using ERPSolution.InitializerModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using System.Data.Entity.Core.Objects.DataClasses;
using ERPSolution.MetadataModels;

namespace ERPSolution.Models
{
    public class ERPContext : DbContext
    {
        #region Protected Methods

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //
            modelBuilder.
                Properties().
                Where(p => 
                    p.Name.ToUpper() == "ID" && 
                    p.PropertyType == typeof(Guid)).
                    Configure(p => p.IsKey());

            modelBuilder.
                Properties().
                Where(p => 
                    p.Name == "Code" && 
                    p.PropertyType == typeof(string)).
                    Configure(p => p.HasMaxLength(200));

            modelBuilder.Entity<UserMaster>().MapToStoredProcedures();
        }

        #endregion

        #region Entities that needs to be saved in Db

        #region Metadata Entities

        public DbSet<EntityMaster> EntityMaster { get; set; }

        #endregion

        #region Model Entities

        public DbSet<ApplicationDefaults> ApplicationDefaults { get; set; }

        public DbSet<Session> Session { get; set; }

        public DbSet<UserMaster> UserMaster { get; set;}

        public DbSet<Identity> Identity { get; set; }

        public DbSet<SecureData> SecureData { get; set; }

        #endregion

        #endregion
    }
}
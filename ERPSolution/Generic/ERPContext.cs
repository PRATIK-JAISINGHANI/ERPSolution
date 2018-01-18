
using ERPSolution.InitializerModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using System.Data.Entity.Core.Objects.DataClasses;

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

        public DbSet<ApplicationDefaults> ApplicationDefaults { get; set; }

        public DbSet<Session> Session { get; set; }

        internal EntityObject Entry<T>()
        {
            throw new NotImplementedException();
        }

        public DbSet<UserMaster> UserMaster { get; set;}

        public DbSet<Identity> Identity { get; set; }

        public DbSet<SecureData> SecureData { get; set; }

        #endregion
    }
}
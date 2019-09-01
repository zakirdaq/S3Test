
using ChartApi.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartApi.Data
{
    public class ApplicationEntities : DbContext
    {
        public ApplicationEntities()
            : base("DBConnection")
        {
            /**
             * It's not necessary to remove the virtual keyword from the navigation properties (which would make lazy loading completely 
             * impossible for the model). It's enough to disable proxy creation (which disables lazy loading as well) for the specific circumstances 
             * where proxies are disturbing, like serialization
             */
            //this.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<ChartValue> ChartValue { get; set; }

        public virtual void Commit()
        {
            base.SaveChanges();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
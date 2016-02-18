using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Microsoft.AspNet.Identity.EntityFramework;
using Wunderlist.Models;

namespace SignalR.Data
{
    public class WunderlistContext : IdentityDbContext<User>
    {

        public WunderlistContext() : base("WunderlistConnection")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<WunderlistContext>());
        }

      
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<IncludeMetadataConvention>();
        }


        public virtual void Commint()
        {
            base.SaveChanges();
        }

    }
}

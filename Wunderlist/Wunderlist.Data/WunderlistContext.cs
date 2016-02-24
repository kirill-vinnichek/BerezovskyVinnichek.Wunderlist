﻿using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Wunderlist.Data.Configuration;
using Wunderlist.Models;

namespace Wunderlist.Data
{
    public class WunderlistContext : DbContext
    {       
        public WunderlistContext() : base("WunderlistConnection")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<WunderlistContext>());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<ToDoItem> ToDoItems { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<ToDoItemList> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
      


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<IncludeMetadataConvention>();

            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new RoleConfiguration());
        }


        public virtual void Commit()
        {
            base.SaveChanges();
        }

    }
}

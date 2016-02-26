using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Epam.Wunderlist.DataAccess.MsSql.Configuration;
using Epam.Wunderlist.Models;

namespace Epam.Wunderlist.DataAccess.MsSql
{
    public class WunderlistContext : DbContext
    {       
        public WunderlistContext() : base("WunderlistConnection")
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<WunderlistContext>());
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
            modelBuilder.Configurations.Add(new PictureConfiguration());
            modelBuilder.Configurations.Add(new CommentConfiguration());
            modelBuilder.Configurations.Add(new ToDoItemConfiguration());
            modelBuilder.Configurations.Add(new ToDoItemListConfiguration());
            modelBuilder.Configurations.Add(new UserProfileConfiguration());
        }


        public virtual void Commit()
        {
            base.SaveChanges();
        }

    }
}

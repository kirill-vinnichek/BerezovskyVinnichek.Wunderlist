using System.Data.Entity.ModelConfiguration;
using Epam.Wunderlist.Models;

namespace Epam.Wunderlist.DataAccess.MsSql.Configuration
{
    internal class RoleConfiguration: EntityTypeConfiguration<Role>
    {
        public RoleConfiguration()
        {
            HasKey(r => r.Id);
        }
    }
}

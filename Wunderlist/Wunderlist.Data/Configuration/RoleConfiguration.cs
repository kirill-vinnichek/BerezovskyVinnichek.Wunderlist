using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wunderlist.Models;

namespace Wunderlist.Data.Configuration
{
   public class RoleConfiguration: EntityTypeConfiguration<Role>
    {
        public RoleConfiguration()
        {
            HasKey(r => r.Id);
        }
    }
}

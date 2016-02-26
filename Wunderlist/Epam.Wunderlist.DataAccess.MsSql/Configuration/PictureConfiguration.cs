using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Wunderlist.Models;

namespace Epam.Wunderlist.DataAccess.MsSql.Configuration
{
    internal class PictureConfiguration: EntityTypeConfiguration<Picture>
    {
        public PictureConfiguration()
        {
            HasKey(p => p.Id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Wunderlist.Models;

namespace Epam.Wunderlist.DataAccess.MsSql.Configuration
{
    internal class ToDoItemListConfiguration: EntityTypeConfiguration<ToDoItemList>
    {
        public ToDoItemListConfiguration()
        {
            HasKey(t => t.Id);
        }
    }
}

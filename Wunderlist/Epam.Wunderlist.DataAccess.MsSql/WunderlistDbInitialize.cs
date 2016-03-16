using Epam.Wunderlist.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Wunderlist.DataAccess.MsSql
{
   public class WunderlistDbInitialize:DropCreateDatabaseIfModelChanges<WunderlistContext>
    {
        protected override void Seed(WunderlistContext context)
        {
            
            base.Seed(context);
        }
    }
}

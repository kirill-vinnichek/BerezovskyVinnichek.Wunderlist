using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalR.Data.Infrastructure;
using Wunderlist.Models;

namespace Wunderlist.Data.Repositories
{
    public class PictureRepository:RepositoryBase<Picture>,IPictureRepository
    {
        public  PictureRepository(IDatabaseFactory dbF) : base(dbF) { }
    }

    public interface IPictureRepository : IRepository<Picture> { }
}

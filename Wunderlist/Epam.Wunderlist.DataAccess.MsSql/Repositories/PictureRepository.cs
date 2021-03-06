﻿using Epam.Wunderlist.DataAccess.Interfaces;
using Epam.Wunderlist.DataAccess.MsSql.Infrastructure;
using Epam.Wunderlist.Models;

namespace Epam.Wunderlist.DataAccess.MsSql.Repositories
{
    public class PictureRepository:RepositoryBase<Picture>,IPictureRepository
    {
        public  PictureRepository(IDatabaseFactory dbF) : base(dbF) { }
    }
}

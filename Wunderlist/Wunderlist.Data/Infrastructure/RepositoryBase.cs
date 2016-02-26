using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Epam.Wunderlist.DataAccess.Interfaces;
using Epam.Wunderlist.DataAccess.Interfaces.Infrastructure;

namespace Epam.Wunderlist.DataAccess.MsSql.Infrastructure
{
    public class RepositoryBase<T> : IRepository<T> where T :class
    {
        private WunderlistContext _dataContext;
        protected IDbSet<T> DbSet;


        public RepositoryBase(IDatabaseFactory databaseFactory)
        {
            DatabaseFactory = databaseFactory;
            DbSet = DataContext.Set<T>();
        }

        protected IDatabaseFactory DatabaseFactory { get; }

        protected WunderlistContext DataContext
        {
            get { return _dataContext ?? (_dataContext = DatabaseFactory.Context); }
        }
        public virtual void Add(T entity) => DbSet.Add(entity);


        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            var entities = DbSet.Where(where).AsEnumerable();
            foreach (var e in entities)
                DbSet.Remove(e);
        }



        public virtual void Delete(T entity) => DbSet.Remove(entity);

        public virtual int Count() => DbSet.Count();

        public virtual int Count(Expression<Func<T, bool>> where) => DbSet.Count(where);

        public virtual T Get(Expression<Func<T, bool>> where) => DbSet.Where(where).FirstOrDefault();


        public virtual IEnumerable<T> GetAll() => DbSet.ToList();


        public virtual T GetById(string id) => DbSet.Find(id);


        public virtual T GetById(long id) => DbSet.Find(id);


        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where) => DbSet.Where(where).ToList();
       
        public virtual void Update(T entity)
        {
            DbSet.Attach(entity);
            DataContext.Entry(entity).State = EntityState.Modified;
        }
    }
}

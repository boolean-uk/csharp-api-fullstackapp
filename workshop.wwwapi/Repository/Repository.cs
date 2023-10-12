﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq.Expressions;
using workshop.wwwapi.Data;

namespace workshop.wwwapi.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {


        private DatabaseContext _db;
        private DbSet<T> _table = null;
        public Repository()
        {
            _db = new DatabaseContext();
            _table = _db.Set<T>();
        }
        public Repository(DatabaseContext db)
        {
            _db = db;
            _table = _db.Set<T>();
        }

        public IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includeExpressions)
        {
            if (includeExpressions.Any())
            {
                var set = includeExpressions
                    .Aggregate<Expression<Func<T, object>>, IQueryable<T>>
                     (_table, (current, expression) => current.Include(expression));
            }
            return _table.ToList();
        }

        public IEnumerable<T> GetAll()
        {
            return _table.ToList();
        }
        public T GetById(object id)
        {
            return _table.Find(id);
        }

        public void Insert(T obj)
        {
            _table.Add(obj);
        }
        public void Update(T obj)
        {
            _table.Attach(obj);
            _db.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(object id)
        {
            T existing = _table.Find(id);
            _table.Remove(existing);
        }


        public void Save()
        {
            _db.SaveChanges();
        }
        public DbSet<T> Table { get { return _table; } }

    }
}

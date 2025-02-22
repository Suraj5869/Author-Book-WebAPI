﻿
using AuthorWebApi.Data;
using Microsoft.EntityFrameworkCore;

namespace AuthorWebApi.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AuthorContext _context;
        private readonly DbSet<T> _table;
        public Repository(AuthorContext authorContext)
        {
            _context = authorContext;
            _table = _context.Set<T>();
        }

        //Add data in database
        public int Add(T entity)
        {
            _table.Add(entity);
            return _context.SaveChanges();
        }

        //Delete data from database
        public int Delete(T entity)
        {
            _table.Remove(entity);
            return _context.SaveChanges();
        }

        //Get the particular data using its id
        public T Get(int id)
        {
            var entity = _table.Find(id);
            return entity;
        }

        //Get all data from specific table
        public IQueryable<T> GetAll()
        {
            return _table.AsQueryable();
        }

        //update data in database
        public T Update(T entity)
        {
            _table.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }

}

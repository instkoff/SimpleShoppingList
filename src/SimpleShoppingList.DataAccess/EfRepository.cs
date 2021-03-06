﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimpleShoppingList.DataAccess.Entities;

namespace SimpleShoppingList.DataAccess
{
    public class EfRepository : IDbRepository
    {
        private readonly DataContext _context;

        public EfRepository(DataContext context)
        {
            _context = context;
        }

        public IQueryable<T> GetActiveEntities<T>() where T : class, IEntity
        {
            return _context.Set<T>().Where(x => x.IsActive).AsQueryable();
        }

        public IQueryable<T> Get<T>(Expression<Func<T, bool>> selector) where T : class, IEntity
        {
            return _context.Set<T>().Where(selector).Where(x => x.IsActive).AsQueryable();
        }

        public async Task<T> AddAsync<T>(T newEntity) where T : class, IEntity
        {
            var entity = await _context.Set<T>().AddAsync(newEntity);
            return entity.Entity;
        }

        public async Task AddRangeAsync<T>(IEnumerable<T> newEntities) where T : class, IEntity
        {
            await _context.Set<T>().AddRangeAsync(newEntities);
        }

        public async Task DeleteAsync<T>(Guid id) where T : class, IEntity
        {
            var activeEntity = await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
            activeEntity.IsActive = false;
            await Task.Run(() => _context.Update(activeEntity));
        }

        public async Task RemoveAsync<T>(T entity) where T : class, IEntity
        {
            await Task.Run(() => _context.Set<T>().Remove(entity));
        }

        public async Task RemoveRangeAsync<T>(IEnumerable<T> entities) where T : class, IEntity
        {
            await Task.Run(() => _context.Set<T>().RemoveRange(entities));
        }

        public async Task UpdateAsync<T>(T entity) where T : class, IEntity
        {
            await Task.Run(() => _context.Set<T>().Update(entity));
        }

        public async Task UpdateRangeAsync<T>(IEnumerable<T> entities) where T : class, IEntity
        {
            await Task.Run(() => _context.Set<T>().UpdateRange(entities));
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public IQueryable<T> GetAll<T>() where T : class, IEntity
        {
            return _context.Set<T>().AsQueryable();
        }
    }
}

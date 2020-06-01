﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SimpleShoppingList.DataAccess.Entities;

namespace SimpleShoppingList.DataAccess
{
    public interface IDbRepository
    {
        IQueryable<T> GetActiveEntities<T>() where T : class, IEntity;
        IQueryable<T> Get<T>(Expression<Func<T, bool>> selector) where T : class, IEntity;
        Task<T> AddAsync<T>(T newEntity) where T : class, IEntity;
        Task AddRangeAsync<T>(IEnumerable<T> newEntities) where T : class, IEntity;
        Task DeleteAsync<T>(Guid id) where T : class, IEntity;
        Task RemoveAsync<T>(T entity) where T : class, IEntity;
        Task RemoveRangeAsync<T>(IEnumerable<T> entities) where T : class, IEntity;
        Task UpdateAsync<T>(T entity) where T : class, IEntity;
        Task UpdateRangeAsync<T>(IEnumerable<T> entities) where T : class, IEntity;
        Task<int> SaveChangesAsync();
        IQueryable<T> GetAll<T>() where T : class, IEntity;
    }
}
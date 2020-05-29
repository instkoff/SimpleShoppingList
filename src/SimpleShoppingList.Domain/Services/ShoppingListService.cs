using System;
using System.Threading.Tasks;
using AutoMapper;
using SimpleShoppingList.DataAccess;
using SimpleShoppingList.DataAccess.Entities;
using SimpleShoppingList.Domain.Abstractions;
using SimpleShoppingList.Domain.Models;

namespace SimpleShoppingList.Domain.Services
{
    public class ShoppingListService : IShoppingListService
    {
        private readonly IDbRepository _dbRepository;
        private readonly IMapper _mapper;

        public ShoppingListService(IDbRepository dbRepository, IMapper mapper)
        {
            _dbRepository = dbRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Create(ShoppingListModel shoppingListModel)
        {
            var shoppingListEntity = _mapper.Map<ShoppingListEntity>(shoppingListModel);
            await _dbRepository.AddAsync(shoppingListEntity);
            await _dbRepository.SaveChangesAsync();
            return shoppingListEntity.Id;
        }
    }
}
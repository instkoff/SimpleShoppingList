using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SimpleShoppingList.DataAccess;
using SimpleShoppingList.DataAccess.Entities;
using SimpleShoppingList.Domain.Abstractions;
using SimpleShoppingList.Domain.Models;

namespace SimpleShoppingList.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly IDbRepository _dbRepository;
        private readonly IMapper _mapper;

        public ProductService(IDbRepository dbRepository, IMapper mapper)
        {
            _dbRepository = dbRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Create(ProductModel productModel)
        {
            var productEntity = _mapper.Map<ProductEntity>(productModel);
            var result = await _dbRepository.AddAsync(productEntity);
            await _dbRepository.SaveChangesAsync();
            return result;
        }

        public async Task<Guid> Update(ProductModel productModel)
        {
            var productEntity = _mapper.Map<ProductEntity>(productModel);
            await _dbRepository.UpdateAsync(productEntity);
            await _dbRepository.SaveChangesAsync();
            return productEntity.Id;
        }

        public List<ProductModel> GetAll()
        {
            var productEntities = _dbRepository.GetActiveEntities<ProductEntity>();
            var productCollection = _mapper.Map<List<ProductModel>>(productEntities);
            if (productCollection == null || !productCollection.Any())
                return null;
            return productCollection;
        }

        public ProductModel GetById(Guid id)
        {
            var productEntity = _dbRepository.GetActiveEntities<ProductEntity>()
                .FirstOrDefault(x => x.Id == id);
            return productEntity != null ? _mapper.Map<ProductModel>(productEntity) : null;
        }

        public async Task Delete(Guid id)
        {
            await _dbRepository.DeleteAsync<ProductEntity>(id);
            await _dbRepository.SaveChangesAsync();
        }
    }
}
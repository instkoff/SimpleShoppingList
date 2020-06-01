using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SimpleShoppingList.Domain.Models;

namespace SimpleShoppingList.Domain.Abstractions
{
    public interface IProductService
    {
        Task<ProductModel> Create(ProductModel productModel);
        Task<Guid> Update(ProductModel productModel);
        List<ProductModel> GetAll();
        ProductModel GetById(Guid id);
        Task Delete(Guid id);
    }
}
using System;
using blazor_proj_models;

namespace blazor_proj_business.Repository
{
    public interface IProductRepository
    {
        public Task<ProductDto> Create(ProductDto product);
        public Task<ProductDto> Update(ProductDto product);
        public Task<int> Delete(int id);
        public Task<ProductDto> Get(int id);

        public Task<IEnumerable<ProductDto>> GetAll();
    }
}


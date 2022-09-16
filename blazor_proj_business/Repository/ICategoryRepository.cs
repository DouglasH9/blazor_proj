using System;
using blazor_proj_models;

namespace blazor_proj_business.Repository
{
    public interface ICategoryRepository
    {
        public Task<CategoryDto> Create(CategoryDto category);
        public Task<CategoryDto> Update(CategoryDto category);
        public Task<int> Delete(int id);
        public Task<CategoryDto> Get(int id);

        public Task<IEnumerable<CategoryDto>> GetAll();
    }
}


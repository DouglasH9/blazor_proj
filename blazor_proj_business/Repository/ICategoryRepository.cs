using System;
using blazor_proj_models;

namespace blazor_proj_business.Repository
{
    public interface ICategoryRepository
    {
        public CategoryDto Create(CategoryDto category);
        public CategoryDto Update(CategoryDto category);
        public int Delete(int id);
        public CategoryDto Get(int id);

        public IEnumerable<CategoryDto> GetAll();
    }
}


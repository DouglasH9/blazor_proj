using System;
using AutoMapper;
using blazor_proj_dataAccess;
using blazor_proj_dataAccess.Data;
using blazor_proj_models;
using blazor_proj_business.Repository;
using Microsoft.EntityFrameworkCore;

namespace blazor_proj_business.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;

        public CategoryRepository(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<CategoryDto> Create(CategoryDto objDto)
        {
            var obj = _mapper.Map<CategoryDto, Category>(objDto);

            obj.DateCreated = DateTime.UtcNow;

            var addedObj = _db.Categories.Add(obj);
            await _db.SaveChangesAsync();

            return _mapper.Map<Category, CategoryDto>(addedObj.Entity);
        }

        public async Task<int> Delete(int id)
        {
            var obj = await _db.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (obj is not null)
            {
                _db.Categories.Remove(obj);
                return await _db.SaveChangesAsync();
            }

            return 0;
        }

        public async Task<CategoryDto> Get(int id)
        {
            var obj = await _db.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (obj is not null)
            {
                return _mapper.Map<Category, CategoryDto>(obj);
            }

            return new CategoryDto();
        }

        public async Task<IEnumerable<CategoryDto>> GetAll()
        {
            return _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDto>>(_db.Categories);
        }

        public async Task<CategoryDto> Update(CategoryDto objDto)
        {
            var objFromDb = await _db.Categories.FirstOrDefaultAsync(x => x.Id == objDto.Id);

            if (objFromDb is not null)
            {
                objFromDb.Name = objDto.Name;
                _db.Categories.Update(objFromDb);
                await _db.SaveChangesAsync();
                return _mapper.Map<Category, CategoryDto>(objFromDb);
            }

            return objDto;
        }
    }
}


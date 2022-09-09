using System;
using AutoMapper;
using blazor_proj_dataAccess;
using blazor_proj_dataAccess.Data;
using blazor_proj_models;
using blazor_proj_business.Repository;

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

        public CategoryDto Create(CategoryDto objDto)
        {
            var obj = _mapper.Map<CategoryDto, Category>(objDto);

            obj.DateCreated = DateTime.Now;

            var addedObj = _db.Categories.Add(obj);
            _db.SaveChanges();

            return _mapper.Map<Category, CategoryDto>(addedObj.Entity);
        }

        public int Delete(int id)
        {
            var obj = _db.Categories.FirstOrDefault(x => x.Id == id);
            if (obj is not null)
            {
                _db.Categories.Remove(obj);
                return _db.SaveChanges();
            }

            return 0;
        }

        public CategoryDto Get(int id)
        {
            var obj = _db.Categories.FirstOrDefault(x => x.Id == id);
            if (obj is not null)
            {
                return _mapper.Map<Category, CategoryDto>(obj);
            }

            return new CategoryDto();
        }

        public IEnumerable<CategoryDto> GetAll()
        {
            return _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDto>>(_db.Categories);
        }

        public CategoryDto Update(CategoryDto objDto)
        {
            var objFromDb = _db.Categories.FirstOrDefault(x => x.Id == objDto.Id);

            if (objFromDb is not null)
            {
                objFromDb.Name = objDto.Name;
                _db.Categories.Update(objFromDb);
                _db.SaveChanges();
                return _mapper.Map<Category, CategoryDto>(objFromDb);
            }

            return objDto;
        }
    }
}


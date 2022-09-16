using System;
using AutoMapper;
using blazor_proj_dataAccess;
using blazor_proj_dataAccess.Data;
using blazor_proj_models;
using blazor_proj_business;
using Microsoft.EntityFrameworkCore;

namespace blazor_proj_business.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;

        public ProductRepository(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ProductDto> Create(ProductDto prodDto)
        {
            var obj = _mapper.Map<ProductDto, Product>(prodDto);

            var addedObj = _db.Products.Add(obj);
            await _db.SaveChangesAsync();

            return _mapper.Map<Product, ProductDto>(addedObj.Entity);

        }

        public async Task<int> Delete(int id)
        {
            var obj = await _db.Products.FirstOrDefaultAsync(x => x.Id == id);

            if (obj is not null)
            {
                _db.Products.Remove(obj);
                return await _db.SaveChangesAsync();
            }

            return 0;
        }

        public async Task<ProductDto> Get(int id)
        {
            var obj = await _db.Products.Include(u => u.Category).FirstOrDefaultAsync(x => x.Id == id);

            if (obj is not null)
            {
                return _mapper.Map<Product, ProductDto>(obj);
            }

            return new ProductDto();
        }

        public async Task<IEnumerable<ProductDto>> GetAll()
        {
            return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(_db.Products.Include(u => u.Category));
        }

        public async Task<ProductDto> Update(ProductDto product)
        {
            var objFromDb = await _db.Products.FirstOrDefaultAsync(x => x.Id == product.Id);

            if (objFromDb is not null)
            {
                objFromDb.Name = product.Name;
                objFromDb.Description = product.Description;
                objFromDb.Color = product.Color;
                objFromDb.ImageUrl = product.ImageUrl;
                objFromDb.CustomerFavorites = product.CustomerFavorites;
                objFromDb.ShopFavorites = product.ShopFavorites;
                objFromDb.CategoryId = product.CategoryId;

                _db.Products.Update(objFromDb);
                await _db.SaveChangesAsync();
                return _mapper.Map<Product, ProductDto>(objFromDb);
            }

            return product;
        }
    }
}


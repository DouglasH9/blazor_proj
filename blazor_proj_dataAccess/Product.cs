using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace blazor_proj_dataAccess
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool ShopFavorites { get; set; }

        public bool CustomerFavorites { get; set; }

        public string Color { get; set; }

        public string ImageUrl { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

    }
}


using System;
using System.ComponentModel.DataAnnotations;

namespace blazor_proj_models
{
    public class CategoryDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a name...")]
        public string? Name { get; set; }
    }
}


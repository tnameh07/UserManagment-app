using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace telerikdemo1.DataAccess.Dto
{
    public class CategoryDto
    {
        public int CategoryId { get; set; }

        [Required]
        [StringLength(15)]
        public string CategoryName { get; set; }

        public string Description { get; set; }

        [StringLength(150)]
        public string PictureUrl { get; set; }

        public List<ProductDto> Products { get; set; }

    }
}
﻿using System.ComponentModel.DataAnnotations;

namespace KandyKaffe.Services.ShoppingCartAPI.Models.Dto
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public string ImageUrl { get; set; }
        public bool? IsActive { get; set; }
    }
}

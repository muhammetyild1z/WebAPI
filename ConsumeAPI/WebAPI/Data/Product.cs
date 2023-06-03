using System;

namespace WebAPI.Data
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public int Stock { get; set; }
        public string Imagepath { get; set; }
        public decimal Price { get; set; }
        public DateTime CreateDate { get; set; }
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
    }
}

using System;
using WebAPI.Data;

namespace ConsumeAPI.ReponseModel
{
    public class ProductResponseModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public int Stock { get; set; }
        public string Imagepath { get; set; }
        public decimal Price { get; set; }
        public DateTime CreateDate { get; set; }
        public int? CategoryId { get; set; }
      
    }
}

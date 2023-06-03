using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Data;
using WebAPI.Interfaces;

namespace WebAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _context;

        public async Task<Product> createAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(x=>x.Id==id);
        }

        public async Task RemoveAsync(int id)
        {
            var removedEntity = await _context.Products.FindAsync(id);
            _context.Products.Remove(removedEntity);
            _context.SaveChanges();
        }

        public async Task UpdateAsync(Product product)
        {
            var unchangedEntity = await _context.Products.FindAsync(product.Id);
            _context.Entry(unchangedEntity).CurrentValues.SetValues(product);
            _context.SaveChanges();
        }
    }
}

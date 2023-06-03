using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using WebAPI.Data;
using WebAPI.Interfaces;

namespace WebAPI.Controllers
{
    [EnableCors]
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
          var result=   await _productRepository.GetAllAsync();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _productRepository.GetByIdAsync(id);
            if (data==null)
            {
                return NotFound(id);
            }
            return Ok(data);
           
        }

        [HttpPost]
        public async Task<IActionResult> create(Product product)
        {
            var AddedProduct= await _productRepository.createAsync(product);
            return Created("", AddedProduct);
        }

        [HttpPut]
        public async  Task<IActionResult> Update(Product product)
        {
            var chaeckProduct= await _productRepository.GetByIdAsync(product.Id);
            if (chaeckProduct==null)
            {
                return NotFound (); 
            }
            await _productRepository.UpdateAsync(chaeckProduct);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var checkProduct = await _productRepository.GetByIdAsync(id);
            if (checkProduct==null)
            {
                return NotFound();
            }
            await _productRepository.RemoveAsync(id);
            return NoContent();
        }

        [HttpPost("upload")]
        public async Task<IActionResult> upload(IFormFile formfile)
        {
            var newName = Guid.NewGuid() + "." + Path.GetExtension(formfile.FileName);
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", newName);
            var stream = new FileStream(path,FileMode.Create);
            await formfile.CopyToAsync(stream);
            return Created("", formfile);

        }
    }
}


            

using DevStore.Api.DTOs;
using DevStore.Api.Models;
using DevStore.Api.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DevStore.Api.Controllers
{
    //Dizendo para o asp.net que essa classe é um controller
    [ApiController]

    // Dizendo que essa rota chamará o mesmo nome da nossa classe, ou seja: api/products pois o asp.net remove o "Controller" da classe
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase {
        private static List<Product> produtos = new();

        private ProductService productService;

        public ProductsController(ProductService productService) { 
            this.productService = productService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(productService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetActionResult(int id) {
            var produto = productService.GetById(id);

            if(produto == null)
            {
                return NotFound();
            }

            return Ok(produto);
        }

        [HttpPost]
        public IActionResult Create(CreateProductRequest request) {
            try
            {
                var produto = productService.CreateProduct(request);
                return Created("", produto);
            }
            catch (Exception ex) { 
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateProductRequest request) {
            try
            {
                var productUpdate = productService.UpdateProduct(id, request);
                return Ok(productUpdate);
            } 
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }

        }
    }
}

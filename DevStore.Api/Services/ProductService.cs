using DevStore.Api.DTOs;
using DevStore.Api.Data;
using DevStore.Api.Models;

namespace DevStore.Api.Services
{
    public class ProductService
    {
        private readonly AppDbContext context;

        public ProductService(AppDbContext context)
        {
            this.context = context;
        }

        public ProductResponseDto CreateProduct(CreateProductRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
                throw new Exception("Nome inválido");

            if (request.Price <= 0)
                throw new Exception("Valor inválido");

            if (request.Stock < 0)
                throw new Exception("O estoque não pode ter um valor menor do que zero.");

            var produto = new Product
            {
                Name = request.Name,
                Price = request.Price,
                Stock = request.Stock
            };

            context.Products.Add(produto);
            context.SaveChanges();

            return MapToResponseDto(produto);
        }

        public List<ProductResponseDto> GetAll()
        {
            var listDbProducts = context.Products.ToList();

            List<ProductResponseDto> listaProdutos = new();

            foreach (var produto in listDbProducts)
                listaProdutos.Add(MapToResponseDto(produto));

            return listaProdutos;
        }

        public ProductResponseDto? GetById(int id)
        {
            var product = context.Products.FirstOrDefault(a => a.Id == id);

            if (product == null)
                return null;

            return MapToResponseDto(product);

        }

        public ProductResponseDto? UpdateProduct(int id, UpdateProductRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
                throw new Exception("Nome inválido");

            if (request.Price <= 0)
                throw new Exception("Preço inválido");

            if (request.Stock < 0)
                throw new Exception("Valor inválido para estoque");

            var product = context.Products.FirstOrDefault(p => p.Id == id);

            if (product == null)
                return null;

            product.Name = request.Name;
            product.Price = request.Price;
            product.Stock = request.Stock;

            context.SaveChanges();

            return MapToResponseDto(product);
            

        }

        public bool DeleteProduct(int id)
        {

            var produto =  context.Products.FirstOrDefault(p => p.Id == id);
            if (produto == null)
                return false;
            else { 
                context.Products.Remove(produto);
                context.SaveChanges();
            }

            return true;
        }

        private ProductResponseDto MapToResponseDto(Product product)
        {
            var responseProduct = new ProductResponseDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock,
            };

            return responseProduct;
        }
    }
}

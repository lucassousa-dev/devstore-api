using DevStore.Api.DTOs;
using DevStore.Api.Models;

namespace DevStore.Api.Services
{
    public class ProductService
    {
        private static List<Product> produtos = new();

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
                Id = produtos.Count + 1,
                Name = request.Name,
                Price = request.Price,
                Stock = request.Stock
            };

            produtos.Add(produto);

            return MapToResponseDto(produto);
        }

        public List<ProductResponseDto> GetAll()
        {
            List<ProductResponseDto> listaProdutos = new();

            foreach (var produto in produtos)
                listaProdutos.Add(MapToResponseDto(produto));

            return listaProdutos;
        }

        public ProductResponseDto? GetById(int id)
        {
            foreach (var produto in produtos)
            {
                if(produto.Id == id) 
                    return MapToResponseDto(produto);
            }
            return null;
        }

        public ProductResponseDto? UpdateProduct(int id, UpdateProductRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
                throw new Exception("Nome inválido");

            if (request.Price <= 0)
                throw new Exception("Preço inválido");

            if (request.Stock < 0)
                throw new Exception("Valor inválido para estoque");

            foreach (var produto in produtos)
            {
                if (produto.Id == id) 
                {
                    produto.Name = request.Name;
                    produto.Price = request.Price;
                    produto.Stock = request.Stock;

                    return MapToResponseDto(produto);
                }
            }

            return null;
        }

        public bool DeleteProduct(int id)
        {
            Product? produtoEncontrado = null;

            foreach (var produto in produtos)
            {

                if (produto.Id == id)
                {
                    produtoEncontrado = produto;
                    break;
                }
            }

            if (produtoEncontrado == null)
                return false;


            produtos.Remove(produtoEncontrado);
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

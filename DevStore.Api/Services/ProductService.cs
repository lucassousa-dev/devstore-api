using DevStore.Api.DTOs;
using DevStore.Api.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace DevStore.Api.Services
{
    public class ProductService
    {
        private static List<Product> produtos = new();
        public Product CreateProduct(CreateProductRequest request)
        {
            if (request.Name == null)
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

            return produto;
        }

        public List<Product> GetAll()
        {
            return produtos;
        }

        public Product? GetById(int id)
        {
            foreach (var produto in produtos)
            {
                if(produto.Id == id)
                    return produto;

            }
            return null;
        }
    }
}

using DevStore.Api.DTOs;
using DevStore.Api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Runtime.CompilerServices;

namespace DevStore.Api.Services
{
    public class ProductService
    {
        private static List<Product> produtos = new();

        public ProductResponseDto CreateProduct(CreateProductRequest request)
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

            var responseProduct = new ProductResponseDto
            {
                Id = produto.Id,
                Name = produto.Name,
                Price = produto.Price,
                Stock = produto.Stock
            };

            return responseProduct;
        }

        public List<ProductResponseDto> GetAll()
        {
            List<ProductResponseDto> listaProdutos = new();

            foreach (var produto in produtos)
            {
                var responseProduct = new ProductResponseDto
                {
                    Id = produto.Id,
                    Name = produto.Name,
                    Price = produto.Price,
                    Stock = produto.Stock
                };

                listaProdutos.Add(responseProduct);
            }

            return listaProdutos;
        }

        public ProductResponseDto? GetById(int id)
        {
            foreach (var produto in produtos)
            {
                if(produto.Id == id) {
                    var responseProduct = new ProductResponseDto
                    {
                        Id = produto.Id,
                        Name = produto.Name,
                        Price = produto.Price,
                        Stock = produto.Stock
                    };
                    return responseProduct;
                }

            }
            return null;
        }

        public ProductResponseDto? UpdateProduct(int id, UpdateProductRequest request)
        {
            foreach (var produto in produtos)
            {
                if (produto.Id == id) 
                {
                    produto.Name = request.Name;
                    produto.Price = request.Price;
                    produto.Stock = request.Stock;

                    var responseProduct = new ProductResponseDto
                    {
                        Id = produto.Id,
                        Name = produto.Name,
                        Price = produto.Price,
                        Stock = produto.Stock,
                    };

                    return responseProduct;
                }
            }

            return null;
        }
    }
}

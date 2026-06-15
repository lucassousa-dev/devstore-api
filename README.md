# DevStore.Api

API REST desenvolvida em ASP.NET Core como parte do meu aprendizado em desenvolvimento back-end com C#, Entity Framework Core e SQL Server.

O objetivo do projeto é praticar a construção de uma API organizada, com separação de responsabilidades, uso de DTOs, Services, Entity Framework Core, migrations, relacionamento entre entidades e retornos HTTP adequados.

## Tecnologias utilizadas

- C#
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- SQL Server Management Studio
- Postman
- Git e GitHub

## Funcionalidades implementadas

### Produtos

- Criar produto
- Listar produtos
- Buscar produto por ID
- Atualizar produto
- Remover produto
- Validar dados de entrada
- Relacionar produto com categoria
- Retornar nome da categoria junto ao produto

### Categorias

- Criar categoria
- Listar categorias
- Buscar categoria por ID
- Atualizar categoria
- Remover categoria
- Validar dados de entrada

## Estrutura do projeto

```txt
DevStore.Api/
├── Controllers/
│   ├── ProductsController.cs
│   └── CategoriesController.cs
│
├── Data/
│   └── AppDbContext.cs
│
├── DTOs/
│   ├── CreateProductRequest.cs
│   ├── UpdateProductRequest.cs
│   ├── ProductResponseDto.cs
│   ├── CreateCategoryRequest.cs
│   ├── UpdateCategoryRequest.cs
│   └── CategoryResponseDto.cs
│
├── Models/
│   ├── Product.cs
│   └── Category.cs
│
├── Services/
│   ├── ProductService.cs
│   └── CategoryService.cs
│
├── Migrations/
├── Program.cs
└── appsettings.json
```

## Conceitos praticados

- Criação de APIs REST com ASP.NET Core
- Controllers e rotas HTTP
- DTOs de entrada e saída
- Services para regras de negócio
- Injeção de dependência
- Entity Framework Core
- DbContext e DbSet
- Migrations
- Relacionamento entre tabelas
- Foreign Key
- Validações básicas
- Retornos HTTP adequados
- Testes manuais com Postman

## Relacionamento entre entidades

O projeto possui relacionamento entre produtos e categorias.

Uma categoria pode ter vários produtos, e cada produto pertence a uma categoria.

```txt
Category 1 → N Products
```

Na entidade `Product`, o relacionamento é representado por:

```csharp
public int CategoryId { get; set; }
public Category Category { get; set; } = null!;
```

## Endpoints principais

### Produtos

```txt
GET    /api/products
GET    /api/products/{id}
POST   /api/products
PUT    /api/products/{id}
DELETE /api/products/{id}
```

### Categorias

```txt
GET    /api/categories
GET    /api/categories/{id}
POST   /api/categories
PUT    /api/categories/{id}
DELETE /api/categories/{id}
```

## Exemplos de requisição

### Criar categoria

```json
{
  "name": "Eletrônicos"
}
```

### Criar produto

```json
{
  "name": "Mouse Gamer",
  "price": 150.00,
  "stock": 10,
  "categoryId": 1
}
```

### Resposta de produto

```json
{
  "id": 1,
  "name": "Mouse Gamer",
  "price": 150.00,
  "stock": 10,
  "categoryId": 1,
  "categoryName": "Eletrônicos"
}
```

## Como executar o projeto

### Pré-requisitos

- .NET SDK instalado
- SQL Server instalado
- SQL Server Management Studio ou ferramenta equivalente
- Visual Studio ou editor compatível com C#

### Configurar conexão com banco

No arquivo `appsettings.json`, configure a connection string:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost\\MSSQLSERVER01;Database=DevStoreDb;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

Ajuste o nome do servidor conforme a instância do SQL Server instalada na máquina.

### Aplicar migrations

No terminal, dentro da pasta do projeto, execute:

```bash
dotnet ef database update
```

### Executar a API

```bash
dotnet run
```

A API será iniciada em uma URL local informada no terminal, como:

```txt
https://localhost:7013
```

## Status do projeto

Projeto em desenvolvimento para estudo e evolução técnica em ASP.NET Core.

Funcionalidades já implementadas:

- CRUD de produtos
- CRUD de categorias
- Banco de dados com SQL Server
- Entity Framework Core
- Relacionamento entre produtos e categorias
- DTOs
- Services
- Validações básicas
- Testes manuais com Postman

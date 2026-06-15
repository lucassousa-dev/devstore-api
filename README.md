# DevStore.Api

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?style=for-the-badge&logo=microsoftsqlserver&logoColor=white)
![Entity Framework Core](https://img.shields.io/badge/Entity%20Framework%20Core-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)

API REST desenvolvida em **ASP.NET Core** para gerenciamento de **produtos** e **categorias**, com persistência em **SQL Server** utilizando **Entity Framework Core**.

O projeto foi criado como parte do meu processo de consolidação em desenvolvimento back-end com **C#/.NET**, aplicando conceitos como organização em camadas, DTOs, Services, validações, migrations, relacionamento entre entidades e retornos HTTP adequados.

---

## Status do projeto

✅ **Versão de estudo concluída**

A DevStore.Api atingiu seu objetivo principal: praticar a construção de uma API REST em ASP.NET Core com CRUD, DTOs, Services, Entity Framework Core, SQL Server, migrations e relacionamento entre entidades.

O projeto pode receber melhorias futuras, mas a versão atual já cumpre seu papel como projeto de consolidação dos fundamentos de back-end em C#/.NET.

---

## Objetivo

Construir uma API de estudo com escopo controlado, mas organizada o suficiente para praticar fundamentos usados em projetos reais de back-end:

- criação de endpoints REST;
- separação entre Controllers, Services, DTOs, Models e Data;
- validação de dados de entrada;
- persistência com Entity Framework Core;
- relacionamento 1:N entre categorias e produtos;
- migrations e criação de banco no SQL Server;
- testes manuais com Postman.

---

## Tecnologias utilizadas

- **C#**
- **.NET**
- **ASP.NET Core Web API**
- **Entity Framework Core**
- **SQL Server**
- **SQL Server Management Studio**
- **Postman**
- **Git e GitHub**

---

## Funcionalidades implementadas

### Produtos

- Criar produto
- Listar produtos
- Buscar produto por ID
- Atualizar produto
- Remover produto
- Validar dados de entrada
- Relacionar produto com categoria
- Retornar o nome da categoria junto ao produto

### Categorias

- Criar categoria
- Listar categorias
- Buscar categoria por ID
- Atualizar categoria
- Remover categoria
- Validar dados de entrada

---

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

---

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

---

## Decisões técnicas

- A API foi organizada separando **Controllers**, **Services**, **DTOs**, **Models** e camada de **Data**.
- Os **Controllers** ficaram responsáveis por receber as requisições e retornar respostas HTTP.
- Os **Services** concentram as regras de negócio e validações principais.
- Os **DTOs** foram utilizados para separar os dados recebidos e retornados pela API das entidades do banco.
- O **Entity Framework Core** foi utilizado para persistência dos dados e criação das migrations.
- O relacionamento entre produtos e categorias foi implementado para praticar associação **1:N** entre entidades.

---

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

---

## Endpoints principais

### Produtos

| Método | Rota | Descrição |
|---|---|---|
| `GET` | `/api/products` | Lista todos os produtos |
| `GET` | `/api/products/{id}` | Busca um produto pelo ID |
| `POST` | `/api/products` | Cria um novo produto |
| `PUT` | `/api/products/{id}` | Atualiza um produto existente |
| `DELETE` | `/api/products/{id}` | Remove um produto |

### Categorias

| Método | Rota | Descrição |
|---|---|---|
| `GET` | `/api/categories` | Lista todas as categorias |
| `GET` | `/api/categories/{id}` | Busca uma categoria pelo ID |
| `POST` | `/api/categories` | Cria uma nova categoria |
| `PUT` | `/api/categories/{id}` | Atualiza uma categoria existente |
| `DELETE` | `/api/categories/{id}` | Remove uma categoria |

---

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

---

## Como executar o projeto

### Pré-requisitos

- .NET SDK instalado
- SQL Server instalado
- SQL Server Management Studio ou ferramenta equivalente
- Visual Studio, VS Code ou editor compatível com C#

### 1. Clone o repositório

```bash
git clone https://github.com/lucassousa-dev/devstore-api.git
```

### 2. Acesse a pasta do projeto

```bash
cd devstore-api/DevStore.Api
```

### 3. Configure a conexão com o banco

No arquivo `appsettings.json`, configure a connection string conforme a instância do seu SQL Server:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost\\MSSQLSERVER01;Database=DevStoreDb;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

> Ajuste o nome do servidor conforme a instância do SQL Server instalada na sua máquina.

### 4. Aplique as migrations

No terminal, dentro da pasta do projeto, execute:

```bash
dotnet ef database update
```

### 5. Execute a API

```bash
dotnet run
```

A API será iniciada em uma URL local informada no terminal, por exemplo:

```txt
https://localhost:7013
```

---

## Testes manuais

Os endpoints foram testados manualmente com **Postman**, validando os principais fluxos:

- criação de categorias;
- criação de produtos vinculados a categorias;
- listagem de produtos e categorias;
- busca por ID;
- atualização;
- remoção;
- validações básicas;
- retorno do nome da categoria junto ao produto.

---

## Próximos passos possíveis

Este projeto foi desenvolvido como estudo de fundamentos em ASP.NET Core. Algumas melhorias possíveis seriam:

- Implementar tratamento global de exceções
- Converter operações para métodos assíncronos
- Criar interfaces para os Services
- Criar camada de Repository
- Implementar paginação e filtros na listagem de produtos
- Melhorar validações com Data Annotations ou FluentValidation
- Adicionar testes automatizados
- Criar autenticação com JWT

---

## Autor

**Lucas G. Sousa**

- LinkedIn: [linkedin.com/in/lucassousads](https://www.linkedin.com/in/lucassousads/)
- GitHub: [github.com/lucassousa-dev](https://github.com/lucassousa-dev)

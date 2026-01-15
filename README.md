# 🏪 Pantry Management System

![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=for-the-badge&logo=dotnet)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)
![Docker](https://img.shields.io/badge/Docker-2496ED?style=for-the-badge&logo=docker&logoColor=white)

Sistema de gerenciamento de despensa desenvolvido com ASP.NET Core, permitindo controle completo de produtos, compradores e usuários através de uma API RESTful robusta e escalável.

---

## 📋 Índice

- [Sobre o Projeto](#sobre-o-projeto)
- [Tecnologias Utilizadas](#tecnologias-utilizadas)
- [Arquitetura](#arquitetura)
- [Pré-requisitos](#pré-requisitos)
- [Instalação e Configuração](#instalação-e-configuração)
- [Documentação da API](#documentação-da-api)
- [Estrutura do Projeto](#estrutura-do-projeto)
- [Segurança](#segurança)

---

## 🎯 Sobre o Projeto

O **Pantry Management System** é uma API REST desenvolvida para gerenciar produtos de despensa, seus compradores e usuários do sistema. O projeto implementa:

- ✅ Relacionamento 1:N entre Buyers e Products
- ✅ DTOs para proteção de dados sensíveis
- ✅ Repository Pattern para abstração de dados
- ✅ Entity Framework Core com Code First
- ✅ Containerização com Docker
- ✅ Documentação automática com Swagger

---

## 🚀 Tecnologias Utilizadas

### Backend
- **ASP.NET Core 8.0** - Framework web moderno e performático
- **C# 12** - Linguagem de programação
- **Entity Framework Core 8** - ORM para acesso a dados
- **SQL Server** (Azure SQL Edge) - Banco de dados relacional

### Ferramentas e Bibliotecas
- **Swagger/OpenAPI** - Documentação interativa da API
- **Docker & Docker Compose** - Containerização e orquestração
- **Entity Framework Tools** - Migrations e gerenciamento de schema

### Padrões de Projeto
- **Repository Pattern** - Abstração da camada de dados
- **Dependency Injection** - Inversão de controle
- **DTO (Data Transfer Object)** - Proteção de dados sensíveis

---

## 🏗️ Arquitetura

```
PantryManagement/
│
├── Controllers/          # Endpoints da API
│   └── DTO/             # Data Transfer Objects
│
├── Models/              # Entidades do domínio
│
├── Repository/          # Camada de acesso a dados
│   ├── Context/        # DbContext e configurações
│   └── Interfaces/     # Contratos dos repositórios
│
└── Migrations/          # Histórico de alterações do BD
```

### Relacionamentos
```
User (1) ────────────────────────> Sistema

Buyer (1) ──────< (N) Products
```

---

## ⚙️ Pré-requisitos

Antes de começar, certifique-se de ter instalado:

- [.NET SDK 8.0](https://dotnet.microsoft.com/download/dotnet/8.0) ou superior
- [Docker](https://www.docker.com/get-started) e Docker Compose
- [Git](https://git-scm.com/downloads)
- (Opcional) [DBeaver](https://dbeaver.io/) ou outra ferramenta de BD

---

## 🔧 Instalação e Configuração

### 1️⃣ Clone o repositório

```bash
git clone https://github.com/seu-usuario/PantryManagement.git
cd PantryManagement
```

### 2️⃣ Suba o container do SQL Server

```bash
docker-compose up -d
```

Aguarde cerca de 10-20 segundos para o SQL Server inicializar completamente.

### 3️⃣ Execute as Migrations

```bash
# Restaurar dependências
dotnet restore

# Criar as tabelas no banco de dados
dotnet ef database update
```

### 4️⃣ Execute a aplicação

```bash
dotnet run
```

A API estará disponível em:
- **HTTP**: `http://localhost:5000`
- **HTTPS**: `https://localhost:5001`
- **Swagger UI**: `https://localhost:5001/swagger`

---

## 📚 Documentação da API

### 🔹 Users

#### Listar todos os usuários
```http
GET /users
```

**Resposta (200 OK):**
```json
[
  {
    "userId": 1,
    "userName": "João Silva",
    "userEmail": "joao@example.com"
  }
]
```

---

#### Buscar usuário por ID
```http
GET /users/{userId}
```

**Resposta (200 OK):**
```json
{
  "userId": 1,
  "userName": "João Silva",
  "userEmail": "joao@example.com"
}
```

**Resposta de Erro (404 Not Found):**
```json
{
  "message": "User not found"
}
```

---

#### Criar novo usuário
```http
POST /users
Content-Type: application/json
```

**Body:**
```json
{
  "userName": "João Silva",
  "userEmail": "joao@example.com",
  "userPassword": "senha123"
}
```

**Resposta (201 Created):**
```json
{
  "userId": 1,
  "userName": "João Silva",
  "userEmail": "joao@example.com"
}
```

> ⚠️ **Nota de Segurança**: A senha nunca é retornada nas respostas da API.

---

#### Deletar usuário
```http
DELETE /users/{userId}
```

**Resposta (204 No Content):** Sem corpo de resposta.

---

### 🔹 Buyers (Compradores)

#### Listar todos os compradores
```http
GET /buyers
```

**Resposta (200 OK):**
```json
[
  {
    "buyerId": 1,
    "buyerName": "Maria Santos",
    "buyerContactInfo": "(11) 98765-4321"
  }
]
```

---

#### Buscar comprador por ID
```http
GET /buyers/{buyerId}
```

**Resposta (200 OK):**
```json
{
  "buyerId": 1,
  "buyerName": "Maria Santos",
  "buyerContactInfo": "(11) 98765-4321"
}
```

---

#### Criar novo comprador
```http
POST /buyers
Content-Type: application/json
```

**Body:**
```json
{
  "buyerName": "Maria Santos",
  "buyerContactInfo": "(11) 98765-4321"
}
```

**Resposta (201 Created):**
```json
{
  "buyerId": 1,
  "buyerName": "Maria Santos",
  "buyerContactInfo": "(11) 98765-4321"
}
```

---

#### Deletar comprador
```http
DELETE /buyers/{buyerId}
```

**Resposta (204 No Content):** Sem corpo de resposta.

> ⚠️ **Atenção**: Deletar um comprador também remove todos os produtos associados (Cascade Delete).

---

#### Listar produtos de um comprador
```http
GET /buyers/{buyerId}/products
```

**Resposta (200 OK):**
```json
[
  {
    "productId": 1,
    "productName": "Arroz Integral",
    "productQuantity": 5,
    "buyerId": 1,
    "expiresIn": "2026-06-15T00:00:00"
  }
]
```

---

#### Adicionar produto existente a um comprador
```http
POST /buyers/{buyerId}/products/{productId}
```

**Resposta (200 OK):**
```json
{
  "buyerId": 1,
  "buyerName": "Maria Santos",
  "buyerContactInfo": "(11) 98765-4321"
}
```

> 📝 **Nota**: Este endpoint transfere a propriedade de um produto para um novo comprador.

---

### 🔹 Products (Produtos)

#### Listar todos os produtos
```http
GET /products
```

**Resposta (200 OK):**
```json
[
  {
    "productId": 1,
    "productName": "Arroz Integral",
    "productQuantity": 5,
    "buyerId": 1,
    "expiresIn": "2026-06-15T00:00:00"
  }
]
```

---

#### Buscar produto por ID
```http
GET /products/{productId}
```

**Resposta (200 OK):**
```json
{
  "productId": 1,
  "productName": "Arroz Integral",
  "productQuantity": 5,
  "buyerId": 1,
  "expiresIn": "2026-06-15T00:00:00"
}
```

---

#### Criar novo produto
```http
POST /products
Content-Type: application/json
```

**Body:**
```json
{
  "productName": "Arroz Integral",
  "productQuantity": 5,
  "buyerId": 1,
  "expiresIn": "2026-06-15T00:00:00"
}
```

**Resposta (201 Created):**
```json
{
  "productId": 1,
  "productName": "Arroz Integral",
  "productQuantity": 5,
  "buyerId": 1,
  "expiresIn": "2026-06-15T00:00:00"
}
```

---

#### Deletar produto
```http
DELETE /products/{productId}
```

**Resposta (204 No Content):** Sem corpo de resposta.

---

#### Buscar comprador de um produto
```http
GET /products/{productId}/buyer
```

**Resposta (200 OK):**
```json
{
  "buyerId": 1,
  "buyerName": "Maria Santos",
  "buyerContactInfo": "(11) 98765-4321"
}
```

---

## 📂 Estrutura do Projeto

```
PantryManagement/
│
├── 📁 Controllers/
│   ├── BuyerController.cs         # Endpoints de compradores
│   ├── ProductController.cs       # Endpoints de produtos
│   ├── UserController.cs          # Endpoints de usuários
│   └── 📁 DTO/
│       ├── BuyerDTO.cs           # DTO para criar buyer
│       ├── BuyerResponseDTO.cs   # DTO para resposta de buyer
│       ├── ProductDTO.cs         # DTO de produto
│       ├── UserDTO.cs            # DTO de usuário (sem senha)
│       └── UserCreateDTO.cs      # DTO para criar usuário
│
├── 📁 Models/
│   ├── Buyer.cs                  # Entidade Comprador
│   ├── Product.cs                # Entidade Produto
│   └── User.cs                   # Entidade Usuário
│
├── 📁 Repository/
│   ├── BuyerRepository.cs        # Lógica de acesso - Buyers
│   ├── ProductRepository.cs      # Lógica de acesso - Products
│   ├── UserRepository.cs         # Lógica de acesso - Users
│   │
│   ├── 📁 Context/
│   │   ├── IPantryManagementContext.cs
│   │   └── PantryManagementContext.cs  # DbContext principal
│   │
│   └── 📁 Interfaces/
│       ├── IBuyerRepository.cs
│       ├── IProductRepository.cs
│       └── IUserRepository.cs
│
├── 📁 Migrations/                # Histórico do banco de dados
│
├── Program.cs                    # Configuração da aplicação
├── appsettings.json             # Configurações gerais
├── docker-compose.yml           # Configuração do Docker
└── README.md                    # Este arquivo
```

---

## 🔒 Segurança

### Proteção de Dados Sensíveis

O projeto implementa DTOs (Data Transfer Objects) para proteger dados sensíveis:

#### ✅ Senhas Nunca São Retornadas
```csharp
// ❌ Model completa (NUNCA retornada)
public class User {
    public string UserPassword { get; set; }  // Sensível
}

// ✅ DTO seguro (retornado na API)
public class UserDTO {
    // UserPassword omitido
    public string UserName { get; set; }
    public string UserEmail { get; set; }
}
```

#### ✅ Prevenção de Referências Circulares
```csharp
// ❌ Pode causar loop infinito na serialização
public class Buyer {
    public List<Product> ListProducts { get; set; }
}

public class Product {
    public Buyer Buyer { get; set; }
}

// ✅ DTOs removem navegações
public class BuyerResponseDTO {
    // ListProducts omitido
}

public class ProductDTO {
    public int BuyerId { get; set; }  // Apenas ID
    // Buyer omitido
}
```

---

## 🗄️ Configuração do Banco de Dados

### Connection String
```csharp
Server=127.0.0.1;
Database=PantryManagementDB;
User=SA;
Password=PantryManagementDB123!;
TrustServerCertificate=true
```

### Conectar ao SQL Server via DBeaver

1. **Host**: `localhost`
2. **Port**: `1433`
3. **Database**: `master` (ou `PantryManagementDB`)
4. **Username**: `SA`
5. **Password**: `PantryManagementDB123!`
6. ✅ Marque "Trust Server Certificate"

---

## 🐳 Docker

### Gerenciar o Container

```bash
# Iniciar o banco de dados
docker-compose up -d

# Ver logs do container
docker logs sql_server_db

# Parar o container
docker-compose down

# Parar e remover volumes (⚠️ deleta dados)
docker-compose down -v

# Verificar status
docker ps
```

---

## 🛠️ Comandos Úteis

### Entity Framework

```bash
# Criar nova migration
dotnet ef migrations add NomeDaMigration

# Aplicar migrations
dotnet ef database update

# Reverter última migration
dotnet ef migrations remove

# Ver SQL gerado
dotnet ef migrations script
```

### Build e Execução

```bash
# Restaurar dependências
dotnet restore

# Compilar o projeto
dotnet build

# Executar a aplicação
dotnet run

# Executar com hot reload
dotnet watch run
```

---

## 📊 Códigos de Status HTTP

| Código | Significado | Quando acontece |
|--------|-------------|-----------------|
| **200** | OK | Requisição bem-sucedida (GET) |
| **201** | Created | Recurso criado com sucesso (POST) |
| **204** | No Content | Recurso deletado com sucesso (DELETE) |
| **400** | Bad Request | Dados inválidos na requisição |
| **404** | Not Found | Recurso não encontrado |

---

## 🧪 Testando a API

### Usando cURL

```bash
# Criar um comprador
curl -X POST http://localhost:5000/buyers \
  -H "Content-Type: application/json" \
  -d '{"buyerName":"Maria Santos","buyerContactInfo":"(11) 98765-4321"}'

# Listar todos os compradores
curl http://localhost:5000/buyers

# Criar um produto
curl -X POST http://localhost:5000/products \
  -H "Content-Type: application/json" \
  -d '{"productName":"Arroz","productQuantity":5,"buyerId":1,"expiresIn":"2026-06-15"}'
```

### Usando Swagger UI

1. Acesse `https://localhost:5001/swagger`
2. Explore todos os endpoints disponíveis
3. Teste diretamente pela interface interativa

---

## 🤝 Contribuindo

Contribuições são bem-vindas! Sinta-se à vontade para:

1. Fazer fork do projeto
2. Criar uma branch para sua feature (`git checkout -b feature/NovaFeature`)
3. Commit suas mudanças (`git commit -m 'Adiciona nova feature'`)
4. Push para a branch (`git push origin feature/NovaFeature`)
5. Abrir um Pull Request

---

## 📝 Licença

Este projeto está sob a licença MIT. Veja o arquivo `LICENSE` para mais detalhes.

---

## 👨‍💻 Autor

**Avner Henrique**

- GitHub: [@avnerhenrique](https://github.com/avnerhenrique)
- LinkedIn: [Avner Henrique](https://linkedin.com/in/avnerhenrique)

---

## 🙏 Agradecimentos

- Comunidade .NET
- Microsoft Entity Framework Team
- Contribuidores open source

---

<div align="center">

### ⭐ Se este projeto foi útil para você, considere dar uma estrela!

**Desenvolvido com ❤️ usando ASP.NET Core**

</div>

# 📦 Estoque API

API REST desenvolvida com ASP.NET Core para controle de estoque.

## 🚀 Tecnologias
- ASP.NET Core
- Entity Framework Core
- MySQL
- Swagger

## 🔥 Funcionalidades
- Cadastro de produtos
- Atualização de estoque
- Exclusão de produtos
- Controle de disponibilidade

## 🧠 Conceitos utilizados
- DTOs
- Services
- Mapper
- Async/Await
- Migrations

## 📷 Demonstração

### Swagger
![Swagger](Images/swagger.png)

### Exemplo de retorno da API
![Response](Images/get-all.png)

## ▶ Como executar

1. Configure a connection string
2. Execute as migrations
3. Rode o projeto

```bash
dotnet ef database update
dotnet run
```
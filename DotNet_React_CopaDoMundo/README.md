# ⚽ API REST de Futebol — Clubes, Seleções e Jogadores

> Web API RESTful desenvolvida com **ASP.NET Core (.NET 10)** e **C#**, voltada para o gerenciamento de **Clubes**, **Seleções** e **Jogadores**, seguindo boas práticas de arquitetura, organização de código e desenvolvimento de APIs modernas.

---

# 📌 Sobre o Projeto

Este projeto consiste em uma API backend responsável pelo gerenciamento completo de Clubes, Seleções e Jogadores de futebol.

A aplicação implementa operações completas de **CRUD (Create, Read, Update e Delete)**, utilizando relacionamentos do tipo **1:N**, onde um Clube ou uma Seleção pode possuir diversos jogadores.

O projeto foi desenvolvido com foco em aprendizado e boas práticas do ecossistema .NET, priorizando organização do código, separação de responsabilidades e facilidade de manutenção.

---

# ✨ Destaques

- ✅ Arquitetura em Camadas (Controllers, Services, DTOs e Data)
- ✅ Entity Framework Core com SQLite
- ✅ CRUD completo para Clubes, Seleções e Jogadores
- ✅ Relacionamentos 1:N
- ✅ Operações assíncronas com Async/Await
- ✅ Tratamento global de exceções via Middleware
- ✅ Injeção de Dependência (Dependency Injection)
- ✅ Documentação interativa com Swagger
- ✅ Configuração de CORS para integração com aplicações Front-End

---

# 🛠️ Tecnologias Utilizadas

| Categoria | Tecnologia |
|------------|------------|
| Linguagem | C# |
| Framework | ASP.NET Core Web API (.NET 10) |
| Banco de Dados | SQLite |
| ORM | Entity Framework Core |
| Documentação | Swagger / OpenAPI |
| Controle de Versão | Git + GitHub |
| IDE | Visual Studio Code |

---

# 📦 Pacotes NuGet

- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.Sqlite
- Microsoft.EntityFrameworkCore.Design
- Microsoft.EntityFrameworkCore.Tools

---

# 🏛️ Arquitetura

O projeto foi estruturado utilizando uma arquitetura em camadas, separando cada responsabilidade da aplicação.

```
Controllers
        │
        ▼
Services
        │
        ▼
Entity Framework Core
        │
        ▼
SQLite
```

## Controllers

Responsáveis por receber as requisições HTTP, validar a entrada de dados e delegar toda a regra de negócio para os Services.

---

## Services

Contêm toda a lógica de negócio da aplicação.

São responsáveis por:

- consultar o banco;
- validar regras;
- criar, atualizar e remover registros;
- converter entidades em DTOs.

---

## DTOs (Data Transfer Objects)

Os DTOs são utilizados para evitar o envio direto das entidades do banco de dados.

Foram implementados:

- CreateDto
- UpdateDto
- ResponseDto
- DTOs de Resumo (Relacionamentos)

---

## Middleware

A aplicação possui um Middleware personalizado responsável por realizar o tratamento global de exceções, retornando respostas padronizadas para a API.

---

## Dependency Injection

Toda a aplicação utiliza a Injeção de Dependência nativa do ASP.NET Core para reduzir acoplamento entre as classes.

---

## Async / Await

Todas as operações de acesso ao banco foram implementadas utilizando métodos assíncronos, evitando o bloqueio desnecessário de operações de I/O.

---

# 🚀 Funcionalidades

## Seleções

- ✅ Listar
- ✅ Buscar por Id
- ✅ Cadastrar
- ✅ Atualizar
- ✅ Excluir

---

## Clubes

- ✅ Listar
- ✅ Buscar por Id
- ✅ Cadastrar
- ✅ Atualizar
- ✅ Excluir

---

## Jogadores

- ✅ Listar
- ✅ Buscar por Id
- ✅ Cadastrar
- ✅ Atualizar
- ✅ Excluir

---

## Recursos adicionais

- ✅ Relacionamentos 1:N
- ✅ Entity Framework Core
- ✅ SQLite
- ✅ Migrations
- ✅ DTO Pattern
- ✅ Services
- ✅ Middleware
- ✅ Swagger
- ✅ CORS

---

# 📂 Estrutura do Projeto

```text
ProjetoCopa
│
├── DotNet_React_CopaDoMundo
│   ├── Controllers
│   ├── DTOs
│   ├── Data
│   ├── Middlewares
│   ├── Migrations
│   ├── Models
│   ├── Services
│   ├── Program.cs
│   └── appsettings.json
│
└── CopaDoMundo_Frontend
    
```

---

# 🔗 Endpoints

## Seleções

| Método | Endpoint |
|---------|----------|
| GET | `/api/Selecao` |
| GET | `/api/Selecao/{id}` |
| POST | `/api/Selecao` |
| PUT | `/api/Selecao/{id}` |
| DELETE | `/api/Selecao/{id}` |

---

## Clubes

| Método | Endpoint |
|---------|----------|
| GET | `/api/Clube` |
| GET | `/api/Clube/{id}` |
| POST | `/api/Clube` |
| PUT | `/api/Clube/{id}` |
| DELETE | `/api/Clube/{id}` |

---

## Jogadores

| Método | Endpoint |
|---------|----------|
| GET | `/api/Jogador` |
| GET | `/api/Jogador/{id}` |
| POST | `/api/Jogador` |
| PUT | `/api/Jogador/{id}` |
| DELETE | `/api/Jogador/{id}` |

---

# 📂 Como Executar

## Pré-requisitos

- .NET 10 SDK
- Git

---

## Clone o projeto

```bash
git clone https://github.com/44mgl/ProjetoCopa.git
```

Entre na pasta do backend:

```bash
cd ProjetoCopa/DotNet_React_CopaDoMundo
```

---

## Restaurar dependências

```bash
dotnet restore
```

---

## Criar o banco

```bash
dotnet ef database update
```

---

## Executar a API

```bash
dotnet run
```

---

## Acessar o Swagger

```
https://localhost:{porta}/swagger
```

---

# 👨‍💻 Autor

**Miguel Amores**

Estudante de Sistemas de Informação e desenvolvedor em formação, focado em desenvolvimento Back-End com C#/.NET e aplicações Full Stack.

GitHub:
https://github.com/44mgl
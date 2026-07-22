# ⚽ API CRUD de Seleções (Clubes, Seleções e Jogadores)

> Uma Web API RESTful robusta desenvolvida em **.NET 10** e **C#**, focada na gestão e relacionamento entre seleções, clubes e jogadores de futebol.

---

## 📌 Sobre o Projeto

Este projeto foi desenvolvido como uma API backend moderna seguindo boas práticas de arquitetura e design de código. Ele fornece endpoints para operações completas de CRUD de **Seleções**, **Clubes** e **Jogadores**, lidando com relacionamentos do tipo **1:N** (Um para Muitos) de forma assíncrona e performática.

### ✨ Diferenciais do Projeto
* **Arquitetura Limpa e Desacoplada:** Separação clara de responsabilidades utilizando DTOs, Services e Controllers.
* **Resiliência:** Tratamento global de exceções via Middleware customizado.
* **Documentação Viva:** Documentação completa e testável via Swagger UI.

---

## 🛠️ Tecnologias e Ferramentas

| Categoria | Tecnologia / Ferramenta |
| :--- | :--- |
| **Linguagem** | C# |
| **Framework** | .NET 10 / ASP.NET Core Web API |
| **Banco de Dados** | SQLite |
| **ORM** | Entity Framework Core |
| **Documentação** | Swagger / OpenAPI |
| **IDE / Ferramentas** | VS Code, Git, GitHub, SQLite, Swagger UI |

### 📦 Pacotes Nuget Utilizados

* `Microsoft.EntityFrameworkCore`
* `Microsoft.EntityFrameworkCore.Sqlite`
* `Microsoft.EntityFrameworkCore.Tools`
* `Microsoft.EntityFrameworkCore.Design`
* `Swashbuckle.AspNetCore` (Suporte OpenAPI)

---

## 🏛️ Arquitetura e Padrões de Projeto

A aplicação foi estruturada utilizando padrões recomendados no ecossistema .NET:

* **REST API:** Comunicação HTTP estruturada utilizando os verbos adequados (`GET`, `POST`, `PUT`, `DELETE`).
* **Controllers:** Camada responsável por expor os endpoints e gerenciar o fluxo das requisições.
* **Services:** Camada contendo as regras de negócio isoladas.
* **DTO Pattern (Data Transfer Objects):** Prevenção do vazamento de entidades internas e otimização dos dados trafegados.
* **Middleware:** Captura e tratamento global de exceções para respostas HTTP padronizadas.
* **Dependency Injection (DI):** Injeção de dependência nativa do ASP.NET Core para baixo acoplamento.
* **Async/Await:** Métodos 100% assíncronos para melhor aproveitamento de I/O e alta performance.

---

## 🚀 Recursos Implementados

- [x] **CRUD Completo de Seleções**
- [x] **CRUD Completo de Clubes**
- [x] **CRUD Completo de Jogadores**
- [x] **Relacionamentos 1:N** (ex: Um Clube/Seleção possui vários Jogadores)
- [x] **Persistência de Dados:** Entity Framework Core + Migrations com SQLite
- [x] **Tratamento Global de Exceções**
- [x] **Suporte a CORS** (Cross-Origin Resource Sharing)
- [x] **Documentação Interativa:** Swagger UI

---

## 📂 Como Executar o Projeto

### Pré-requisitos
* [.NET 10 SDK](https://dotnet.microsoft.com/download) instalado.
* [Git](https://git-scm.com/) instalado.

### Passo a Passo

1. **Clone o repositório:**
   ```bash
   git clone https://github.com/44mgl/ProjetoCopa.git
   
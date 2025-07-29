# Restful_Jwt_MVC_Repository-Pattern

Este projeto é uma API RESTful desenvolvida com **C#** e **ASP.NET MVC**, implementando autenticação com **JWT (JSON Web Token)** e utilizando o padrão de repositório (**Repository Pattern**) para separação de responsabilidades e melhor organização do código.

## 🛠️ Tecnologias Utilizadas

- C#  
- ASP.NET MVC  
- JWT (JSON Web Token)  
- Repository Pattern  
- Entity Framework Core  
- SQLite (apenas para simplificação do projeto demonstrativo)
- Swagger (para documentação da API)

## 🔐 Autenticação

O projeto utiliza autenticação baseada em **JWT** para proteger rotas e garantir o acesso seguro aos recursos da API. Após a autenticação, o token deve ser enviado no header das requisições seguintes:

## 🧱 Arquitetura

A arquitetura do projeto segue boas práticas de desenvolvimento, com camadas bem definidas:

- **Controllers:** Ponto de entrada das requisições HTTP.  
- **Data:** Camada de contexto e dados.  
- **Repositories:** Responsáveis pela comunicação com o banco de dados.  
- **Models / DTOs:** Estrutura das entidades e objetos de transferência de dados.  
- **Helpers:** Utilidades diversas.

## 🚀 Como Executar

Clone o repositório com o comando abaixo:
   ```bash
   git clone https://github.com/tiagogoncalvestg/ManagementTaskApp_Restful_Jwt_MVC_Repository-Pattern.git
```

## 📄 Documentação

Acesse a documentação interativa via Swagger em:

```bash
http://localhost:5040/swagger/index.html
```

## 📌 Funcionalidades

- Geração de token JWT

- Acesso a rotas protegidas com autenticação

- CRUD com Repository Pattern

- Validações básicas de entrada

- Separação clara de camadas (MVC)

## 🤝 Contribuições

Contribuições são bem-vindas! Sinta-se à vontade para abrir issues ou pull requests.


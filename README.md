🎬 MyFlix

Sistema de gerenciamento de filmes desenvolvido como desafio técnico utilizando ASP.NET Core 8, React, TypeScript, Entity Framework Core, SQLite e Docker.

O objetivo do projeto é permitir o cadastro, consulta, atualização e remoção de filmes, além do gerenciamento de status e avaliação de cada título.

🚀 Funcionalidades
  Cadastro de filmes
  Listagem de filmes
  Atualização de filmes
  Exclusão de filmes
  Controle de status:
  Quero Assistir
  Assistindo
  Assistido
  Avaliação de filmes (1 a 5 estrelas)
  Integração Frontend + Backend via API REST
  Persistência de dados com SQLite
  Containerização com Docker

🛠️ Tecnologias Utilizadas
  Backend
  ASP.NET Core 8
  Entity Framework Core
  SQLite
  FluentValidation
  Swagger
  Frontend
  React
  TypeScript
  Axios
  Vite
  DevOps
  Docker
  Git
  GitHub

📁 Estrutura do Projeto
  MyFlix
  │
  ├── backend
  │   └── MyFlix.Api
  │       ├── Controllers
  │       ├── Data
  │       ├── DTOs
  │       ├── Models
  │       ├── Services
  │       ├── Validators
  │       └── Migrations
  │
  └── frontend
      ├── components
      ├── pages
      ├── services
      ├── styles
      └── types
    
🏛️ Arquitetura
  ┌─────────────────┐
  │ React + Vite    │
  │ Frontend        │
  └────────┬────────┘
           │ HTTP / JSON
           ▼
  ┌─────────────────┐
  │ ASP.NET Core 8  │
  │ REST API        │
  └────────┬────────┘
           │
           ▼
  ┌─────────────────┐
  │ MovieService    │
  │ Business Layer  │
  └────────┬────────┘
           │
           ▼
  ┌─────────────────┐
  │ EntityFramework │
  │ Core            │
  └────────┬────────┘
           │
           ▼
  ┌─────────────────┐
  │ SQLite Database │
  └─────────────────┘

▶️ Como Executar
  Backend
  cd backend/MyFlix.Api
  dotnet restore
  dotnet run
  Frontend
  cd frontend
  npm install
  npm run dev
  Docker
  docker build -t myflix-api .
  docker run -d -p 8080:8080 --name myflix-container myflix-api
  
📌 Melhorias Futuras
  Autenticação com JWT
  Filtros por gênero
  Busca por nome
  Upload de capa dos filmes
  Dashboard com estatísticas
  Deploy em nuvem (AWS/Azure)
  
👨‍💻 Autor

Pedro Henrique

Analista de TI | Desenvolvedor .NET

Projeto desenvolvido para fins de estudo, prática de arquitetura em camadas e avaliação técnica.

# 🏥 Gestão de Pacientes

API REST desenvolvida em **.NET 8** para cadastro e gerenciamento de pacientes, com persistência em **PostgreSQL** e integração com a API pública do **ViaCEP** para preenchimento automático de endereço a partir do CEP.

Este projeto foi desenvolvido como parte do meu processo seletivo para atuar como desenvolvedor backend, aplicando arquitetura em camadas e boas práticas de organização de código.

## ✨ Funcionalidades

- Cadastro de pacientes (nome, data de nascimento, sexo, telefone e e-mail)
- Consulta de paciente por ID
- Atualização de dados cadastrais
- Remoção de paciente
- Preenchimento automático de endereço via integração com a **API ViaCEP**, a partir do CEP informado

## 🛠️ Tecnologias utilizadas

- **C# / .NET 8**
- **Entity Framework Core 8** (ORM e Migrations)
- **PostgreSQL** (via `Npgsql.EntityFrameworkCore.PostgreSQL`)
- **Swagger / Swashbuckle** (documentação interativa da API)
- **ViaCEP API** (integração externa para consulta de endereços)

## 🏗️ Arquitetura

O projeto é organizado em camadas, separando responsabilidades:

```
GestaoDePaciente/
├── Controllers/     → Endpoints da API (PacientesController)
├── Domain/           
│   ├── Entities/     → Entidades de domínio (Paciente, Endereco)
│   └── Enums/        → Enumeradores (ESexo)
├── DTOs/             → Objetos de transferência de dados (Create, Update, Response)
├── Repository/        → Camada de acesso a dados
├── Services/           → Regras de negócio e integração com ViaCEP
├── Infrastructure/    → Configuração de injeção de dependência
├── Data/               → DbContext e configurações do EF Core
└── Migrations/         → Migrations do banco de dados
```

## 📌 Endpoints principais

| Método | Rota                    | Descrição                     |
|--------|-------------------------|--------------------------------|
| POST   | `/api/pacientes`        | Cria um novo paciente          |
| GET    | `/api/pacientes/{id}`   | Busca um paciente pelo ID      |
| PUT    | `/api/pacientes/{id}`   | Atualiza os dados de um paciente |
| DELETE | `/api/pacientes/{id}`   | Remove um paciente             |

## ▶️ Como executar o projeto

**Pré-requisitos:** .NET 8 SDK e PostgreSQL instalados.

```bash
# Clone o repositório
git clone https://github.com/CVieiraSantos/GestaoDePaciente.git
cd GestaoDePaciente/GestaoDePaciente

# Ajuste a connection string do PostgreSQL em appsettings.json

# Aplique as migrations
dotnet ef database update

# Execute o projeto
dotnet run
```

Após rodar, a documentação interativa da API estará disponível via **Swagger** em `https://localhost:{porta}/swagger`.

## 📄 Licença

Projeto de estudo/portfólio, livre para consulta e aprendizado.

---

<p align="left">
  <a href="https://www.linkedin.com/in/carlos-vieirasantos/" target="_blank">LinkedIn</a> ·
  <a href="https://github.com/CVieiraSantos" target="_blank">GitHub</a>
</p>

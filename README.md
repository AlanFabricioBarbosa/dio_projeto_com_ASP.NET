# CarStore API

Este é um projeto de exemplo de uma API RESTful para gerenciar o inventário de uma pequena loja de carros. A API permite realizar operações de CRUD (Criar, Ler, Atualizar e Deletar) para os veículos.

O projeto foi desenvolvido com ASP.NET 8 Minimal APIs, utilizando as práticas mais recentes da plataforma .NET para a criação de APIs leves e performáticas.

## Funcionalidades

- ✅ **Listar** todos os carros do inventário.
- ✅ **Obter** detalhes de um carro específico por seu ID.
- ✅ **Adicionar** um novo carro ao inventário.
- ✅ **Atualizar** as informações de um carro existente.
- ✅ **Remover** um carro do inventário (por exemplo, após uma venda).

## Tecnologias Utilizadas

- **.NET 8**: A mais recente versão Long-Term Support (LTS) do framework .NET.
- **ASP.NET Core Minimal APIs**: Para a criação de endpoints HTTP com o mínimo de código e complexidade.
- **Entity Framework Core (In-Memory Provider)**: Para o acesso a dados de forma simples, sem a necessidade de um banco de dados externo.
- **Swagger / OpenAPI**: Para documentação interativa e testes da API, integrado através do pacote `Swashbuckle.AspNetCore`.

## Pré-requisitos

Para executar este projeto, você precisará ter o seguinte software instalado:

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) ou superior.

## Como Executar o Projeto

Siga os passos abaixo para executar a aplicação localmente:

1.  **Clone o repositório ou baixe os arquivos** para a sua máquina.

2.  **Navegue até o diretório raiz do projeto** através do seu terminal:
    ```bash
    cd caminho/para/aprendendoaspnet
    ```

3.  **Restaure os pacotes NuGet** necessários para o projeto (isso baixa as dependências como Entity Framework e Swashbuckle):
    ```bash
    dotnet restore
    ```

4.  **Execute a aplicação**:
    ```bash
    dotnet run
    ```

5.  A API estará em execução e ouvindo em um endereço local, como `http://localhost:5147` (a porta pode variar).

6.  Para acessar a **documentação interativa do Swagger**, abra seu navegador e vá para:
    ```
    http://localhost:XXXX/swagger
    ```
    (substitua `XXXX` pela porta que aparece no seu terminal).

## Endpoints da API

A API expõe os seguintes endpoints:

---

#### `GET /cars`
- **Descrição:** Retorna uma lista com todos os carros no inventário.
- **Resposta de Sucesso:** `200 OK` com a lista de carros.

---

#### `GET /cars/{id}`
- **Descrição:** Busca um carro específico pelo seu ID.
- **Parâmetros:** `id` (inteiro) - O ID do carro a ser buscado.
- **Resposta de Sucesso:** `200 OK` com os dados do carro.
- **Resposta de Erro:** `404 Not Found` se o carro não for encontrado.

---

#### `POST /cars`
- **Descrição:** Adiciona um novo carro ao inventário.
- **Body da Requisição (JSON):**
    ```json
    {
      "make": "Volkswagen",
      "model": "Nivus",
      "year": 2024,
      "price": 130000.00,
      "color": "Cinza",
      "isAvailable": true
    }
    ```
- **Resposta de Sucesso:** `201 Created` com os dados do carro recém-criado.

---

#### `PUT /cars/{id}`
- **Descrição:** Atualiza todas as informações de um carro existente.
- **Parâmetros:** `id` (inteiro) - O ID do carro a ser atualizado.
- **Body da Requisição (JSON):** A estrutura completa do carro com os dados atualizados.
- **Resposta de Sucesso:** `204 No Content`.
- **Resposta de Erro:** `404 Not Found` se o carro não for encontrado.

---

#### `DELETE /cars/{id}`
- **Descrição:** Remove um carro do inventário.
- **Parâmetros:** `id` (inteiro) - O ID do carro a ser removido.
- **Resposta de Sucesso:** `200 OK` com os dados do carro que foi removido.
- **Resposta de Erro:** `404 Not Found` se o carro não for encontrado.

## Estrutura do Projeto

```
/
|-- Data/
|   `-- CarStoreDbContext.cs  # Configuração do DbContext do EF Core
|-- Models/
|   `-- Car.cs                # Modelo de dados da entidade Carro
|-- Properties/
|   `-- launchSettings.json   # Configurações de inicialização
|-- appsettings.json
|-- aprendendoaspnet.csproj   # Arquivo de projeto .NET
|-- Program.cs              # Ponto de entrada da API, configuração e endpoints
`-- README.md               # Este arquivo
```

## Próximos Passos e Melhorias

Este é um projeto base. Algumas melhorias possíveis incluem:
- **Mudar para um Banco de Dados Persistente**: Substituir o `UseInMemoryDatabase` por `UseSqlServer` ou `UseNpgsql` para usar um banco de dados real.
- **Implementar Validação de Dados**: Adicionar validações nos modelos para garantir que dados como `ano` e `preço` sejam sempre válidos.
- **Adicionar DTOs (Data Transfer Objects)**: Separar os modelos da API dos modelos do banco de dados para maior controle e segurança.
- **Implementar Autenticação e Autorização**: Proteger os endpoints que modificam dados (POST, PUT, DELETE) para que apenas usuários autorizados possam acessá-los.
# GeekShopping

E-commerce em arquitetura de microsserviços com ASP.NET Core.

## Estrutura

Cada projeto é um repositório próprio, incluído aqui como [git submodule](https://git-scm.com/book/en/v2/Git-Tools-Submodules).

```
GeekShopping.sln
├── FrontEnd/
│   └── GeekShopping.Web               # ASP.NET Core MVC (.NET 9)          → https://localhost:4430
└── Services/
    ├── GeekShopping.IdentityServer    # Duende IdentityServer (.NET 10)   → https://localhost:4435
    └── GeekShopping.ProductAPI        # Web API de produtos (.NET 8)      → https://localhost:4440
```

## Clonando

```powershell
git clone --recurse-submodules https://github.com/YuriLopess/GeekShopping.git
```

Se o repositório já foi clonado sem os submodules, as pastas dos projetos ficam vazias. Para baixá-las:

```powershell
git submodule update --init --recursive
```

## Pré-requisitos

- [.NET SDK 8, 9 e 10](https://dotnet.microsoft.com/download)
- PostgreSQL
- Ferramenta do Entity Framework: `dotnet tool install --global dotnet-ef`

## Configuração

A connection string não fica no repositório. Em desenvolvimento ela é lida do [User Secrets](https://learn.microsoft.com/aspnet/core/security/app-secrets):

```powershell
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Host=localhost;Port=5432;Database=geek_shooping_product_api;Username=postgres;Password=SUA_SENHA" --project Services/GeekShopping.ProductAPI
```

Fora de desenvolvimento, use a variável de ambiente `ConnectionStrings__DefaultConnection`.

## Banco de dados

Criar ou atualizar o banco com as migrations:

```powershell
$env:ASPNETCORE_ENVIRONMENT = 'Development'
dotnet ef database update --project Services/GeekShopping.ProductAPI
```

## Executando

```powershell
dotnet run --project Services/GeekShopping.ProductAPI
dotnet run --project FrontEnd/GeekShopping.Web
```

A ProductAPI expõe o Swagger em `/swagger` quando roda em Development.

## Afazeres

- [ ] Avaliar o uso de um secret manager
- [ ] Melhorar a arquitetura das APIs
- [ ] Organizar estrutura dos microsserviços
- [ ] Adicionar Entidade encapusladora
- [ ] Middleware de exceptions
- [ ] Logs nas classes
- [ ] Melhoria no Swagger
- [ ] Mudar de id de long para GUID
- [ ] Validar o HTTPS
- [ ] Validar parametrização dos headers nos controllers
- [ ] Fazer containerização
- [ ] Adicionar Testes unitários
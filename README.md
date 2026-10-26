# GeekShopping

E-commerce em arquitetura de microsserviços com ASP.NET Core.

## Estrutura

```
GeekShopping.sln
├── FrontEnd/
│   └── GeekShopping.Web          # ASP.NET Core MVC (.NET 9)
└── Services/
    └── GeekShopping.ProductAPI   # Web API de produtos (.NET 8) + PostgreSQL
```

## Pré-requisitos

- [.NET SDK 8 e 9](https://dotnet.microsoft.com/download)
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
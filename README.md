# AspNetCore.WebApi
Projeto ASP.NET Core Web API, demonstrando um CRUD básico utilizando [Entity Framework](https://entityframeworkcore.com/) e [Dapper](https://dapper-tutorial.net/).
O objetivo do projeto é apresentar como é feito a implementação de funcionalidades como: Insert, Update, Delete, GetById, Select simples e Select com INNER JOIN utilizando abos os frameworks.
Também foi criado um método para medição de performance para cada cenário.

## Estrutura
### AspnetCore.DapperVsEFCore.Domain

* Entidades de domínio e interfaces.

### AspnetCore.DapperVsEFCore.DapperAdapter

#### Padrões e Tecnologias
* Dapper 2.0
* Dapper FluentMap 2.0
* Dapper FluentMap Dommel 2.0
* Repository Pattern

O projeto DapperAdapter tem a função de configurar, mapear e consumir o SGBD SQLLocalDB utilizando o Micro ORM Dapper.

### AspnetCore.DapperVsEFCore.EFCoreAdapter

#### Padrões e Tecnologias
* EFCore 5.0
* Repository Pattern

O projeto EFCoreAdapter tem a função de configurar, mapear e consumir o SGBD SQLLocalDB utilizando o ORM Entity Framework.

**Para facilitar a criação do schema de dados, o EFCore está configurado para criar o banco de dados caso não exista.**

### AspnetCore.DapperVsEFCore.WebApi

#### Padrões e Tecnologias
* Faker 2.0
* OpenAPI
* MVC

O projeto WebApi é a camada de apresentação que irá consumir os adapter já configurados. 
Nesse projeto foi adicionado um Helper para medição de tempo que pode ser utilizado para análise de performance(WatchTime).

O Swagger foi configurado para duas versões:
* V1 consome o DapperAdapter;
* V2 consome o EFCoreAdapter.
**Sugestão, utilizar o V2 EFCoreAdapter primeiro para criar o schema de dados.**


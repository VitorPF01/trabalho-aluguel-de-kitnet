# SRS – Especificação de Requisitos de Software

## Escopo

API backend para um sistema de aluguel de kitnets, consumida por front end futuro.

## Requisitos Funcionais (resumo)

* RF01 – Cadastro e autenticação de usuário administrador.
* RF02 – CRUD de kitnets.
* RF03 – CRUD de locatários.
* RF04 – CRUD de contratos de locação.
* RF05 – CRUD de pagamentos.
* RF06 – Endpoint de consulta de inadimplência por mês/ano.

## Requisitos Não Funcionais

* RNF01 – Backend em C# .NET 8.
* RNF02 – Banco de dados SQL Server via Docker.
* RNF03 – ORM Entity Framework Core.
* RNF04 – Swagger sempre habilitado.
* RNF05 – Código organizado em camadas (Data, Models, DTOs, Services, Controllers).
* RNF06 – Senhas com hash (sem texto puro no banco).

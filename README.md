# Sistema de Aluguel de Kitnets

Backend de exemplo acadêmico para gestão de aluguel de kitnets, com:

* API REST em .NET 8
* Banco de dados SQL Server via Docker + Entity Framework Core
* Swagger sempre habilitado em `/swagger`
* Testes automatizados com xUnit
* Documentação: BRD, SRS, Planejamento, Diagramas e Evidências

## Como executar

1. Suba o banco de dados com Docker (na pasta raiz do projeto):

   ```bash
   docker compose up -d
   ```

2. Rode a API (em outro terminal):

   ```bash
   cd src/KitnetAluguel.Api
   dotnet restore
   dotnet run
   ```

3. Acesse no navegador:

   * Swagger: `http://localhost:5000/swagger`
   * Exemplo de endpoint: `http://localhost:5000/api/Kitnets`

4. Rodar testes:

   ```bash
   cd tests/KitnetAluguel.Tests
   dotnet test
   ```

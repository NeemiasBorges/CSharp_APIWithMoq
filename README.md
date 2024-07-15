# API de Feriados Nacionais

## Descrição
Esta API permite o gerenciamento de feriados nacionais do Brasil. Os usuários podem realizar operações CRUD (Criar, Ler, Atualizar, Deletar) sobre feriados, além de consultar a documentação via Swagger.

## Funcionalidades
- **Obter todos os feriados**: Retorna uma lista de todos os feriados cadastrados.
- **Obter feriado por ID**: Permite buscar um feriado específico utilizando seu ID.
- **Adicionar novo feriado**: Permite o cadastro de novos feriados.
- **Atualizar feriado existente**: Atualiza as informações de um feriado já cadastrado.
- **Deletar feriado**: Remove um feriado da base de dados.

## Estrutura de Pastas
- **Models**: Contém a definição do modelo `Feriados`.
- **Services**: Implementação da lógica de negócios em `FeriadosService`.
- **Data**: Implementação do repositório em `FeriadosRepository`.
- **Controllers**: Contém a API em `FeriadoController`.
- **Tests**: Contém testes unitários para garantir a qualidade do código.

## Tecnologias Utilizadas
- .NET 7
- ASP.NET Core
- Swagger para documentação da API
- Serilog para logging
- Moq para testes

## Como Executar
1. Clone este repositório.
2. Abra o projeto no Visual Studio ou outro IDE de sua preferência.
3. Execute a aplicação e acesse `http://localhost:5259/swagger` para visualizar a documentação da API.

## Exemplos de Uso
### Obter todos os feriados
```http
GET /api/v1/Feriado
```

### Adicionar um novo feriado
```http
POST /api/v1/Feriado
Content-Type: application/json

{
  "Name": "Ano Novo",
  "Date": "2024-01-01",
  "IsNational": true
}
```

## Contribuição
Contribuições são bem-vindas! Sinta-se à vontade para abrir issues ou pull requests.

## Licença
Este projeto é licenciado sob a MIT License.
```

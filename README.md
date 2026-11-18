# LH-Pets

Web API em ASP.NET Core (.NET 8) para cadastro de clientes e pets da LH-Pets. Os dados ficam em memória (`List<T>`).

## Como executar

```bash
dotnet run --project LHPets
```

Swagger: `http://localhost:5008/swagger`

## Endpoints

| Método | Rota | Descrição |
|--------|------|-----------|
| GET | `/api/clientes` | Lista todos os clientes |
| POST | `/api/clientes` | Cadastra um cliente |
| GET | `/api/pets` | Lista todos os pets |
| POST | `/api/pets` | Cadastra um pet vinculado a um cliente (`ClienteId`) |
| GET | `/api/pets/cliente/{clienteId}` | Lista os pets de um cliente |

## Regras

- Nome, CPF (11 dígitos) e e-mail válidos são obrigatórios para o cliente.
- O pet só é cadastrado se o `ClienteId` existir (404 caso contrário).
- Os dados são perdidos ao reiniciar a aplicação.

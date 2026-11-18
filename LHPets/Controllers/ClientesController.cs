using LHPets.Data;
using LHPets.Models;
using Microsoft.AspNetCore.Mvc;

namespace LHPets.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientesController(BancoEmMemoria banco) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(List<Cliente>), StatusCodes.Status200OK)]
    public ActionResult<List<Cliente>> Listar() => banco.ListarClientes();

    [HttpPost]
    [ProducesResponseType(typeof(Cliente), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<Cliente> Adicionar(Cliente cliente)
    {
        var criado = banco.AdicionarCliente(cliente);
        return CreatedAtAction(nameof(Listar), criado);
    }
}

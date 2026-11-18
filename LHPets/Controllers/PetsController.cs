using LHPets.Data;
using LHPets.Models;
using Microsoft.AspNetCore.Mvc;

namespace LHPets.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PetsController(BancoEmMemoria banco) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(List<Pet>), StatusCodes.Status200OK)]
    public ActionResult<List<Pet>> Listar() => banco.ListarPets();

    [HttpPost]
    [ProducesResponseType(typeof(Pet), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Pet> Adicionar(Pet pet)
    {
        var criado = banco.AdicionarPet(pet);
        if (criado is null) return NotFound($"Cliente {pet.ClienteId} não encontrado.");

        return CreatedAtAction(nameof(Listar), criado);
    }

    [HttpGet("cliente/{clienteId:int}")]
    [ProducesResponseType(typeof(List<Pet>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<List<Pet>> ListarPorCliente(int clienteId)
    {
        if (!banco.ClienteExiste(clienteId)) return NotFound($"Cliente {clienteId} não encontrado.");

        return banco.ListarPetsPorCliente(clienteId);
    }
}

using LHPets.Models;

namespace LHPets.Data;

public class BancoEmMemoria
{
    private readonly object _trava = new();
    private readonly List<Cliente> _clientes = [];
    private readonly List<Pet> _pets = [];
    private int _ultimoClienteId;
    private int _ultimoPetId;

    public List<Cliente> ListarClientes()
    {
        lock (_trava) return [.. _clientes];
    }

    public Cliente AdicionarCliente(Cliente cliente)
    {
        lock (_trava)
        {
            cliente.Id = ++_ultimoClienteId;
            _clientes.Add(cliente);
            return cliente;
        }
    }

    public bool ClienteExiste(int clienteId)
    {
        lock (_trava) return _clientes.Exists(c => c.Id == clienteId);
    }

    public List<Pet> ListarPets()
    {
        lock (_trava) return [.. _pets];
    }

    public List<Pet> ListarPetsPorCliente(int clienteId)
    {
        lock (_trava) return _pets.FindAll(p => p.ClienteId == clienteId);
    }

    public Pet? AdicionarPet(Pet pet)
    {
        lock (_trava)
        {
            if (!_clientes.Exists(c => c.Id == pet.ClienteId)) return null;

            pet.Id = ++_ultimoPetId;
            _pets.Add(pet);
            return pet;
        }
    }
}

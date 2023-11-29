﻿using LibraryShared.Models;

namespace WebApi.Repository
{
    public interface IClienteRepository
    {
        Task<List<Cliente>?> GetClientes();

        Task<Cliente?> GetCliente(int id);

        Task<Cliente?> AddCliente(Cliente cliente);

        Task<List<Cliente>?> GetClientesNome(string nome);
    }
}

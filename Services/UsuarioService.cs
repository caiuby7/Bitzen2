using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bitzen.Interface.Repositories;
using Bitzen.Interface.Services;
using Bitzen.Models;

namespace Bitzen.Services
{
  public class UsuarioService : IUsuarioService
  {
    private readonly IUsuarioRepository _repository;
    public UsuarioService(IUsuarioRepository repository)
    {
      _repository = repository;
    }

    public async Task<Usuario> Atualizar(int id, Usuario row)
    {
      return await _repository.Atualizar(id, row);
    }

    public async Task<Usuario> BuscarPorId(int id)
    {
      return await _repository.BuscarPorId(id);
    }

    public async Task<IEnumerable<Usuario>> BuscarTodos()
    {
      return await _repository.BuscarTodos();
    }

    public async Task<Usuario> Criar(Usuario row)
    {
      return await _repository.Criar(row);
    }

    public Task<Usuario> Excluir(int id)
    {
      return _repository.Excluir(id);
    }
  }
}
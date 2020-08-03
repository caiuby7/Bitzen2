using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bitzen.Interface.Repositories;
using Bitzen.Interface.Services;
using Bitzen.Models;

namespace Bitzen.Services
{
  public class PermissaoService : IPermissaoService
  {
    private readonly IPermissaoRepository _repository;
    public PermissaoService(IPermissaoRepository repository)
    {
      _repository = repository;
    }

    public async Task<Permissao> Atualizar(int id, Permissao row)
    {
      return await _repository.Atualizar(id, row);
    }

    public async Task<Permissao> BuscarPorId(int id)
    {
      return await _repository.BuscarPorId(id);
    }

    public async Task<IEnumerable<Permissao>> BuscarTodos()
    {
      return await _repository.BuscarTodos();
    }

    public async Task<Permissao> Criar(Permissao row)
    {
      return await _repository.Criar(row);
    }

    public Task<Permissao> Excluir(int id)
    {
      return _repository.Excluir(id);
    }
  }
}
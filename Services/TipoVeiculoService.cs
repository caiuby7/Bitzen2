using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bitzen.Interface.Repositories;
using Bitzen.Interface.Services;
using Bitzen.Models;

namespace Bitzen.Services
{
  public class TipoVeiculoService : ITipoVeiculoService
    {
    private readonly ITipoVeiculoRepository _repository;
    public TipoVeiculoService(ITipoVeiculoRepository repository)
    {
      _repository = repository;
    }

    public async Task<TipoVeiculo> Atualizar(int id, TipoVeiculo row)
    {
      return await _repository.Atualizar(id, row);
    }

    public async Task<TipoVeiculo> BuscarPorId(int id)
    {
      return await _repository.BuscarPorId(id);
    }

    public async Task<IEnumerable<TipoVeiculo>> BuscarTodos()
    {
      return await _repository.BuscarTodos();
    }

    public async Task<TipoVeiculo> Criar(TipoVeiculo row)
    {
      return await _repository.Criar(row);
    }

    public Task<TipoVeiculo> Excluir(int id)
    {
      return _repository.Excluir(id);
    }
  }
}
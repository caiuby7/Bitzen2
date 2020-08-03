using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bitzen.Interface.Repositories;
using Bitzen.Interface.Services;
using Bitzen.Models;

namespace Bitzen.Services
{
  public class TipoCombustivelService : ITipoCombustivelService
    {
    private readonly ITipoCombustivelRepository _repository;
    public TipoCombustivelService(ITipoCombustivelRepository repository)
    {
      _repository = repository;
    }

    public async Task<TipoCombustivel> Atualizar(int id, TipoCombustivel row)
    {
      return await _repository.Atualizar(id, row);
    }

    public async Task<TipoCombustivel> BuscarPorId(int id)
    {
      return await _repository.BuscarPorId(id);
    }

    public async Task<IEnumerable<TipoCombustivel>> BuscarTodos()
    {
      return await _repository.BuscarTodos();
    }

    public async Task<TipoCombustivel> Criar(TipoCombustivel row)
    {
      return await _repository.Criar(row);
    }

    public Task<TipoCombustivel> Excluir(int id)
    {
      return _repository.Excluir(id);
    }
  }
}
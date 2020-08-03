using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bitzen.Interface.Repositories;
using Bitzen.Interface.Services;
using Bitzen.Models;

namespace Bitzen.Services
{
  public class AbastecimentoService : IAbastecimentoService
    {
    private readonly IAbastecimentoRepository _repository;
    public AbastecimentoService(IAbastecimentoRepository repository)
    {
      _repository = repository;
    }

    public async Task<Abastecimento> Atualizar(int id, Abastecimento row)
    {
      return await _repository.Atualizar(id, row);
    }

    public async Task<Abastecimento> BuscarPorId(int id)
    {
      return await _repository.BuscarPorId(id);
    }

    public async Task<IEnumerable<Abastecimento>> BuscarTodos()
    {
      return await _repository.BuscarTodos();
    }

    public async Task<Abastecimento> Criar(Abastecimento row)
    {
      return await _repository.Criar(row);
    }

    public Task<Abastecimento> Excluir(int id)
    {
      return _repository.Excluir(id);
    }
  }
}
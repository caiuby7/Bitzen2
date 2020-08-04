using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bitzen.Interface.Repositories;
using Bitzen.Interface.Services;
using Bitzen.Models;

namespace Bitzen.Services
{
  public class VeiculoService : IVeiculoService
    {
    private readonly IVeiculoRepository _repository;
    public VeiculoService(IVeiculoRepository repository)
    {
      _repository = repository;
    }

    public async Task<Veiculo> Atualizar(int id, Veiculo row)
    {
      return await _repository.Atualizar(id, row);
    }

    public async Task<Veiculo> BuscarPorId(int id)
    {
      return await _repository.BuscarPorId(id);
    }

        public async Task<IEnumerable<Veiculo>> BuscarPorUsuario(int idUser)
        {
            return await _repository.BuscarPorUsuario(idUser);
        }
        public async Task<IEnumerable<Veiculo>> BuscarTodos()
    {
      return await _repository.BuscarTodos();
    }

    public async Task<Veiculo> Criar(Veiculo row)
    {
      return await _repository.Criar(row);
    }

    public Task<Veiculo> Excluir(int id)
    {
      return _repository.Excluir(id);
    }
  }
}
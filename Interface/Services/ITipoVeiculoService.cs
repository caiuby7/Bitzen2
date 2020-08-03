using System.Collections.Generic;
using System.Threading.Tasks;
using Bitzen.Models;

namespace Bitzen.Interface.Services
{
  public interface ITipoVeiculoService
    {
    Task<IEnumerable<TipoVeiculo>> BuscarTodos();
    Task<TipoVeiculo> BuscarPorId(int id);
    Task<TipoVeiculo> Criar(TipoVeiculo row);
    Task<TipoVeiculo> Atualizar(int id, TipoVeiculo row);
    Task<TipoVeiculo> Excluir(int id);
  }
}
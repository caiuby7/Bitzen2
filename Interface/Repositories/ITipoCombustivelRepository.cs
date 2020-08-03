using System.Collections.Generic;
using System.Threading.Tasks;
using Bitzen.Models;

namespace Bitzen.Interface.Repositories
{
  public interface ITipoCombustivelRepository
    {
    Task<IList<TipoCombustivel>> BuscarTodos();
    Task<TipoCombustivel> BuscarPorId(int id);
    Task<TipoCombustivel> Criar(TipoCombustivel row);
    Task<TipoCombustivel> Atualizar(int id, TipoCombustivel row);
    Task<TipoCombustivel> Excluir(int id);
  }
}
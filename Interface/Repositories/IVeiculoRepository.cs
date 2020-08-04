using System.Collections.Generic;
using System.Threading.Tasks;
using Bitzen.Models;

namespace Bitzen.Interface.Repositories
{
  public interface IVeiculoRepository
    {
    Task<IList<Veiculo>> BuscarTodos();
    Task<Veiculo> BuscarPorId(int id);
    Task<Veiculo> Criar(Veiculo row);
    Task<Veiculo> Atualizar(int id, Veiculo row);
    Task<Veiculo> Excluir(int id);
  }
}
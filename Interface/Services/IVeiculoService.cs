using System.Collections.Generic;
using System.Threading.Tasks;
using Bitzen.Models;

namespace Bitzen.Interface.Services
{
  public interface IVeiculoService
    {
    Task<IEnumerable<Veiculo>> BuscarTodos();
    Task<Veiculo> BuscarPorId(int id);

        Task<IEnumerable<Veiculo>> BuscarPorUsuario(int idUser);
        Task<Veiculo> Criar(Veiculo row);
    Task<Veiculo> Atualizar(int id, Veiculo row);
    Task<Veiculo> Excluir(int id);
  }
}
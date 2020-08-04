using System.Collections.Generic;
using System.Threading.Tasks;
using Bitzen.Models;

namespace Bitzen.Interface.Repositories
{
  public interface IAbastecimentoRepository
    {
    Task<IList<Abastecimento>> BuscarTodos();

        Task<IList<Abastecimento>> BuscarporUsuario(int id);
        Task<Abastecimento> BuscarPorId(int id);
    Task<Abastecimento> Criar(Abastecimento row);
    Task<Abastecimento> Atualizar(int id, Abastecimento row);
    Task<Abastecimento> Excluir(int id);
  }
}
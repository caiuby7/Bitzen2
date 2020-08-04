using System.Collections.Generic;
using System.Threading.Tasks;
using Bitzen.Models;

namespace Bitzen.Interface.Services
{
  public interface IAbastecimentoService
    {
    Task<IEnumerable<Abastecimento>> BuscarTodos();
    Task<Abastecimento> BuscarPorId(int id);

        Task<IEnumerable<Abastecimento>> BuscarPorUsuario(int id);

        Task<IEnumerable<Abastecimento>> BuscarPorPeriodo(int ano);
        Task<Abastecimento> Criar(Abastecimento row);
    Task<Abastecimento> Atualizar(int id, Abastecimento row);
    Task<Abastecimento> Excluir(int id);
  }
}
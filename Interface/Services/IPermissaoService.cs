using System.Collections.Generic;
using System.Threading.Tasks;
using Bitzen.Models;

namespace Bitzen.Interface.Services
{
  public interface IPermissaoService
  {
    Task<IEnumerable<Permissao>> BuscarTodos();
    Task<Permissao> BuscarPorId(int id);
    Task<Permissao> Criar(Permissao row);
    Task<Permissao> Atualizar(int id, Permissao row);
    Task<Permissao> Excluir(int id);
  }
}
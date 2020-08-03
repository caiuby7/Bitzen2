using System.Collections.Generic;
using System.Threading.Tasks;
using Bitzen.Models;

namespace Bitzen.Interface.Repositories
{
  public interface IUsuarioRepository
  {
    Task<IList<Usuario>> BuscarTodos();
    Task<Usuario> BuscarPorId(int id);
    Task<Usuario> Criar(Usuario row);
    Task<Usuario> Atualizar(int id, Usuario row);
    Task<Usuario> Excluir(int id);
  }
}
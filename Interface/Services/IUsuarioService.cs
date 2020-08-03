using System.Collections.Generic;
using System.Threading.Tasks;
using Bitzen.Models;

namespace Bitzen.Interface.Services
{
  public interface IUsuarioService
  {
    Task<IEnumerable<Usuario>> BuscarTodos();
    Task<Usuario> BuscarPorId(int id);
    Task<Usuario> Criar(Usuario row);
    Task<Usuario> Atualizar(int id, Usuario row);
    Task<Usuario> Excluir(int id);
  }
}
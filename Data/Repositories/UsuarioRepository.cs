
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Bitzen.Interface.Repositories;
using Bitzen.Models;

namespace Bitzen.Data.Repositories
{
  public class UsuarioRepository : IUsuarioRepository
  {
    private readonly DataContext _context;

    public UsuarioRepository(DataContext context)
    {
      _context = context;
    }

    public async Task<Usuario> Atualizar(int id, Usuario row)
    {
      _context.Entry<Usuario>(row).State = EntityState.Modified;
      await _context.SaveChangesAsync();
      return row;
    }

    public async Task<Usuario> BuscarPorId(int id)
    {
      return await _context.Usuarios
                          .AsNoTracking()
                          .Where(x => x.Id == id)
                          .FirstOrDefaultAsync();
    }

    public async Task<IList<Usuario>> BuscarTodos()
    {
      return await _context.Usuarios
                         .AsNoTracking()
                         .ToListAsync();
    }

    public async Task<Usuario> Criar(Usuario row)
    {
      _context.Usuarios.Add(row);
      await _context.SaveChangesAsync();
      return row;
    }

    public Task<Usuario> Excluir(int id)
    {
      var row = BuscarPorId(id).Result;
      row.Ativo = false;

      return Atualizar(row.Id, row);
    }
  }
}
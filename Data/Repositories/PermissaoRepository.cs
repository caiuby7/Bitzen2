
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Bitzen.Interface.Repositories;
using Bitzen.Models;

namespace Bitzen.Data.Repositories
{
  public class PermissaoRepository : IPermissaoRepository
  {
    private readonly DataContext _context;

    public PermissaoRepository(DataContext context)
    {
      _context = context;
    }

    public async Task<Permissao> Atualizar(int id, Permissao row)
    {
      _context.Entry<Permissao>(row).State = EntityState.Modified;
      await _context.SaveChangesAsync();
      return row;
    }

    public async Task<Permissao> BuscarPorId(int id)
    {
      return await _context.Permissoes
                         .AsNoTracking()
                         .Where(x => x.Id == id)
                         .FirstOrDefaultAsync();
    }

    public async Task<IList<Permissao>> BuscarTodos()
    {
      return await _context.Permissoes
                         .AsNoTracking()
                         .ToListAsync();
    }

    public async Task<Permissao> Criar(Permissao row)
    {
      _context.Permissoes.Add(row);
      await _context.SaveChangesAsync();
      return row;
    }

    public Task<Permissao> Excluir(int id)
    {
      var row = BuscarPorId(id).Result;
      row.Ativo = false;

      return Atualizar(row.Id, row);
    }
  }
}
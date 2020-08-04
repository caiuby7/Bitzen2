
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Bitzen.Interface.Repositories;
using Bitzen.Models;

namespace Bitzen.Data.Repositories
{
    public class AbastecimentoRepository : IAbastecimentoRepository
    {
        private readonly DataContext _context;

        public AbastecimentoRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Abastecimento> Atualizar(int id, Abastecimento row)
        {
            _context.Entry<Abastecimento>(row).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return row;
        }

        public async Task<Abastecimento> BuscarPorId(int id)
        {
            return await _context.Abastecimento
                                .AsNoTracking()
                                .Where(x => x.Id == id)
                                .FirstOrDefaultAsync();
        }

        public async Task<IList<Abastecimento>> BuscarporUsuario(int IdUsuario)
        {
            return await _context.Abastecimento
                               .AsNoTracking()
                                .Where(x => x.IdUsuario == IdUsuario)
                               .ToListAsync();
        }
        public async Task<IList<Abastecimento>> BuscarporPeriodo(int ano)
        {
            
            return await _context.Abastecimento
                               .AsNoTracking()
                               .Where(x => x.Data.Year == ano)
                               .ToListAsync();
        }
        public async Task<IList<Abastecimento>> BuscarTodos()
        {
            return await _context.Abastecimento
                               .AsNoTracking()
                               .ToListAsync();
        }
        public async Task<IList<Abastecimento>> BuscarTodosporAno()
        {
            return await _context.Abastecimento
                               .AsNoTracking()
                               .OrderBy(o => new
                               {
                                   Month = o.Data.Month,
                                   Year = o.Data.Year
                               })
                               .ToListAsync();
        }

        public async Task<Abastecimento> Criar(Abastecimento row)
        {
            _context.Abastecimento.Add(row);
            await _context.SaveChangesAsync();
            return row;
        }

        public Task<Abastecimento> Excluir(int id)
        {
            var row = BuscarPorId(id).Result;
           

            return Atualizar(row.Id, row);
        }
    }
}
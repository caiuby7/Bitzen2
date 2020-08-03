
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Bitzen.Interface.Repositories;
using Bitzen.Models;

namespace Bitzen.Data.Repositories
{
    public class TipoCombustivelRepository : ITipoCombustivelRepository
    {
        private readonly DataContext _context;

        public TipoCombustivelRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<TipoCombustivel> Atualizar(int id, TipoCombustivel row)
        {
            _context.Entry<TipoCombustivel>(row).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return row;
        }

        public async Task<TipoCombustivel> BuscarPorId(int id)
        {
            return await _context.TipoCombustivel
                                .AsNoTracking()
                                .Where(x => x.Id == id)
                                .FirstOrDefaultAsync();
        }

        public async Task<IList<TipoCombustivel>> BuscarTodos()
        {
            return await _context.TipoCombustivel
                               .AsNoTracking()
                               .ToListAsync();
        }

        public async Task<TipoCombustivel> Criar(TipoCombustivel row)
        {
            _context.TipoCombustivel.Add(row);
            await _context.SaveChangesAsync();
            return row;
        }

        public Task<TipoCombustivel> Excluir(int id)
        {
            var row = BuscarPorId(id).Result;
           

            return Atualizar(row.Id, row);
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Bitzen.Interface.Repositories;
using Bitzen.Models;

namespace Bitzen.Data.Repositories
{
    public class TipoVeiculoRepository : ITipoVeiculoRepository
    {
        private readonly DataContext _context;

        public TipoVeiculoRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<TipoVeiculo> Atualizar(int id, TipoVeiculo row)
        {
            _context.Entry<TipoVeiculo>(row).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return row;
        }

        public async Task<TipoVeiculo> BuscarPorId(int id)
        {
            return await _context.TipoVeiculo
                                .AsNoTracking()
                                .Where(x => x.Id == id)
                                .FirstOrDefaultAsync();
        }

        public async Task<IList<TipoVeiculo>> BuscarTodos()
        {
            return await _context.TipoVeiculo
                               .AsNoTracking()
                               .ToListAsync();
        }

        public async Task<TipoVeiculo> Criar(TipoVeiculo row)
        {
            _context.TipoVeiculo.Add(row);
            await _context.SaveChangesAsync();
            return row;
        }

        public Task<TipoVeiculo> Excluir(int id)
        {
            var row = BuscarPorId(id).Result;
            

            return Atualizar(row.Id, row);
        }
    }
}
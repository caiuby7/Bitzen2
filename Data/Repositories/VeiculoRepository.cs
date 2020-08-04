
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Bitzen.Interface.Repositories;
using Bitzen.Models;
using Microsoft.EntityFrameworkCore.Internal;

namespace Bitzen.Data.Repositories
{
    public class VeiculoRepository : IVeiculoRepository
    {
        private readonly DataContext _context;

        public VeiculoRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Veiculo> Atualizar(int id, Veiculo row)
        {
            _context.Entry<Veiculo>(row).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return row;
        }

        public async Task<Veiculo> BuscarPorId(int id)
        {
            return await _context.Veiculo
                                .AsNoTracking()
                                .Where(x => x.Id == id)
                                .FirstOrDefaultAsync();
        }

        public async Task<IList<Veiculo>> BuscarPorUsuario(int idUser)
        {
            return await _context.Veiculo
                                .AsNoTracking()
                                .Where(x => x.IdUsuario == idUser)
                                 .ToListAsync();
        }


        public async Task<IList<Veiculo>> BuscarTodos()
        {
            return await _context.Veiculo
                               .AsNoTracking()
                               .ToListAsync();
        }
        public async Task<IList<Veiculo>> BuscarTodosPorAno()
        {
            return await _context.Veiculo
                               .AsNoTracking()
                               .ToListAsync();
        }

        public async Task<Veiculo> Criar(Veiculo row)
        {
            _context.Veiculo.Add(row);
            await _context.SaveChangesAsync();
            return row;
        }

        public Task<Veiculo> Excluir(int id)
        {
            var row = BuscarPorId(id).Result;
          

            return Atualizar(row.Id, row);
        }
    }
}
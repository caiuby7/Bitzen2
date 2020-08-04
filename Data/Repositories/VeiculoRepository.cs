
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Bitzen.Interface.Repositories;
using Bitzen.Models;
using Microsoft.EntityFrameworkCore.Internal;
using System.Security.Cryptography.X509Certificates;

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

        public async Task<IList<Mes_Relatorio_Veiculo>> BuscarPorperiodo(int ano)
        {

            List<Mes_Relatorio_Veiculo> m = new List<Mes_Relatorio_Veiculo>();
            for (int i = 0; i < 12; i++)
            {
                Mes_Relatorio_Veiculo mes = new Mes_Relatorio_Veiculo();
                string mesExtenso = System.Globalization.DateTimeFormatInfo.CurrentInfo.GetMonthName(i + 1).ToLower();
                mes.mes = char.ToUpper(mesExtenso[0]) + mesExtenso.Substring(1);
                

                var resultv = from veiculo in _context.Veiculo
                                join Abastecimento in _context.Abastecimento
                                on veiculo.Id equals Abastecimento.IdVeiculo
                                where Abastecimento.Data.Month == i + 1
                                select veiculo;
                mes.veiculo = resultv.ToList();
                for (int p = 0; p < mes.veiculo.Count; p++)
                {

                    mes.veiculo[p].relatorio_abastecimento = new Relatorio_Abastecimento();
                    mes.veiculo[p].relatorio_abastecimento.kmrodados = _context.Abastecimento.Where(t => t.IdVeiculo == mes.veiculo[p].Id && t.Data.Month == i + 1).Sum(i => long.Parse(i.Km.ToString() ));
                    mes.veiculo[p].relatorio_abastecimento.totallitros = _context.Abastecimento.Where(t => t.IdVeiculo == mes.veiculo[p].Id && t.Data.Month == i + 1).Sum(i => long.Parse(i.Litros.ToString()));
                    mes.veiculo[p].relatorio_abastecimento.totalpago = _context.Abastecimento.Where(t => t.IdVeiculo == mes.veiculo[p].Id && t.Data.Month == i + 1).Sum(i => long.Parse(i.ValorPago.ToString()));
                    mes.veiculo[p].relatorio_abastecimento.mediaporkm = mes.veiculo[p].relatorio_abastecimento.kmrodados / mes.veiculo[p].relatorio_abastecimento.totallitros;
                }
                

            }
            return m;
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
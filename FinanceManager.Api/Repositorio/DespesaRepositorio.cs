using System.Collections.Generic;
using System.Threading.Tasks;
using FinanceManager.Api.Repositorio.Interface;
using FinanceManager.Api.Model;
using Microsoft.EntityFrameworkCore;

namespace FinanceManager.Api.Repositorio
{
    public class DespesaRepositorio : IDespesaRepositorio
    {
        private readonly DbContext _context;

        public DespesaRepositorio(DbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Despesa>> ObterTodasAsync()
        {
            return await _context.Set<Despesa>().ToListAsync();
        }

        public async Task<Despesa> ObterPorIdAsync(int id)
        {
            return await _context.Set<Despesa>().FindAsync(id);
        }

        public async Task AdicionarAsync(Despesa despesa)
        {
            await _context.Set<Despesa>().AddAsync(despesa);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Despesa despesa)
        {
            _context.Set<Despesa>().Update(despesa);
            await _context.SaveChangesAsync();
        }

        public async Task DeletarAsync(int id)
        {
            var despesa = await _context.Set<Despesa>().FindAsync(id);
            if (despesa != null)
            {
                _context.Set<Despesa>().Remove(despesa);
                await _context.SaveChangesAsync();
            }
        }
    }
}

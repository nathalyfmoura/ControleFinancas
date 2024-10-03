using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FinanceManager.Api.Repositorio.Interface;
using FinanceManager.Api.Model;

namespace FinanceManager.Api.Repositorio
{
    public class ReceitaRepositorio : IReceitaRepositorio
    {
        private readonly DbContext _context;

        public ReceitaRepositorio(DbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Receita>> ObterTodas()
        {
            return await _context.Set<Receita>().ToListAsync(); 
        }

        public async Task<Receita> ObterPorId(int id)
        {
            return await _context.Set<Receita>().FindAsync(id);
        }

        public async Task Adicionar(Receita receita)
        {
            await _context.Set<Receita>().AddAsync(receita);
            await _context.SaveChangesAsync();
        }

        public async Task Atualizar(Receita receita)
        {
            _context.Set<Receita>().Update(receita);
            await _context.SaveChangesAsync();
        }

        public async Task Deletar(int id)
        {
            var receita = await _context.Set<Receita>().FindAsync(id);
            if (receita != null)
            {
                _context.Set<Receita>().Remove(receita);
                await _context.SaveChangesAsync();
            }
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanceManager.Api.Model;
using FinanceManager.Api.Repositorio.Interface;
using FinanceManager.Api.Servico.Interfaces;

namespace FinanceManager.Api.Servico
{
    public class DespesaServico : IDespesaServico
    {
        private readonly IDespesaRepositorio _despesaRepositorio;

        public DespesaServico(IDespesaRepositorio despesaRepositorio)
        {
            _despesaRepositorio = despesaRepositorio;
        }

        public async Task<IEnumerable<Despesa>> ObterTodasAsync()
        {
            return await _despesaRepositorio.ObterTodasAsync();
        }

        public async Task<Despesa> ObterPorIdAsync(int id)
        {
            return await _despesaRepositorio.ObterPorIdAsync(id);
        }

        public async Task<Despesa> Criar(Despesa despesa)
        {
            await _despesaRepositorio.AdicionarAsync(despesa);
            return despesa;
        }

        public async Task AtualizarAsync(Despesa despesa)
        {
            await _despesaRepositorio.AtualizarAsync(despesa);
        }

        public async Task DeletarAsync(int id)
        {
            await _despesaRepositorio.DeletarAsync(id);
        }

        public async Task<bool> Existe(int id)
        {
            var despesa = await _despesaRepositorio.ObterPorIdAsync(id);
            return despesa != null;
        }
    }
}

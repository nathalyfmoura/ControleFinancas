using System.Collections.Generic;
using System.Threading.Tasks;
using FinanceManager.Api.Model;

namespace FinanceManager.Api.Servico.Interfaces
{
    public interface IDespesaServico
    {
        Task<IEnumerable<Despesa>> ObterTodasAsync();
        Task<Despesa> ObterPorIdAsync(int id);
        Task<Despesa> Criar(Despesa despesa);
        Task AtualizarAsync(Despesa despesa);
        Task DeletarAsync(int id);
        Task<bool> Existe(int id);
    }
}

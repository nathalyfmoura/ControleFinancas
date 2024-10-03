using System.Collections.Generic;
using System.Threading.Tasks;
using FinanceManager.Api.Model;

namespace FinanceManager.Api.Repositorio.Interface
{
    public interface IDespesaRepositorio
    {
        Task<IEnumerable<Despesa>> ObterTodasAsync();
        Task<Despesa> ObterPorIdAsync(int id);
        Task AdicionarAsync(Despesa despesa);
        Task AtualizarAsync(Despesa despesa);
        Task DeletarAsync(int id);
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using FinanceManager.Api.Model;

namespace FinanceManager.Api.Repositorio.Interface
{
    public interface IReceitaRepositorio
    {
        Task<IEnumerable<Receita>> ObterTodas();
        Task<Receita> ObterPorId(int id);
        Task Adicionar(Receita receita);
        Task Atualizar(Receita receita);
        Task Deletar(int id);
    }
}

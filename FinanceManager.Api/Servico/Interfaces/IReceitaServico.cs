using System.Collections.Generic;
using System.Threading.Tasks;
using FinanceManager.Api.Model;

namespace FinanceManager.Api.Servico.Interfaces
{
    public interface IReceitaServico
    {
        Task<IEnumerable<Receita>> ObterTodas();
        Task<Receita> ObterPorId(int id);
        Task<Receita> Criar(Receita receita);
        Task Atualizar(Receita receita);
        Task<bool> Existe(int id);
        Task Deletar(int id);
    }
}


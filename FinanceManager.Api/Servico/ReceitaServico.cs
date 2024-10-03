using System.Collections.Generic;
using System.Threading.Tasks;
using FinanceManager.Api.Repositorio.Interface;
using FinanceManager.Api.Model;
using FinanceManager.Api.Servico.Interfaces;

namespace FinanceManager.Api.Servico
{
    public class ReceitaServico : IReceitaServico
    {
        private readonly IReceitaRepositorio _receitaRepositorio;

        public ReceitaServico(IReceitaRepositorio receitaRepositorio)
        {
            _receitaRepositorio = receitaRepositorio;
        }

        public async Task<IEnumerable<Receita>> ObterTodas()
        {
            return await _receitaRepositorio.ObterTodas();
        }

        public async Task<Receita> ObterPorId(int id)
        {
            return await _receitaRepositorio.ObterPorId(id);
        }

        public async Task<Receita> Criar(Receita receita)
        {
            await _receitaRepositorio.Adicionar(receita);
            return receita; // Retorna a receita criada
        }

        public async Task Atualizar(Receita receita)
        {
            await _receitaRepositorio.Atualizar(receita);
        }

        public async Task<bool> Existe(int id)
        {
            var receita = await _receitaRepositorio.ObterPorId(id);
            return receita != null;
        }

        public async Task Deletar(int id)
        {
            await _receitaRepositorio.Deletar(id);
        }
    }
}

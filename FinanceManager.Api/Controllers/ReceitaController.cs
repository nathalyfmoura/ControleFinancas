using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using FinanceManager.Api.Servico.Interfaces;
using FinanceManager.Api.Model;

namespace FinanceManager.Api.Controladores
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceitaController : ControllerBase
    {
        private readonly IReceitaServico _servicoReceita;

        public ReceitaController(IReceitaServico servicoReceita)
        {
            _servicoReceita = servicoReceita;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Receita>>> ObterTodas()
        {
            var receitas = await _servicoReceita.ObterTodas();
            return Ok(receitas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Receita>> ObterPorId(int id)
        {
            var receita = await _servicoReceita.ObterPorId(id);
            if (receita == null)
            {
                return NotFound();
            }
            return Ok(receita);
        }

        [HttpPost]
        public async Task<ActionResult<Receita>> Criar([FromBody] Receita receitaDto)
        {
            var receitaCriada = await _servicoReceita.Criar(receitaDto);
            return CreatedAtAction(nameof(ObterPorId), new { id = receitaCriada.Id }, receitaCriada);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Atualizar(int id, [FromBody] Receita receita)
        {
            if (id != receita.Id)
            {
                return BadRequest();
            }

            await _servicoReceita.Atualizar(receita);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Deletar(int id)
        {
            var existe = await _servicoReceita.Existe(id);
            if (!existe)
            {
                return NotFound();
            }

            await _servicoReceita.Deletar(id);
            return NoContent();
        }
    }
}

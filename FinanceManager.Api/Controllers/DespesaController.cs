using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using FinanceManager.Api.Servico.Interfaces;
using FinanceManager.Api.Model;

namespace FinanceManager.Api.Controladores
{
    [Route("api/[controller]")]
    [ApiController]
    public class DespesaController : ControllerBase
    {
        private readonly IDespesaServico _servicoDespesa;

        public DespesaController(IDespesaServico servicoDespesa)
        {
            _servicoDespesa = servicoDespesa;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Despesa>>> ObterTodas()
        {
            var despesas = await _servicoDespesa.ObterTodasAsync();
            return Ok(despesas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Despesa>> ObterPorId(int id)
        {
            var despesa = await _servicoDespesa.ObterPorIdAsync(id);
            if (despesa == null)
            {
                return NotFound();
            }
            return Ok(despesa);
        }

        [HttpPost]
        public async Task<ActionResult<Despesa>> Criar([FromBody] Despesa despesaDto)
        {
            var despesaCriada = await _servicoDespesa.Criar(despesaDto);
            return CreatedAtAction(nameof(ObterPorId), new { id = despesaCriada.Id }, despesaCriada);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Atualizar(int id, [FromBody] 
        
        Despesa despesaDto)
        {
            if (id != despesaDto.Id)
            {
                return BadRequest();
            }

            await _servicoDespesa.AtualizarAsync(despesaDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Deletar(int id)
        {
            var existe = await _servicoDespesa.Existe(id);
            if (!existe)
            {
                return NotFound();
            }

            await _servicoDespesa.DeletarAsync(id);
            return NoContent();
        }
    }
}

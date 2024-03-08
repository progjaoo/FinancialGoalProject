using FinancialGoal.Application.Abstracao;
using FinancialGoal.Application.Commands.ObjetivosFinanceiros.AtualizarObjetivo;
using FinancialGoal.Application.Commands.ObjetivosFinanceiros.CriarObjetivo;
using FinancialGoal.Application.Commands.ObjetivosFinanceiros.DeletarObjetivo;
using FinancialGoal.Application.Commands.ObjetivosFinanceiros.SimularObjetivoFinanceiro;
using FinancialGoal.Application.Queries.ObjetivoFinanceiro.BuscarPorId;
using FinancialGoal.Application.Queries.ObjetivoFinanceiro.BuscarTodos;
using FinancialGoal.Core.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinancialGoal.Controllers
{
    [Route("api/ObjetivoFinanceiro")]
    [ApiController]
    public class ObjetivoFinanceiroController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IObjetivoFinanceiroRepository _objetivoFinanceiroRepository;
        public ObjetivoFinanceiroController(IMediator mediator, IObjetivoFinanceiroRepository objetivoFinanceiroRepository)
        {
            _mediator = mediator;
            _objetivoFinanceiroRepository = objetivoFinanceiroRepository;
        }
        [HttpGet]
        public async Task<IActionResult> BuscarTodos()
        {
            var buscarTodos = new BuscarTodosQuery();

            var result = await _mediator.Send(buscarTodos);

            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarPorId(int id)
        {
            var queryId = new BuscarPorIdQuery(id);

            var buscarPorId = await _mediator.Send(queryId);

            if (buscarPorId == null)
                return NotFound();

            return Ok(buscarPorId);
        }
        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] AddObjetivoCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(BuscarPorId), new { id = id }, command);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar([FromBody] AtualizarObjetivoCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(int id)
        {
            var command = new DeleteObjetivoCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }
        [HttpPut("cancelarObjetivo")]
        public async Task<IActionResult> Cancelar(int id)
        {
            var cancelar = await _objetivoFinanceiroRepository.BuscarPorId(id);

            cancelar.Cancelar();

            await _objetivoFinanceiroRepository.SaveChangesAsync();

            return NoContent();
        }
        [HttpPut("completarObjetivo")]
        public async Task<IActionResult> Finalizar(int id)
        {
            var completar = await _objetivoFinanceiroRepository.BuscarPorId(id);

            completar.Finalizar();

            await _objetivoFinanceiroRepository.SaveChangesAsync();

            return NoContent();
        }
        [HttpPost("SimularEvolucao")]
        public async Task<IActionResult> SimularObjetivoFinanceiro(SimularObjetivoCommand command)
        {
            var resultado = await _mediator.Send(command);

            return Ok(Result<string>.Success(resultado));
        }
    }
}

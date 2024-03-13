using FinancialGoal.Application.Abstracao;
using FinancialGoal.Application.Commands.Transacao.EnviarTransacao;
using FinancialGoal.Application.Commands.Transacao.RemoverTransacao;
using FinancialGoal.Application.Queries.Transacao.BuscarPorId;
using FinancialGoal.Application.Queries.Transacao.BuscarTodos;
using FinancialGoal.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinancialGoal.API.Controllers
{
    [Route("api/transacoes")]
    [ApiController]
    public class TransacaoController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TransacaoController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> BuscarTodos()
        {
            var transacao = new BuscarTodasTransacoesQuery();

            var resultado = await _mediator.Send(transacao);

            return Ok(resultado);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarPorId(int id)
        {
            var transacaoId = new BuscarTransacaoPorIdQuery(id);

            var resultado = await _mediator.Send(transacaoId);

            return Ok(resultado);
        }
        [HttpPost]
        public async Task<IActionResult> EnviarTransacao([FromBody] EnviarTransacaoCommand command)
        {
            var transacao = await _mediator.Send(command);

            if (!transacao)
                return NotFound(Result<EnviarTransacaoCommand>.NotFound());

            return Created(string.Empty, "Transação realizada com sucesso");
        }
        [HttpDelete("ExcluirTransacao")]
        public async Task<IActionResult> Deletar(int id)
        {
            var query = new RemoverTransacaoCommand(id);

            var result = await _mediator.Send(query);

            if (!result)
                return BadRequest(Result<RemoverTransacaoCommand>.Failure());

            return NoContent();
        }
    }
}

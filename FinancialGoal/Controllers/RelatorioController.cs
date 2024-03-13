using FinancialGoal.Application.Abstracao;
using FinancialGoal.Application.Queries.Relatorio;
using FinancialGoal.Core.DTO_s;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinancialGoal.API.Controllers
{
    [Route("api/Relatorios")]
    [ApiController]
    public class RelatorioController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RelatorioController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("Relatórios")]
        public async Task<IActionResult> BuscarReports()
        {
            var query = new BuscarRelatorioQuery();

            var relatorios = await _mediator.Send(query);

            return Ok(Result<List<RelatorioDto>>.Success(relatorios)); ;
        }
    }
}

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
        public async Task <IActionResult> BuscarTodos()
        {
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarPorId(int id )
        {
            return Ok();
        }
    }
}

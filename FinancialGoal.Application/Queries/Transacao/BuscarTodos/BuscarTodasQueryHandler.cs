using FinancialGoal.Application.ViewModels;
using FinancialGoal.Core.Repositories;
using MediatR;

namespace FinancialGoal.Application.Queries.Transacao.BuscarTodos
{
    public class BuscarTodasQueryHandler : IRequestHandler<BuscarTodosQuery, List<TransacaoViewModel>>
    {
        private readonly ITransacaoRepository _transacaoRepository;
        public BuscarTodasQueryHandler(ITransacaoRepository transacaoRepository)
        {
            _transacaoRepository = transacaoRepository;
        }
        public async Task<List<TransacaoViewModel>> Handle(BuscarTodosQuery request, CancellationToken cancellationToken)
        {
            var transacao = await _transacaoRepository.BuscarTodos();

            var transacaoViewModel = transacao.Select(t => new TransacaoViewModel(
                t.Quantidade,
                t.Tipo,
                t.DataTransacao)).ToList();

            return transacaoViewModel;
        }
    }
}

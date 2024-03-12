using FinancialGoal.Application.ViewModels;
using FinancialGoal.Core.Repositories;
using MediatR;

namespace FinancialGoal.Application.Queries.Transacao.BuscarTodos
{
    public class BuscarTodasTransacoesQueryHandler : IRequestHandler<BuscarTodasTransacoesQuery, List<TransacaoViewModel>>
    {
        private readonly ITransacaoRepository _transacaoRepository;
        public BuscarTodasTransacoesQueryHandler(ITransacaoRepository transacaoRepository)
        {
            _transacaoRepository = transacaoRepository;
        }
        public async Task<List<TransacaoViewModel>> Handle(BuscarTodasTransacoesQuery request, CancellationToken cancellationToken)
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

using FinancialGoal.Application.ViewModels;
using FinancialGoal.Core.Repositories;
using MediatR;

namespace FinancialGoal.Application.Queries.ObjetivoFinanceiro.BuscarTodos
{
    public class BuscarTodosQueryHandler : IRequestHandler<BuscarTodosQuery, List<ObjetivoFinanceiroViewModel>>
    {
        private readonly IObjetivoFinanceiroRepository _objetivoFinanceiroRepository;

        public BuscarTodosQueryHandler(IObjetivoFinanceiroRepository objetivoFinanceiroRepository)
        {
            _objetivoFinanceiroRepository = objetivoFinanceiroRepository;
        }

        public async Task<List<ObjetivoFinanceiroViewModel>> Handle(BuscarTodosQuery request, CancellationToken cancellationToken)
        {
            var objetivo = await _objetivoFinanceiroRepository.BuscarTodos();

            var objetivoViewModel = objetivo
                .Select(o =>
                new ObjetivoFinanceiroViewModel(o.Titulo, o.QuantidadeAlvo, o.Prazo, o.StatusObj, o.CriadoEm)).ToList();

            return objetivoViewModel;

        }
    }
}

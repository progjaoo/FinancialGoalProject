using FinancialGoal.Application.ViewModels;
using FinancialGoal.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoal.Application.Queries.ObjetivoFinanceiro.BuscarPorId
{
    public class BuscarPorIdQueryHandler : IRequestHandler<BuscarPorIdQuery, ObjetivoFinanceiroDetalheViewModel>
    {
        private readonly IObjetivoFinanceiroRepository _objetivoFinanceiroRepository;
        public BuscarPorIdQueryHandler(IObjetivoFinanceiroRepository objetivoFinanceiroRepository)
        {
            _objetivoFinanceiroRepository = objetivoFinanceiroRepository;
        }
        public async Task<ObjetivoFinanceiroDetalheViewModel> Handle(BuscarPorIdQuery request, CancellationToken cancellationToken)
        {
            var objetivo = await _objetivoFinanceiroRepository.BuscarPorId(request.Id);

            if (objetivo == null) return null;

            var objetivoViewModel = new ObjetivoFinanceiroDetalheViewModel(
                objetivo.Id,
                objetivo.Titulo,
                objetivo.QuantidadeAlvo,
                objetivo.Prazo,
                objetivo.StatusObj,
                objetivo.CriadoEm);

            return objetivoViewModel;
        }
    }
}

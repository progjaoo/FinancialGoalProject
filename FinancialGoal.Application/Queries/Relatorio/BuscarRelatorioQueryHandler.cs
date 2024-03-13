using FinancialGoal.Core.DTO_s;
using FinancialGoal.Core.Repositories;
using MediatR;

namespace FinancialGoal.Application.Queries.Relatorio
{
    public class BuscarRelatorioQueryHandler : IRequestHandler<BuscarRelatorioQuery, List<RelatorioDto>>
    {
        private readonly IRelatorioRepository _relatorioRepository;
        public BuscarRelatorioQueryHandler(IRelatorioRepository relatorioRepository)
        {
            _relatorioRepository = relatorioRepository;
        }
        public async Task<List<RelatorioDto>> Handle(BuscarRelatorioQuery request, CancellationToken cancellationToken)
        {
            var relatorios = _relatorioRepository.BuscarRelatorio();

            return await relatorios;
        }
    }
}

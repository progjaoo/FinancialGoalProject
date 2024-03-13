using FinancialGoal.Core.DTO_s;
using MediatR;

namespace FinancialGoal.Application.Queries.Relatorio
{
    public class BuscarRelatorioQuery : IRequest<List<RelatorioDto>>
    {
    }
}

using FinancialGoal.Application.ViewModels;
using MediatR;

namespace FinancialGoal.Application.Queries.Transacao.BuscarTodos
{
    public class BuscarTodasTransacoesQuery : IRequest<List<TransacaoViewModel>> { }
}

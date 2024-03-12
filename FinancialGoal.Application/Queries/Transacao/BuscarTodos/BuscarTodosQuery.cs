using FinancialGoal.Application.ViewModels;
using MediatR;

namespace FinancialGoal.Application.Queries.Transacao.BuscarTodos
{
    public class BuscarTodosQuery : IRequest<List<TransacaoViewModel>> { }
}

using FinancialGoal.Application.ViewModels;
using MediatR;

namespace FinancialGoal.Application.Queries.ObjetivoFinanceiro.BuscarPorId
{
    public class BuscarPorIdQuery : IRequest<ObjetivoFinanceiroDetalheViewModel>
    {
        public BuscarPorIdQuery(int id) 
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}

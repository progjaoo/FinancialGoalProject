using FinancialGoal.Application.ViewModels;
using FinancialGoal.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoal.Application.Queries.Transacao.BuscarPorId
{
    public class BuscarTransacaoPorIdQuery : IRequest<TransacaoDetalheViewModel>
    {
        public BuscarTransacaoPorIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}

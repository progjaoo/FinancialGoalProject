using FinancialGoal.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoal.Application.Queries.ObjetivoFinanceiro.BuscarTodos
{
    public class BuscarTodosQuery :IRequest<List<ObjetivoFinanceiroViewModel>> { }
}

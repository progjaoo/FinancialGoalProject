using FinancialGoal.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoal.Core.Repositories
{
    public interface IObjetivoFinanceiroRepository
    {
        Task<List<ObjetivoFinanceiro>> BuscarTodos();
        Task<ObjetivoFinanceiro> BuscarPorId(int id);
        Task AddAsync(ObjetivoFinanceiro objetivoFinanceiro);
        Task Delete(int id);
        Task SaveChangesAsync();
    }
}

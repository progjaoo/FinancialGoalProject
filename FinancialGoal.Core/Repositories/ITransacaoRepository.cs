using FinancialGoal.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoal.Core.Repositories
{
    public interface ITransacaoRepository
    {
        Task<List<Transacao>> BuscarTodos();
        Task<Transacao> BuscarPorId(int id);
        Task AddAsync(Transacao transacao, ObjetivoFinanceiro objetivoFinanceiro);
        Task Delete(int id);
        Task SaveChangesAsync();
    }
}

using FinancialGoal.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoal.Infrastructure.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IObjetivoFinanceiroRepository ObjetivoFinanceiroRepository { get; }
        IRelatorioRepository RelatorioRepository { get; }
        ITransacaoRepository TransacaoRepository { get; }
        Task BeginTransactionAsync();
        Task CommitAsync();
        Task<int> CompleteAsync();
    }
}

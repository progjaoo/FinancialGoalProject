using FinancialGoal.Core.Repositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace FinancialGoal.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbContextTransaction _transaction;
        private readonly ObjetivoFinanceiroDbContext _dbcontext;
        public IObjetivoFinanceiroRepository ObjetivoFinanceiroRepository { get; }
        public IRelatorioRepository RelatorioRepository { get; }
        public ITransacaoRepository TransacaoRepository { get; }

        public UnitOfWork(ObjetivoFinanceiroDbContext dbcontext,
            IObjetivoFinanceiroRepository objetivoFinanceiroRepository,
            IRelatorioRepository relatorioRepository,
            ITransacaoRepository transacaoRepository)
        {
            _dbcontext = dbcontext;
            ObjetivoFinanceiroRepository = objetivoFinanceiroRepository;
            RelatorioRepository = relatorioRepository;
            TransacaoRepository = transacaoRepository;
        }

        public async Task BeginTransactionAsync()
            => _transaction = await _dbcontext.Database.BeginTransactionAsync();

        public async Task CommitAsync()
        {
            try
            {
                await _transaction.CommitAsync();
            }
            catch (Exception)
            {
                await _transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<int> CompleteAsync()
        {
            return await _dbcontext.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                _dbcontext.Dispose();
        }
    }
}

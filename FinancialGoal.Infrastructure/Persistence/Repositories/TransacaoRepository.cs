using FinancialGoal.Core.Entities;
using FinancialGoal.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FinancialGoal.Infrastructure.Persistence.Repositories
{
    public class TransacaoRepository : ITransacaoRepository
    {
        private readonly ObjetivoFinanceiroDbContext _dbcontext;
        public TransacaoRepository(ObjetivoFinanceiroDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<Transacao> BuscarPorId(int id) 
            =>await _dbcontext.Transacoes.SingleOrDefaultAsync(t => t.Id == id);            

        public async Task<List<Transacao>> BuscarTodos()
            => await _dbcontext.Transacoes.ToListAsync();
        public async Task AddAsync(Transacao transacao, ObjetivoFinanceiro objetivoFinanceiro)
        {
            if(objetivoFinanceiro != null)
            {
                transacao.ObjetivoFinanceiro = objetivoFinanceiro;

                objetivoFinanceiro.Transacoes = objetivoFinanceiro.Transacoes ?? new List<Transacao>();
                objetivoFinanceiro.Transacoes.Add(transacao);

                _dbcontext.Update(objetivoFinanceiro);
            }
            await _dbcontext.Transacoes.AddAsync(transacao);
        }
        public async Task Delete(int id)
        {
            var transacoes = await _dbcontext.Transacoes.SingleOrDefaultAsync(o => o.Id == id);

            if (transacoes == null)
                throw new Exception("Transição inexistente!");

            await RemoverAsync(transacoes);
        }
        public async Task RemoverAsync(Transacao transacao)
        {
            _dbcontext.Remove(transacao);
        }
        public async Task SaveChangesAsync()
            => await _dbcontext.SaveChangesAsync();
    }
}

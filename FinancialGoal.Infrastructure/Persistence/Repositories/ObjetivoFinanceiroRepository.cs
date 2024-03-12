using FinancialGoal.Core;
using FinancialGoal.Core.Entities;
using FinancialGoal.Core.Repositories;
using FinancialGoal.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoal.Infrastructure.Persistence.Repositories
{
    public class ObjetivoFinanceiroRepository : IObjetivoFinanceiroRepository
    {
        private readonly ObjetivoFinanceiroDbContext _dbcontext;

        public ObjetivoFinanceiroRepository(ObjetivoFinanceiroDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<ObjetivoFinanceiro> BuscarPorId(int id)
            => await _dbcontext.ObjetivoFinanceiro.SingleOrDefaultAsync(o => o.Id == id);

        public async Task<List<ObjetivoFinanceiro>> BuscarTodos()
            => await _dbcontext.ObjetivoFinanceiro.ToListAsync();

        public async Task AddAsync(ObjetivoFinanceiro objetivoFinanceiro)
        {
            await _dbcontext.ObjetivoFinanceiro.AddAsync(objetivoFinanceiro);
            await _dbcontext.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var objetivo = await _dbcontext.ObjetivoFinanceiro.SingleOrDefaultAsync(o => o.Id == id);

            if (objetivo == null)
                throw new Exception("O Objetivo não existe");

            await RemoverAsync(objetivo);
        }
        public async Task RemoverAsync(ObjetivoFinanceiro objetivoFinanceiro)
        {
            _dbcontext.Remove(objetivoFinanceiro);
        }
        public async Task SaveChangesAsync() 
            =>await _dbcontext.SaveChangesAsync();
    }
}

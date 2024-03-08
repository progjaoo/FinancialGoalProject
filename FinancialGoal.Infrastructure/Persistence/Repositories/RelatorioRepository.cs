using FinancialGoal.Core.DTO_s;
using FinancialGoal.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FinancialGoal.Infrastructure.Persistence.Repositories
{
    public class RelatorioRepository : IRelatorioRepository
    {
        private readonly ObjetivoFinanceiroDbContext _dbcontext;

        public RelatorioRepository(ObjetivoFinanceiroDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<List<RelatorioDto>> BuscarRelatorio()
        {
            var consulta = await _dbcontext.ObjetivoFinanceiro
                .Include(i => i.Transacoes)
                .Select(relatorios => new RelatorioDto
                {
                    Titulo = relatorios.Titulo,
                    Transacoes = relatorios.Transacoes,
                    CriadoEm = relatorios.CriadoEm,
                    QuantidadeAlvo = relatorios.QuantidadeAlvo
                }).ToListAsync();

            return consulta;
        }
    }
}

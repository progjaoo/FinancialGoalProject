using FinancialGoal.Core.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoal.Core.Repositories
{
    public interface IRelatorioRepository
    {
        Task<List<RelatorioDto>> BuscarRelatorio();
    }
}

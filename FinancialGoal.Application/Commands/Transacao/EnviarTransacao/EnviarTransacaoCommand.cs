using FinancialGoal.Core.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoal.Application.Commands.Transacao.EnviarTransacao
{
    public class EnviarTransacaoCommand : IRequest<bool>
    {
        public int IdObjetivo { get; set; }
        public decimal? Quantidade { get;  set; }
        public TipoTransacao Tipo { get; set; }
        public DateTime? DataTransacao { get; set; }
    }
}

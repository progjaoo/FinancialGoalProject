using FinancialGoal.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoal.Core.Entities
{
    public class Transacao : BaseEntity
    {
        public decimal? Quantidade { get; private set; }
        public TipoTransacao Tipo { get; private set; }
        public DateTime? DataTransacao { get; private set; }
        public DateTime? CriadoEm { get; private set; }
        public bool? EstaDeletado { get; private set; }
        public int IdObjetivo { get; set; }
        public ObjetivoFinanceiro ObjetivoFinanceiro { get; set; }
    }
}

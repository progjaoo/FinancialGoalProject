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
        public Transacao(int idObjetivo, decimal? quantidade, TipoTransacao tipo, DateTime? dataTransacao)
        {
            IdObjetivo = idObjetivo;
            Quantidade = quantidade;
            Tipo = tipo;
            DataTransacao = dataTransacao;
            CriadoEm = DateTime.UtcNow;
            EstaDeletado = false;
        }

        public ObjetivoFinanceiro ObjetivoFinanceiro { get; set; }
        public int IdObjetivo { get; set; }
        public decimal? Quantidade { get; private set; }
        public TipoTransacao Tipo { get; private set; }
        public DateTime? DataTransacao { get; private set; }
        public DateTime? CriadoEm { get; private set; }
        public bool? EstaDeletado { get; private set; }
    }
}

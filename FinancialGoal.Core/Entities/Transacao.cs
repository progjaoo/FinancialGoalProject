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
        private Transacao() { }
        public Transacao(decimal quantidade, TipoTransacao tipo, DateTime? dataTransacao, int idObjetivo)
        {
            Quantidade = Math.Round(quantidade, 2);
            Tipo = tipo;
            DataTransacao = dataTransacao;
            IdObjetivo = idObjetivo;

            CriadoEm = DateTime.UtcNow;
            EstaDeletado = false;
        }

        public ObjetivoFinanceiro ObjetivoFinanceiro { get; set; }
        public int IdObjetivo { get; set; }
        public decimal? Quantidade { get; private set; }
        public TipoTransacao Tipo { get; private set; }
        public DateTime? DataTransacao { get; private set; }
        public DateTime? CriadoEm { get; private set; }
        public bool? EstaDeletado { get;  set; }
    }
}

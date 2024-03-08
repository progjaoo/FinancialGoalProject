using FinancialGoal.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoal.Core.Entities
{
    public class ObjetivoFinanceiro : BaseEntity
    {
        public ObjetivoFinanceiro() { }
        public ObjetivoFinanceiro(string titulo, decimal? quantidadeAlvo, DateTime? prazo)
        {
            Titulo = titulo;
            QuantidadeAlvo = quantidadeAlvo;
            Prazo = prazo;

            StatusObj = StatusObjetivo.EmProgresso;
            CriadoEm = DateTime.Now;
            EstaDeletado = false;
        }

        public string Titulo { get; private set; }
        public decimal? QuantidadeAlvo { get; private set; }

        public DateTime? Prazo { get; private set; }

        public StatusObjetivo StatusObj { get; private set; }

        public DateTime? CriadoEm { get; private set; }

        public bool? EstaDeletado { get; private set; }
        public List<Transacao> Transacoes { get; private set; }

        public void UpdateObjetivo(string titulo, decimal? quantidadeAlvo, DateTime? prazo)
        {
            Titulo = titulo;
            QuantidadeAlvo = quantidadeAlvo;
            Prazo = prazo;
        }
        public void Cancelar()
        {
            if (StatusObj == StatusObjetivo.EmProgresso)
            {
                StatusObj = StatusObjetivo.Cancelado;
            }
        }
        public void Finalizar()
        {
            if (StatusObj == StatusObjetivo.EmProgresso || StatusObj == StatusObjetivo.Cancelado)
                StatusObj = StatusObjetivo.Completo;
        }
    }
}

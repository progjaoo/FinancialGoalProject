using FinancialGoal.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoal.Application.ViewModels
{
    public class ObjetivoFinanceiroViewModel
    {
        public ObjetivoFinanceiroViewModel(string titulo, decimal? quantidadeAlvo, DateTime? prazo, StatusObjetivo statusObj, DateTime? criadoEm)
        {
            Titulo = titulo;
            QuantidadeAlvo = quantidadeAlvo;
            Prazo = prazo;
            StatusObj = statusObj;
            CriadoEm = criadoEm;
        }

        public string Titulo { get;  set; }
        public decimal? QuantidadeAlvo { get;  set; }
        public DateTime? Prazo { get;  set; }
        public StatusObjetivo StatusObj { get;  set; }
        public DateTime? CriadoEm { get;  set; }
    }
}

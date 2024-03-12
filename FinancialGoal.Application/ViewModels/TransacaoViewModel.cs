using FinancialGoal.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoal.Application.ViewModels
{
    public class TransacaoViewModel
    {
        public TransacaoViewModel(decimal? quantidade, TipoTransacao tipo, DateTime? dataTransacao)
        {
            Quantidade = quantidade;
            Tipo = tipo;
            DataTransacao = dataTransacao;
        }

        public decimal? Quantidade { get;  set; }
        public TipoTransacao Tipo { get; set; }
        public DateTime? DataTransacao { get; set; }
    }
}

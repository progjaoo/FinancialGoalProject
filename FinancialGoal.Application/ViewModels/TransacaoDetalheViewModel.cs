using FinancialGoal.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoal.Application.ViewModels
{
    public class TransacaoDetalheViewModel
    {
        public TransacaoDetalheViewModel(int id, decimal? quantidade, TipoTransacao tipo, DateTime? dataTransacao, DateTime? criadoEm, int idObjetivo)
        {
            Id = id;
            Quantidade = quantidade;
            Tipo = tipo;
            DataTransacao = dataTransacao;
            CriadoEm = criadoEm;
            IdObjetivo = idObjetivo;
        }

        public int Id { get; set; }
        public decimal? Quantidade { get;  set; }
        public TipoTransacao Tipo { get;  set; }
        public DateTime? DataTransacao { get;  set; }
        public DateTime? CriadoEm { get;  set; }
        public int IdObjetivo { get; set; }
    }
}

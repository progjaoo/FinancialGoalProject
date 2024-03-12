using FinancialGoal.Core.Enums;

namespace FinancialGoal.Application.ViewModels
{
    public class ObjetivoFinanceiroDetalheViewModel
    {
        public ObjetivoFinanceiroDetalheViewModel(int id, string titulo, decimal? quantidadeAlvo, DateTime? prazo,
            StatusObjetivo statusObj, DateTime? criadoEm)
        {
            Id = id;
            Titulo = titulo;
            QuantidadeAlvo = quantidadeAlvo;
            Prazo = prazo;
            StatusObj = statusObj;
            CriadoEm = criadoEm;
        }

        public int Id { get; set; }
        public string Titulo { get; set; }
        public decimal? QuantidadeAlvo { get; set; }

        public DateTime? Prazo { get; set; }

        public StatusObjetivo StatusObj { get; set; }

        public DateTime? CriadoEm { get; set; }
    }
}

using MediatR;

namespace FinancialGoal.Application.Commands.ObjetivosFinanceiros.AtualizarObjetivo
{
    public class AtualizarObjetivoCommand : IRequest<Unit>
    {
        public int Id { get; set; } 
        public string Titulo { get; set; }
        public decimal? QuantidadeAlvo { get; set; }
        public DateTime? Prazo { get; set; }
    }
}

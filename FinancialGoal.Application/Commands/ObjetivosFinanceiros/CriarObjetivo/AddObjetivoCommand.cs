using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoal.Application.Commands.ObjetivosFinanceiros.CriarObjetivo
{
    public class AddObjetivoCommand : IRequest<int>
    {
        public string Titulo { get; set; }
        public decimal? QuantidadeAlvo { get; set; }
        public DateTime? Prazo { get; set; }
    }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoal.Application.Commands.ObjetivosFinanceiros.SimularObjetivoFinanceiro
{
    public class SimularObjetivoCommandHandler : IRequestHandler<SimularObjetivoCommand, string>
    {
        public Task<string> Handle(SimularObjetivoCommand request, CancellationToken cancellationToken)
        {
            var taxa = 1 + (request.RendaMensal / 100);

            var quantiaFinal = request.Quantia * Math.Pow(request.Meses, taxa);

            var resultado = $"A quantia final é {quantiaFinal}";

            return Task.FromResult(resultado);
        }
    }
}

using FinancialGoal.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoal.Application.Commands.ObjetivosFinanceiros.AtualizarObjetivo
{
    public class AtualizarObjetivoCommandHandler : IRequestHandler<AtualizarObjetivoCommand, Unit>
    {
        private readonly IObjetivoFinanceiroRepository _objetivoFinanceiroRepository;
        public AtualizarObjetivoCommandHandler(IObjetivoFinanceiroRepository objetivoFinanceiroRepository)
        {
            _objetivoFinanceiroRepository = objetivoFinanceiroRepository;
        }
        public async Task<Unit> Handle(AtualizarObjetivoCommand request, CancellationToken cancellationToken)
        {
            var objetivo = await _objetivoFinanceiroRepository.BuscarPorId(request.Id);

            objetivo.UpdateObjetivo(request.Titulo, request.QuantidadeAlvo, request.Prazo);
            
            await _objetivoFinanceiroRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}

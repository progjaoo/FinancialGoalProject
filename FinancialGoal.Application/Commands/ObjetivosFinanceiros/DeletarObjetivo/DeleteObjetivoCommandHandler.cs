using FinancialGoal.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoal.Application.Commands.ObjetivosFinanceiros.DeletarObjetivo
{
    public class DeleteObjetivoCommandHandler : IRequestHandler<DeleteObjetivoCommand, Unit>
    {
        private readonly IObjetivoFinanceiroRepository _objetivoFinanceiroRepository;
        public DeleteObjetivoCommandHandler(IObjetivoFinanceiroRepository objetivoFinanceiroRepository)
        {
            _objetivoFinanceiroRepository = objetivoFinanceiroRepository;
        }
        public async Task<Unit> Handle(DeleteObjetivoCommand request, CancellationToken cancellationToken)
        {
            var objetivo = await _objetivoFinanceiroRepository.BuscarPorId(request.Id);

            await _objetivoFinanceiroRepository.Delete(objetivo.Id);
            await _objetivoFinanceiroRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}

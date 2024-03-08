using FinancialGoal.Core.Entities;
using FinancialGoal.Core.Repositories;
using MediatR;

namespace FinancialGoal.Application.Commands.ObjetivosFinanceiros.CriarObjetivo
{
    public class AddObjetivoCommandHandler : IRequestHandler<AddObjetivoCommand, int>
    {
        private readonly IObjetivoFinanceiroRepository _objetivoFinanceiroRepository;
        public AddObjetivoCommandHandler(IObjetivoFinanceiroRepository objetivoFinanceiroRepository)
        {
            _objetivoFinanceiroRepository = objetivoFinanceiroRepository;
        }
        public async Task<int> Handle(AddObjetivoCommand request, CancellationToken cancellationToken)
        {
            var objetivo = new ObjetivoFinanceiro(request.Titulo, request.QuantidadeAlvo, request.Prazo);
            
            await _objetivoFinanceiroRepository.AddAsync(objetivo);
            await _objetivoFinanceiroRepository.SaveChangesAsync();

            return objetivo.Id;
        }
    }
}

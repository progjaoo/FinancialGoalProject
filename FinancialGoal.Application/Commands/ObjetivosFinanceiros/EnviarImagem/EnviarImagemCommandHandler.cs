using FinancialGoal.Core.Repositories;
using MediatR;

namespace FinancialGoal.Application.Commands.ObjetivosFinanceiros.EnviarImagem
{
    public class EnviarImagemCommandHandler : IRequestHandler<EnviarImagemCommand, bool>
    {
        private readonly IObjetivoFinanceiroRepository _objetivoFinanceiroRepository;
        public EnviarImagemCommandHandler(IObjetivoFinanceiroRepository objetivoFinanceiroRepository)
        {
            _objetivoFinanceiroRepository = objetivoFinanceiroRepository;
        }
        public async Task<bool> Handle(EnviarImagemCommand request, CancellationToken cancellationToken)
        {
            var objetivo = await _objetivoFinanceiroRepository.BuscarPorId(request.Id);

            if(objetivo == null)
                return false;

            byte[] file;

            using (var stream = new MemoryStream())
            {
                await request.Imagem.CopyToAsync(stream);
                file = stream.ToArray();

                objetivo.Imagem = file;
            }
            await _objetivoFinanceiroRepository.SaveChangesAsync();
            
            return true;
        }
    }
}

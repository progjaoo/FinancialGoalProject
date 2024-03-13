using FinancialGoal.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoal.Application.Commands.Transacao.RemoverTransacao
{
    public class RemoverTransacaoCommandHandler : IRequestHandler<RemoverTransacaoCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        public RemoverTransacaoCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(RemoverTransacaoCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.BeginTransactionAsync();
            var transacao = await _unitOfWork.TransacaoRepository.BuscarPorId(request.Id);

            if (transacao == null) return false;

            await _unitOfWork.TransacaoRepository.Delete(transacao.Id);
            await _unitOfWork.CompleteAsync();
            await _unitOfWork.CommitAsync();

            return true;
        }
    }
}

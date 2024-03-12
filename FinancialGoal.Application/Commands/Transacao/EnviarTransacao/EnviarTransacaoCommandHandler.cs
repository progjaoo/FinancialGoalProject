using FinancialGoal.Core.Entities;
using FinancialGoal.Core.Enums;
using FinancialGoal.Core.Repositories;
using FinancialGoal.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoal.Application.Commands.Transacao.EnviarTransacao
{
    public class EnviarTransacaoCommandHandler : IRequestHandler<EnviarTransacaoCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IObjetivoFinanceiroRepository _objetivoFinanceiroRepository;
        public EnviarTransacaoCommandHandler(IUnitOfWork unitOfWork, IObjetivoFinanceiroRepository objetivoFinanceiroRepository)
        {
            _unitOfWork = unitOfWork;
            _objetivoFinanceiroRepository = objetivoFinanceiroRepository;
        }
        public async Task<bool> Handle(EnviarTransacaoCommand request, CancellationToken cancellationToken)
        {
            var objetivoFinanceiro = await _unitOfWork.ObjetivoFinanceiroRepository.BuscarPorId(request.IdObjetivo);

            if (objetivoFinanceiro == null)
                return false;

            if (request.Tipo == TipoTransacao.Saque)
                request.Quantidade *= -1;

            var transacao = new Core.Entities.Transacao(request.Quantidade, 
                request.Tipo, request.DataTransacao, request.IdObjetivo);

            await _unitOfWork.BeginTransactionAsync();
            await _unitOfWork.TransacaoRepository.AddAsync(transacao, objetivoFinanceiro);
            await _unitOfWork.CompleteAsync();
            await _unitOfWork.CommitAsync();

            return true;
        }
    }
}

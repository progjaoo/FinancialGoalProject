using FinancialGoal.Application.ViewModels;
using FinancialGoal.Core.Entities;
using FinancialGoal.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoal.Application.Queries.Transacao.BuscarPorId
{
    public class BuscarTransacaoQueryHandler : IRequestHandler<BuscarTransacaoPorIdQuery, TransacaoDetalheViewModel>
    {
        private readonly ITransacaoRepository _transacaoRepository;
        public BuscarTransacaoQueryHandler(ITransacaoRepository transacaoRepository)
        {
            _transacaoRepository = transacaoRepository;
        }
        public async Task<TransacaoDetalheViewModel> Handle(BuscarTransacaoPorIdQuery request, CancellationToken cancellationToken)
        {
            var transacao = await _transacaoRepository.BuscarPorId(request.Id);

            if (transacao == null) return null;

            var transacaoDetalheViewModel = new TransacaoDetalheViewModel(
                transacao.Id,
                transacao.Quantidade,
                transacao.Tipo,
                transacao.DataTransacao,
                transacao.CriadoEm,
                transacao.IdObjetivo);

            return transacaoDetalheViewModel;
        }
    }
}

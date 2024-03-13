using MediatR;

namespace FinancialGoal.Application.Commands.Transacao.RemoverTransacao
{
    public class RemoverTransacaoCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public RemoverTransacaoCommand(int id)
        {
            Id = id;
        }
    }
}

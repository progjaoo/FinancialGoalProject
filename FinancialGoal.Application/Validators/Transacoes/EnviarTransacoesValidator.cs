using FinancialGoal.Application.Commands.Transacao.EnviarTransacao;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoal.Application.Validators.Transacoes
{
    public class EnviarTransacoesValidator : AbstractValidator<EnviarTransacaoCommand>
    {
        public EnviarTransacoesValidator()
        {
            RuleFor(t => t.IdObjetivo)
                .NotEmpty()
                .NotNull()
                .WithMessage("Id do objetivo não pode ser nulo nem vazio!");

            RuleFor(i => i.Quantidade)
                .NotNull()
                .NotEmpty()
                .GreaterThanOrEqualTo(1)
                .LessThanOrEqualTo(100000)
                .WithMessage("A quantidade alvo só pode ser no minimo 1 real e no máximo 100.000!");

            RuleFor(i => i.DataTransacao)
                .NotNull()
                .NotEmpty()
                .GreaterThanOrEqualTo(new DateTime(2024, 01, 01))
                .LessThanOrEqualTo(DateTime.Now)
                .WithMessage("A transação deve ter um intervalo entre 2024 e a data atual!");

            RuleFor(i => i.Tipo)
                .NotNull()
                .NotEmpty()
                .IsInEnum()
                .WithMessage("Certifique-se de ter passado por um enum válido!");
        }
    }
}

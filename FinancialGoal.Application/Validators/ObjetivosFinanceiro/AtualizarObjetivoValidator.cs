using FinancialGoal.Application.Commands.ObjetivosFinanceiros.AtualizarObjetivo;
using FinancialGoal.Application.Helpers;
using FluentValidation;

namespace FinancialGoal.Application.Validators.ObjetivosFinanceiro
{
    public class AtualizarObjetivoValidator : AbstractValidator<AtualizarObjetivoCommand>
    {
        public AtualizarObjetivoValidator()
        {
            RuleFor(i => i.Titulo)
                .Must(ValidationsHelper.ValidarTitulo)
                .WithMessage("titulo deve conter 3-30 caracteres!");
            RuleFor(i => i.QuantidadeAlvo)
                .Must(ValidationsHelper.ValidarQuantidadeAlvo)
                .WithMessage("Quantidade alvo deve conter entre 500 e 1.000.000!");
            RuleFor(i => i.Prazo)
                .Must(ValidationsHelper.ValidarPrazo)
                .WithMessage("O prazo deve ser de no mínimo 2 meses e no máximo 5 anos!");
        }
    }
}

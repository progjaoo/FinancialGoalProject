using FinancialGoal.Application.Commands.ObjetivosFinanceiros.CriarObjetivo;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoal.Application.Validators.ObjetivosFinanceiro
{
    public class CriarObjetivoValidator : AbstractValidator<AddObjetivoCommand>
    {
        public CriarObjetivoValidator()
        {
            RuleFor(c => c.Titulo)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
                .MaximumLength(30)
                .WithMessage("Titulo deve conter de 3 a 30 caracteres");

            RuleFor(c => c.QuantidadeAlvo)
                .NotNull()
                .NotEmpty()
                .GreaterThanOrEqualTo(500)
                .LessThanOrEqualTo(1000000)
                .WithMessage("A quantidade alvo deve ser de pelo menos 500 e 1.000.000");

            RuleFor(c => c.Prazo)
                .NotEmpty()
                .NotEmpty()
                .GreaterThanOrEqualTo(DateTime.Now.AddMonths(2))
                .LessThanOrEqualTo(DateTime.Now.AddYears(5))
                .WithMessage("O prazo deve ter no mínimo 2 meses e a data máxima 5 anos!");
        }
    }
}

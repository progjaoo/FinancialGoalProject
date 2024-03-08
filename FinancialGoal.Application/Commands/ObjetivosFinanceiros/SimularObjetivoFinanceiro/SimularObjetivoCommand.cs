using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoal.Application.Commands.ObjetivosFinanceiros.SimularObjetivoFinanceiro
{
    public class SimularObjetivoCommand : IRequest<string>
    {
        public int Meses { get; set; }
        public double RendaMensal { get; set;}
        public double Quantia { get; set;}
    }
}

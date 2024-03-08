using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoal.Application.Commands.ObjetivosFinanceiros.DeletarObjetivo
{
    public class DeleteObjetivoCommand : IRequest<Unit>
    {
        public DeleteObjetivoCommand(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}

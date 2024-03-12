using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoal.Application.Commands.ObjetivosFinanceiros.EnviarImagem
{
    public class EnviarImagemCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public required IFormFile Imagem { get; set; }
    }
}

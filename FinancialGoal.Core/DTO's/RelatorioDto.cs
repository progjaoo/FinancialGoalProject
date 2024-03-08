﻿using FinancialGoal.Core.Entities;
using FinancialGoal.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoal.Core.DTO_s
{
    public class RelatorioDto
    {
        public string Titulo { get;  set; }
        public decimal? QuantidadeAlvo { get;  set; }
        public DateTime? CriadoEm { get;  set; }
        public List<Transacao> Transacoes { get;  set; }
    }
}

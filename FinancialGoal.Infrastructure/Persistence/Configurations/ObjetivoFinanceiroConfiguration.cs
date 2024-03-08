using FinancialGoal.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoal.Infrastructure.Persistence.Configurations
{
    public class ObjetivoFinanceiroConfiguration : IEntityTypeConfiguration<ObjetivoFinanceiro>
    {
        public void Configure(EntityTypeBuilder<ObjetivoFinanceiro> builder)
        {
            builder.HasKey(o => o.Id);

            builder.HasMany(o => o.Transacoes)
                   .WithOne(o => o.ObjetivoFinanceiro)
                   .HasForeignKey(o => o.IdObjetivo)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

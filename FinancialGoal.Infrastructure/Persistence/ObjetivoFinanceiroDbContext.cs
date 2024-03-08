using FinancialGoal.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoal.Infrastructure.Persistence
{
    public class ObjetivoFinanceiroDbContext : DbContext
    {
        public ObjetivoFinanceiroDbContext(DbContextOptions<ObjetivoFinanceiroDbContext> options) : base(options) { }

        public DbSet<ObjetivoFinanceiro> ObjetivoFinanceiro {  get; set; }
        public DbSet<Transacao> Transacoes {  get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}

using FinanceManager.Api.Model;
using Microsoft.EntityFrameworkCore;

namespace FinanceManager.Api.Data
{
    public class FinanceDbContext : DbContext
    {
        public FinanceDbContext(DbContextOptions<FinanceDbContext> options) : base(options)
        {
        }

        public DbSet<Receita> Receitas { get; set; }
        public DbSet<Despesa> Despesas { get; set; }
       
    }
}

using Microsoft.EntityFrameworkCore;
using csharp_wpf_cleaningcompany_orderpanel.Models;

namespace csharp_wpf_cleaningcompany_orderpanel.ViewModels.AppContext
{
    class ClosedRequestContext : DbContext
    {
        public DbSet<ClosedRequest> ClosedRequests { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=CleaningCompanyDatabase;Trusted_Connection=True;");
        }
    }
}

using Microsoft.EntityFrameworkCore;
using csharp_wpf_cleaningcompany_orderpanel.Models;

namespace csharp_wpf_cleaningcompany_orderpanel.ViewModels
{
    class CustomerRequestContext : DbContext
    {
        public DbSet<CustomerRequest> CustomersRequests { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=CleaningCompanyDatabase;Trusted_Connection=True;");
        }
    }
}

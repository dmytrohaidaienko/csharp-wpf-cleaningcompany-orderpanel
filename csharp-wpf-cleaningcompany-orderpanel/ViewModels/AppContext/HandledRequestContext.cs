﻿using csharp_wpf_cleaningcompany_orderpanel.Models;
using Microsoft.EntityFrameworkCore;

namespace csharp_wpf_cleaningcompany_orderpanel.ViewModels
{
    class HandledRequestContext : DbContext
    {
        public DbSet<HandledRequest> HandledRequests { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=CleaningCompanyDatabase;Trusted_Connection=True;");
        }
    }
}

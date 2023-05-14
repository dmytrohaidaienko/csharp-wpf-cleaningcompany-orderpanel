using System;
using System.ComponentModel.DataAnnotations;

namespace csharp_wpf_cleaningcompany_orderpanel.Models
{
    public class CustomerRequest
    {
        [Key]
        public Guid Id { get; set; }
        public String? CustomersName { get; set; }
        public String? CustomersPhone { get; set; }
        public String? CustomersCity { get; set; }
        public String? CustomersAddress { get; set; }
        public String? CustomersPlace { get; set; }
    }
}
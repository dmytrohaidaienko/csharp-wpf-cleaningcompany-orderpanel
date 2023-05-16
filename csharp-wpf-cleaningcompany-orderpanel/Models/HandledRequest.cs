using System;
using System.ComponentModel.DataAnnotations;

namespace csharp_wpf_cleaningcompany_orderpanel.Models
{
    class HandledRequest
    {
        [Key]
        public Guid Id { get; set; }
        public String? CustomersName { get; set; }
        public String? CustomersPhone { get; set; }
        public String? CustomersCity { get; set; }
        public String? CustomersAddress { get; set; }
        public String? CustomersPlace { get; set; }
        public Int32 AppartmentSize { get; set; }
        public Int32 WorkPrice { get; set; }
        public DateTime? HandledDate { get; set; }
        public DateTime? AppointmentDate { get; set; }
    }
}

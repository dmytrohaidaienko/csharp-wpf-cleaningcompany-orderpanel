using System;
using System.ComponentModel.DataAnnotations;
using System.Windows.Media;

namespace csharp_wpf_cleaningcompany_orderpanel.Models
{
    class User
    {
        public User()
        {

        }

        [Key]
        public String? Email { get; set; }
        public String? Password { get; set; }
        public String? FullName { get; set; }
    }
}
using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLayer.Models
{
    public partial class User
    {
        public User()
        {
            Carts = new HashSet<Cart>();
        }

        public long Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public long Phone { get; set; }
        public string Email { get; set; }
        public DateTime? Birthday { get; set; }
        public string PasswordHash { get; set; }
        public DateTime? RegistredAt { get; set; }
        public DateTime? LastLogin { get; set; }

        public virtual ICollection<Cart> Carts { get; set; }
    }
}

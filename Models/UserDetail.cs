using System;
using System.Collections.Generic;

namespace BookMyShow.Models
{
    public partial class UserDetail
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? EmailAddress { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Password { get; set; }
    }
}

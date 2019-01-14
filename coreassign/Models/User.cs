using System;
using System.Collections.Generic;

namespace coreassign.Models
{
    public class User
    {
        public uint IdUser { get; set; }

        public bool IsAdmin { get; set; }

        public String Username { get; set; }

        public String Password { get; set; }

        public ICollection<Package> Sent { get; set; }

        public ICollection<Package> Received { get; set; }

        public User()
        {
            Received = new HashSet<Package>();
            Sent = new HashSet<Package>();
            IsAdmin = false;
        }
    }
}
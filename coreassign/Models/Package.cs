
using System;
using System.Collections.Generic;

namespace coreassign.Models
{
    public class Package
    {
        public uint IdPackage { get; set; }

        public String Name { get; set; }

        public String Description { get; set; }

        public bool Tracking { get; set; }

        public String SenderCity { get; set; }

        public String DestinationCity { get; set; }

        public uint SenderId { get; set; }

        public User Sender { get; set; }

        public uint ReceiverId { get; set; }

        public User Receiver { get; set; }

        public ICollection<Route> Route { get; set; }

        public Package()
        {
            Route = new HashSet<Route>();
        }
    }
}
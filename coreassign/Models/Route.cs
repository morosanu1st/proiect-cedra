
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace coreassign.Models
{
    public class Route
    {
        public uint IdRoute { get; set; }

        public int Time { get; set; }

        public String City { get; set; }

        public uint PackageId { get; set; }

        public Package Package { get; set; }
    }

}
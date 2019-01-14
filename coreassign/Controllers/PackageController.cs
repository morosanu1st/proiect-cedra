using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coreassign.dbstuff;
using coreassign.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace coreassign.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageController : ControllerBase
    {
        private Repo r;

        public PackageController([FromServices] BasicContext c)
        {
            r = new Repo(c);
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
            Package package = Newtonsoft.Json.JsonConvert.DeserializeObject<Package>(value);
            r.AddPackage(package);
        }

        [Route("/track")]
        [HttpPut]
        public void Put([FromBody] string value)
        {
            Route route= Newtonsoft.Json.JsonConvert.DeserializeObject<Route>(value);
            r.AddRoute(route);
        }
    }
}
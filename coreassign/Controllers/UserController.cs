using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coreassign.dbstuff;
using coreassign.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace coreassign.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private Repo r;

        public UserController([FromServices] BasicContext c)
        {
            r = new Repo(c);
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
            User user = Newtonsoft.Json.JsonConvert.DeserializeObject<User>(value);
            r.AddUser(user);
        }
    }
}
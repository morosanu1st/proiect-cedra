using coreassign.dbstuff;
using coreassign.Models;
using Microsoft.AspNetCore.Mvc;

namespace coreassign.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackingController : ControllerBase
    {
        private Repo r;

        public TrackingController([FromServices] BasicContext c)
        {
            r = new Repo(c);
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
            Route route = Newtonsoft.Json.JsonConvert.DeserializeObject<Route>(value);
            r.AddRoute(route);
        }
    }
}
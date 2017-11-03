using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
 
namespace api {

  [Route("api/[controller]")]
  public class TestController : ControllerBase {
    
    [HttpGet("hello/{name}")]
    public string PublicEndpoint(string name) {
      return $"Hello {name}";
    }

    [Authorize]
    [HttpGet("hello")]
    public Dictionary<string, object> SecureEndpoint() {
      return (
        from c in User.Claims
        group c by c.Type into g where g.Any()
        select new { g.Key, Values = g.Select(x => x.Value) }
      ).Aggregate(new Dictionary<string, object>(), (res, c) => {
        res.Add(c.Key, c.Values.Count() > 1 ? (object)c.Values : c.Values.First());
        return res;
      });
    }
  }
}
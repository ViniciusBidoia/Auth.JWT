using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Auth.JWT.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private string[] _values = new string[] { "Maria", "Paulo", "Pedro", "Marcia", "Armando" };

        [Authorize]
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return _values;
        }

        [Authorize]        
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            Random rdn = new Random();

            return _values[rdn.Next(0, 5)];
        }
    }
}

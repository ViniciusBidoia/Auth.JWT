using AutoMapper;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Auth.JWT.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosValuesController : ControllerBase
    {
        private readonly IMapper _mapper;


        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}

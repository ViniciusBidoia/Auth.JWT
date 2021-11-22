using Auth.JWT.API.ViewModel;
using Auth.JWT.Application.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Auth.JWT.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<UsuariosController> _log;
        private readonly IConfiguration _config;
        private readonly IUsuarioAppService _usuarioAppService;

        public UsuariosController(IMapper mapper, 
                                  ILogger<UsuariosController> log,
                                  IConfiguration config,
                                  IUsuarioAppService usuarioAppService)
        {
            _mapper = mapper;
            _log = log;
            _config = config;
            _usuarioAppService = usuarioAppService;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}

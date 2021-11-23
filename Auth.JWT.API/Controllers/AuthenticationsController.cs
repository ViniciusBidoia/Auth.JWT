using Auth.JWT.API.Util;
using Auth.JWT.API.ViewModel;
using Auth.JWT.Application.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Auth.JWT.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationsController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IUsuarioAppService _usuarioAppService;
        private readonly IMapper _mapper;

        public AuthenticationsController(IConfiguration config,
                                         IUsuarioAppService usuarioAppService, 
                                         IMapper mapper)
        {
            _config = config;
            _usuarioAppService = usuarioAppService;
            _mapper = mapper;
        }

        [HttpPost]        
        public async Task<ActionResult<dynamic>> Login([FromBody]LoginViewModel login)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = _usuarioAppService.Get(login.Username, login.Password);
            if (!_usuarioAppService.ValidUser(user))
                return Unauthorized();
            
            var token = TokenService.GenerateToken(user);

            user.Password = String.Empty;
                        
            return Ok(new { Usuario = _mapper.Map<UsuarioViewModel>(user), 
                            Token = token});
        }

        /// <summary>
        /// Permite acesso anônimo, sem autenticação alguma a página.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("anonymous")]
        [AllowAnonymous] 
        public string Anonymous() => "Anônimo";

        /// <summary>
        /// Requer que o usuário esteja autenticado, mas não se importa com seu perfil.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("authenticated")]
        [Authorize] 
        public string Authenticated() => String.Format("Autenticado - {0}", User.Identity.Name);

        /// <summary>
        /// Exige que o usuário além de autenticado, faça parte de um dos perfis listados.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("employee")]
        [Authorize(Roles = "employee,manager")] 
        public string Employee() => "Funcionário";

        /// <summary>
        /// Exige que o usuário além de autenticado, faça parte de um dos perfis listados.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("manager")]
        [Authorize(Roles = "manager")]
        public string Manager() => "Gerente";
    }
}

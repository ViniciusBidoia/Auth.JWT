using Auth.JWT.API.ViewModel;
using Auth.JWT.Application.Interfaces;
using Auth.JWT.Domain.Models;
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
        public async Task<ActionResult<List<UsuarioViewModel>>> Get()
        {
            List<UsuarioViewModel> usuarios;
            try
            {
                usuarios = _mapper.Map<List<UsuarioViewModel>>(await _usuarioAppService.ObterTodos());
                if (usuarios == null || !usuarios.Any())
                    return NoContent();
            }
            catch (Exception ex)
            {
                _log.LogError("Error --> UsuariosController.Get()", ex);
                throw;
            }
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioViewModel>> Get(Guid id)
        {
            UsuarioViewModel usuario;
            try
            {
                usuario = _mapper.Map<UsuarioViewModel>(await _usuarioAppService.ObterPorId(id));
                if (usuario == null)
                    return NoContent();
            }
            catch (Exception ex)
            {
                _log.LogError("Error --> UsuariosController.Get(id)", ex);
                throw;
            }
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult<LoginViewModel>> Post([FromBody] LoginViewModel login)
        {
            try
            {
                if (!ModelState.IsValid)
                    return NotFound(login);

                Usuario usuario = new Usuario()
                {
                    Username = login.Username,
                    Email = login.Email,
                    Password = login.Password
                };

                await _usuarioAppService.Adicionar(usuario);

            }
            catch (Exception ex)
            {
                _log.LogError("Error --> UsuariosController.Post(id)", ex);
                throw;
            }
            return Ok(login);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UsuarioViewModel>> Delete(Guid id)
        {
            UsuarioViewModel usuario;
            try
            {
                usuario = _mapper.Map<UsuarioViewModel>(await _usuarioAppService.ObterPorId(id));
                if (usuario == null)
                    return NoContent();
                
                await _usuarioAppService.Remover(id);
            }
            catch (Exception ex)
            {
                _log.LogError("Error --> UsuariosController.Delete(id)", ex);
                throw;
            }
            return Ok(usuario);
        }
    }
}

using Auth.JWT.API.ViewModel;
using Auth.JWT.Application.Interfaces;
using Auth.JWT.Domain.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Auth.JWT.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<UsersController> _log;
        private readonly IConfiguration _config;
        private readonly IUsuarioAppService _usuarioAppService;

        public UsersController(IMapper mapper,
                                  ILogger<UsersController> log,
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
        public async Task<ActionResult<UsuarioViewModel>> Post([FromBody] UsuarioViewModel usuario)
        {
            try
            {
                if (!ModelState.IsValid)
                    return NotFound(usuario);

                await _usuarioAppService.Adicionar(_mapper.Map<Usuario>(usuario));

            }
            catch (Exception ex)
            {
                _log.LogError("Error --> UsuariosController.Post(id)", ex);
                throw;
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(Guid id)
        {            
            try
            {
                var usuario = _mapper.Map<UsuarioViewModel>(await _usuarioAppService.ObterPorId(id));
                if (usuario == null)
                    return NoContent();
                
                await _usuarioAppService.Remover(usuario.Id);
            }
            catch (Exception ex)
            {
                _log.LogError("Error --> UsuariosController.Delete(id)", ex);
                throw;
            }
            return Ok(true);
        }
    }
}

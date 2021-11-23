using Auth.JWT.Application.Interfaces;
using Auth.JWT.Domain.Interfaces.Services;
using Auth.JWT.Domain.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.JWT.Application.Services
{
    public class UsuarioAppService : BaseAppService<Usuario>, IUsuarioAppService
    {
        private readonly IUsuarioService _service;
        private readonly ILogger<UsuarioAppService> _log;

        public UsuarioAppService(IUsuarioService service)
            :base(service)
        {
            _service = service;
        }

        public Usuario Get(string username, string password)
        {
            return _service.Get(username, password);
        }

        public bool ValidUser(Usuario user)
        {            
            try
            {
                if (user == null)
                    return false;                
            }
            catch (Exception ex)
            {
                _log.LogError("Error -> UsuarioAppService.ValidUser(username, password)", ex);
            }

            return true;
        }
    }
}

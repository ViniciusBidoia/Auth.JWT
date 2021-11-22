using Auth.JWT.Application.Interfaces;
using Auth.JWT.Domain.Interfaces.Services;
using Auth.JWT.Domain.Models;
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

        public UsuarioAppService(IUsuarioService service)
            :base(service)
        {
            _service = service;
        }
    }
}

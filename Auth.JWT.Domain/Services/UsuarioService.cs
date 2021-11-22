using Auth.JWT.Domain.Interfaces.Repositories;
using Auth.JWT.Domain.Interfaces.Services;
using Auth.JWT.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.JWT.Domain.Services
{
    public class UsuarioService : BaseService<Usuario>, IUsuarioService
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioService(IUsuarioRepository repository)
            :base(repository)
        {
            _repository = repository;
        }
    }
}

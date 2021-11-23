using Auth.JWT.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.JWT.Application.Interfaces
{
    public interface IUsuarioAppService : IBaseAppService<Usuario>
    {
        Usuario Get(string username, string password);

        bool ValidUser(Usuario usuario);
    }
}

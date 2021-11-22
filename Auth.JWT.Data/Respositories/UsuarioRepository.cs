using Auth.JWT.Data.Context;
using Auth.JWT.Domain.Interfaces.Repositories;
using Auth.JWT.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.JWT.Data.Respositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(ApplicationContext _context)
            : base(_context)
        {

        }
    }
}

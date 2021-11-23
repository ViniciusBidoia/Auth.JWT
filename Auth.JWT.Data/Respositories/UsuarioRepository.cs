using Auth.JWT.Data.Context;
using Auth.JWT.Domain.Interfaces.Repositories;
using Auth.JWT.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Auth.JWT.Data.Respositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        private readonly ApplicationContext _context;
        private readonly ILogger<UsuarioRepository> _log;

        public UsuarioRepository(ApplicationContext context,
                                 ILogger<UsuarioRepository> log)
            : base(context)
        {
            _context = context;
            _log = log;
        }

        public Usuario Get(string username, string password)
        {
            Usuario usuario = null;
            try
            {
                usuario = _context?.Usuario?.AsNoTracking()?.FirstOrDefault(x => x.Username == username && x.Password == password);
            }
            catch (Exception ex)
            {
                _log.LogError("Error --> UsuarioRepository.Get(username, password)", ex);
            }
            return usuario;
        }
    }
}

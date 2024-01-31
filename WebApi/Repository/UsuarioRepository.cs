using LibraryShared.Models;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;

namespace WebApi.Repository
{
    public class UsuarioRepository(DBPedDataContext context) : IUsuarioRepository
    {
        private readonly DBPedDataContext _context = context;

        public async Task<Usuario?> VerUsuario(Usuario usuario)
        {
            var result = await _context.Usuarios
              .Where(x => x.Nome == usuario.Nome && x.Password == usuario.Password)
              .FirstOrDefaultAsync();

            if (result != null)
            {
                return result;
            }
            else { return new Usuario(); }
        }
    }
    }

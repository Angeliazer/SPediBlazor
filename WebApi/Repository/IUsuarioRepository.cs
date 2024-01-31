using LibraryShared.Models;

namespace WebApi.Repository
{
    public interface IUsuarioRepository
    {
        Task<Usuario?> VerUsuario(Usuario usuario);
    }
}

using Fraccionamientos_LDS.Entities;
using Fraccionamientos_LDS.Repositories;

namespace Fraccionamientos_LDS.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers();
        User GetUserById(int id);
        void CrearUsuario(User usuario);
        void ActualizarUsuario(User usuario);
        void EliminarUsuario(int id);
    }

    public class UserService : IUserService
    {
        private readonly IUserRepository _usuarioRepository;

        public UserService(IUserRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public IEnumerable<User> GetUsers()
        {
            return _usuarioRepository.ObtenerUsuarios();
        }

        public User GetUserById(int id)
        {
            return _usuarioRepository.GetUserById(id);
        }

        public void CrearUsuario(User usuario)
        {
            _usuarioRepository.CrearUsuario(usuario);
        }

        public void ActualizarUsuario(User usuario)
        {
            _usuarioRepository.ActualizarUsuario(usuario);
        }

        public void EliminarUsuario(int id)
        {
            _usuarioRepository.EliminarUsuario(id);
        }
    }

}

using Fraccionamientos_LDS.Data;
using Fraccionamientos_LDS.Entities;
using Microsoft.EntityFrameworkCore;

namespace Fraccionamientos_LDS.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> ObtenerUsuarios();
        User GetUserById(int id);
        void CrearUsuario(User usuario);
        void ActualizarUsuario(User usuario);
        void EliminarUsuario(int id);
    }


    public class UserRepository : IUserRepository
    {
        private readonly ResidentialContext _context;

        public UserRepository(ResidentialContext context)
        {
            _context = context;
        }

        public IEnumerable<User> ObtenerUsuarios()
        {
            return _context.Users.ToList();
        }

        public User GetUserById(int id)
        {
            return _context.Users.Find(id);
        }

        public void CrearUsuario(User usuario)
        {
            _context.Users.Add(usuario);
            _context.SaveChanges();
        }

        public void ActualizarUsuario(User usuario)
        {
            _context.Entry(usuario).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void EliminarUsuario(int id)
        {
            var usuario = _context.Users.Find(id);
            if (usuario != null)
            {
                _context.Users.Remove(usuario);
                _context.SaveChanges();
            }
        }
    }

}

using System.ComponentModel.DataAnnotations;

namespace Fraccionamientos_LDS.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }
    }
}

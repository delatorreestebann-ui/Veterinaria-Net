using System.Threading.Tasks;

namespace Veterinaria.Servicios.Interfaces
{
    public interface IAuthService
    {
        Task<bool> Login(string email, string password);

        Task<bool> Register(
            string nombre,
            string apellido,
            string email,
            string telefono,
            string contraseña
        );
    }
}
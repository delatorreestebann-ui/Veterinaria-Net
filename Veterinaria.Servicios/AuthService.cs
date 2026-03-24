using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;
using API_Consumer;
using Veterinaria.Modelos;
using Veterinaria.Servicios.Interfaces;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;

namespace Veterinaria.Servicios
{
    public class AuthService : Interfaces.IAuthService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> Login(string email, string password)
        {
            var usuarios = Crud<PersonalAdministrativos>.GetAll();

            foreach (var usuario in usuarios)
            {
                if (usuario.email_Personal == email)
                {
                    // BCrypt compara el texto plano (password) con el Hash (contraseña_Personal)
                    if (BCrypt.Net.BCrypt.Verify(password, usuario.contraseña_Personal))
                    {
                        var datosUsuario = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, usuario.Nombre_Personal),
                            new Claim(ClaimTypes.Email, usuario.email_Personal),
                            new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                        };

                        var credencialDigital = new ClaimsIdentity(datosUsuario, "Cookies");
                        var usuarioAutenticado = new ClaimsPrincipal(credencialDigital);

                        await _httpContextAccessor.HttpContext.SignInAsync("Cookies", usuarioAutenticado);
                        return true;
                    }
                }
            }
            return false;
        }

        public async Task<bool> Register(
            string nombre,
            string apellido,
            string email,
            string telefono,
            string password)
        {
            // Verificamos duplicados
            var usuarioExistente = Crud<PersonalAdministrativos>.GetAll()
                 .FirstOrDefault(u => u.email_Personal == email);

            if (usuarioExistente != null)
            {
                Console.WriteLine("Error: El correo ya está registrado.");
                return false;
            }

            try
            {
                // CREACIÓN DEL OBJETO USUARIO (Mantenemos contraseña_Personal para el modelo)
                var nuevoUsuario = new PersonalAdministrativos
                {
                    Id = 0,
                    Nombre_Personal = nombre,
                    Apellido_Personal = apellido,
                    email_Personal = email,
                    Telefono_Personal = telefono,
                    contraseña_Personal = BCrypt.Net.BCrypt.HashPassword(password)
                };

                Crud<PersonalAdministrativos>.Create(nuevoUsuario);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al registrar usuario: {ex.Message}");
                return false;
            }
        }
    }
}
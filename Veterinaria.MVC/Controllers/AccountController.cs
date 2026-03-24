using API_Consumer;
using Veterinaria.Modelos;
using Veterinaria.Servicios.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace Veterinaria.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthService _authService;

        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }

        // GET: Account
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            // Ajuste de formato según tu profe
            email = email.Trim().ToLower();

            if (await _authService.Login(email, password))
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.ErrorMessage = "Email o password incorrectos.";
                return View("Index");
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(string nombre, string apellido, string email, string telefono, string password)
        {
            email = email.Trim().ToLower();

            // Verificación manual en el controller (estilo de tu profe)
            var usuario = Crud<PersonalAdministrativos>.GetAll()
                .FirstOrDefault(u => u.email_Personal.ToLower() == email);

            if (usuario != null)
            {
                ViewBag.ErrorMessage = "Esta cuenta ya está asociada a este correo";
                return View();
            }

            if (await _authService.Register(nombre, apellido, email, telefono, password))
            {
                return RedirectToAction("Index", "Account");
            }

            ViewBag.ErrorMessage = "Error al crear el usuario";
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            // Elimina la cookie de autenticación (usa el mismo string "Cookies" de tu Program.cs)
            await HttpContext.SignOutAsync("Cookies");
            return RedirectToAction("Index", "Account");
        }
    }
}
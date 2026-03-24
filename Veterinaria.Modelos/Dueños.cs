using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Veterinaria.Modelos
{
    public class Dueños
    {
        [Key] public int Id { get; set; }
        public string Nombre_dueño { get; set; }
        public string Apellido_dueño { get; set; }
        public string Telefono_dueño { get; set; }
        public string email_dueño { get; set; }
        public string contraseña_dueño { get; set; }

        public List<Mascotas>? Mascotas { get; set; } = new List<Mascotas>();

    }
}

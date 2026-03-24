using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Veterinaria.Modelos
{
    public class PersonalAdministrativos
    {
        [Key] public int Id { get; set; }
        public string Nombre_Personal { get; set; }
        public string Apellido_Personal { get; set; }
        public string Telefono_Personal { get; set; }
        public string email_Personal { get; set; }
        public string contraseña_Personal { get; set; }

        public List<Citas>? Citas { get; set; } = new List<Citas>();

    }
}

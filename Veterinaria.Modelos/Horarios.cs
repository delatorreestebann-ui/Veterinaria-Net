using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Veterinaria.Modelos
{
    public class Horarios
    {
        [Key] public int Id { get; set; }
        public DateTime Hora_Inicio { get; set; }

        public List<Citas>? Citas { get; set; } = new List<Citas>();

    }
}

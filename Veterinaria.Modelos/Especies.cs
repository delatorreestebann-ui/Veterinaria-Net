using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Veterinaria.Modelos
{
    public class Especies
    {
        [Key] public int Id { get; set; }
        public string Nombre_especie { get; set; }

        public List<Mascotas>? Mascotas { get; set; } = new List<Mascotas>();
    }
}

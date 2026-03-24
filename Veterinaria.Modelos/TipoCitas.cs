using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Veterinaria.Modelos
{
    public class TipoCitas
    {
        [Key] public int Id { get; set; }
        public string Descripcion { get; set; }

        public List<Citas>? Citas { get; set; } = new List<Citas>();
    }
}

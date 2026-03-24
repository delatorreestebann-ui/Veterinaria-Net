using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Veterinaria.Modelos
{
    public class Mascotas
    {
        [Key] public int Id { get; set; }
        public string Nombre_Mascota { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }

        // f de dueños
        [ForeignKey("DueñoId")]
        public int DueñoId { get; set; }
        public Dueños? Dueño { get; set; }

        // f de especies
        [ForeignKey("EspecieId")]
        public int EspecieId { get; set; }
        public Especies? Especie { get; set; }

        // mascota tiene muchas citas
        public List<Citas>? Citas { get; set; } = new List<Citas>();
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Veterinaria.Modelos
{
    public class Citas
    {
        [Key] public int Id { get; set; }

        [ForeignKey("MascotaId")]
        public int MascotaId { get; set; }
        public Mascotas? Mascota { get; set; }

        [ForeignKey("PersonalId")]
        public int PersonalId { get; set; }
        public PersonalAdministrativos? PersonalAdministrativo { get; set; }

        [ForeignKey("HorarioId")]
        public int HorarioId { get; set; }
        public Horarios? Horario { get; set; }

        [ForeignKey("TipoCitaId")]
        public int TipoCitaId { get; set; }
        public TipoCitas? TipoCita { get; set; }

    }
}

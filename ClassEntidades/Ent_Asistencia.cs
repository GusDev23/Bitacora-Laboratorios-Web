using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassEntidades
{
    public class Ent_Asistencia
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int f_ProfeCuatri { get; set; }
        public Int16 f_Laboratorio { get; set; }
        public Byte f_HoraEntrada { get; set; } 
        public Byte f_HoraSalida { get; set; }
        public Byte N_Alumnos { get; set; }
        public string Tema { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyPOOI_T2.Models
{
    public class Sp_ListarCitasPorAnio
    {
        public int NumeroCita {  get; set; }
        public DateTime FechaCita { get; set; }
        public string CodigoPaciente { get; set; }
        public string NombreMedico { get; set; }
        public decimal Precio { get; set; }

    }
}
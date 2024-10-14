using ProyPOOI_T2.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace ProyPOOI_T2.Controllers
{
    public class MinayaT2Controller : Controller
    {
        string cad = ConfigurationManager.ConnectionStrings["cn1"].ConnectionString;

        private List<Sp_ListarCitasPorAnio> ListaCitasAnio(int anio)
        {
            var lista = new List<Sp_ListarCitasPorAnio>();

            SqlConnection cnx = new SqlConnection(cad);
            cnx.Open();
            string cad_sql = $"EXEC Sp_ListarCitasPorAnio {anio}";
            SqlCommand cmd = new SqlCommand(cad_sql, cnx);

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                lista.Add(new Sp_ListarCitasPorAnio()
                    {
                        NumeroCita = dr.GetInt32(0),
                        FechaCita = dr.GetDateTime(1),
                        CodigoPaciente = dr.GetString(2),
                        NombreMedico = dr.GetString(3),
                        Precio = dr.GetDecimal(4)
                    }
                    );
            }
            dr.Close();
            cnx.Close();
            return lista;
        }
        public ActionResult ConsultarCitasMedico(int anio = 2023) //2022  2023  2024
        {
            var list = ListaCitasAnio(anio);
            ViewBag.cont = list.Count;
            return View(list);
        }
    }
}
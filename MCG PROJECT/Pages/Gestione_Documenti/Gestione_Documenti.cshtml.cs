using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace MCG_PROJECT.Pages.Gestione_Documenti
{
    public class Index1Model : PageModel
    {
        public List<Documentiinfo> documentiis = new List<Documentiinfo>();

        public void OnGet()
        {
            string idCorso = Request.Query["idCorso"];
            string connessione = "Server=DESKTOP-UOEE9EA\\SQLEXPRESS;Database=MCGCorsi;Trusted_Connection=true;";
            string strSQL = "execute [dbo].[Gestione_Documenti]";
            SqlConnection con = new SqlConnection(connessione);
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@idCorso", idCorso);
                SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Documentiinfo model = new Documentiinfo();
                        model.idCorsista = reader.GetString(0);
                        model.Cognome = reader.GetString(1);
                        model.Nome = reader.GetString(2);
                        model.Cartaidentità = reader.GetString(3);
                        model.CertificatoResidenza = reader.GetString(4);
                        model.CodiceFiscale = reader.GetString(5);
                        model.CV = reader.GetString(6);
                        model.Diploma = reader.GetString(7);
                        model.Idoneità = reader.GetString(8);
                        model.PatenteGuida = reader.GetString(9);
                        documentiis.Add(model);
                    }
            }
        }

        public class Documentiinfo
        {
            public string idCorsista;
            public string Cognome;
            public string Nome;
            public string Cartaidentità;
            public string CertificatoResidenza;
            public string CodiceFiscale; 
            public string CV;
            public string Diploma;
            public string Idoneità;
            public string PatenteGuida;
        }
    }










}


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
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = strSQL;
            cmd.Parameters.AddWithValue("idCorso", idCorso);
            cmd.Connection = con;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                //public dynamic Documentiinfo = new Documentiinfo();
        //Documentiinfo model = new Documentiinfo();
        //var model = Documentiinfo as idCorso<string, object>;
        //qua vanno inserite le variabili derivate dal database (attendere Marco)
        model.idCorsista = reader.GetString(0);
                model.Cognome = reader.GetString(1);
                model.nome = reader.GetString(2);
                model.Cartaidentità = reader.GetString(3);
                model.CertificatoResidenza = reader.GetString(4);
                model.CodiceFiscale = reader.GetString(5);
                model.CV = reader.GetString(6);
                model.Diploma = reader.GetString(7);
                model.Idoneità = reader.GetString(8);
                model.PatenteGuida = reader.GetString(9);
                documentiis.Add(model);
            }
            con.Close();
        }
    }

    
    
 
    




}


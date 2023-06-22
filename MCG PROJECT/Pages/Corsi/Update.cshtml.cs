using MCG_PROJECT.Pages.Utenti;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace MCG_PROJECT.Pages.Corsi
{
    public class EditModel : PageModel
    {
        public List<Corsiinfo> corsis = new List<Corsiinfo>();
        public Corsiinfo corsi = new Corsiinfo();

        public void OnGet()
        {
            string idCorso = Request.Query["idCorso"];
            string connessione = "Server=DESKTOP-UOEE9EA\\SQLEXPRESS;Database=MCGCorsi;Trusted_Connection=true";
            string strSQL = "select idCorso, Codice, Corso, Area, CONVERT(nvarchar(10),DataInizio, 103)Inizio,CONVERT(nvarchar(10),DataFine, 103)Fine, Ente, Stato from Corsi WHERE idCorso=@idCorso";
            SqlConnection con = new SqlConnection(connessione);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = strSQL;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("idCorso", idCorso);
            SqlDataReader reader = cmd.ExecuteReader();
             while (reader.Read())
            {
                Corsiinfo infocorsi = new Corsiinfo();
                infocorsi.idCorso = reader.GetInt32(0);
                infocorsi.Codice = reader.GetString(1);
                infocorsi.Corso = reader.GetString(2);
                infocorsi.Area = reader.GetString(3);
                infocorsi.Inizio = reader.GetString(4);
                infocorsi.Fine = reader.GetString(5);
                infocorsi.Ente = reader.GetString(6);
                infocorsi.Stato = reader.GetInt32(7);
                corsis.Add(infocorsi);
            }
            con.Close();
        }

        public void OnPost()
        {
                corsi.Codice=Request.Form["textboxCorso"];
                corsi.Corso=Request.Form["textboxCorso"];
                corsi.Area=Request.Form["textboxArea"];
                corsi.Inizio=Request.Form["textboxInizio"];
                corsi.Fine=Request.Form["textboxFine"];
                corsi.Ente=Request.Form["textboxEnte"];
                //corsi.Stato=Request.Form["textboxStato"];
            
            string idCorso = Request.Query["idCorso"];
            string connessione = "Server=DESKTOP-UOEE9EA\\SQLEXPRESS;Database=MCGCorsi;Trusted_Connection=true";
            string strSQL = "UPDATE Corsi SET Codice=@Codice, Corso=@Corso, Area=@Area, DataInizio=@Inizio, DataFine=@Fine, Ente=@Ente, Stato=2 WHERE idCorso=@idCorso";
            SqlConnection conn = new SqlConnection(connessione);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = strSQL;
            cmd.Parameters.AddWithValue("idCorso", idCorso);
            cmd.Parameters.AddWithValue("Codice", corsi.Codice);
            cmd.Parameters.AddWithValue("Corso", corsi.Corso);
            cmd.Parameters.AddWithValue("Area", corsi.Area);
            cmd.Parameters.AddWithValue("Inizio", corsi.Inizio);
            cmd.Parameters.AddWithValue("Fine", corsi.Fine);
            cmd.Parameters.AddWithValue("Ente", corsi.Ente);
            cmd.Parameters.AddWithValue("Stato", 2);
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();
            // Response.Redirect("/Utenti");
            conn.Close();
        }
    }
}


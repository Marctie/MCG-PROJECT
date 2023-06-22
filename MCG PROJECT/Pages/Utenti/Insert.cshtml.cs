using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace MCG_PROJECT.Pages.Utenti
{
    public class InsertModel : PageModel
    {
        public Utentiinfo info = new Utentiinfo();
        public void OnGet()
        {
        }

        public void OnPost()
        {
            // tabella Corsisti modificare i campi

            info.CodiceFiscale = Request.Form["textboxCodiceFiscale"];
            info.Cognome = Request.Form["textboxCognome"];
            info.Nome = Request.Form["textboxNome"];
            info.DataNascita = Request.Form["textboxDataNascita"];
            info.LuogoNascita = Request.Form["textboxLuogoNascita"];
            info.Indirizzo = Request.Form["textboxIndirizzo"];
            info.CAP = Request.Form["textboxCAP"];
            info.Citta = Request.Form["textboxCitta"];
            info.Provincia = Request.Form["textboxProvincia"];
            info.Nazione = Request.Form["textboxNazione"];
            info.email = Request.Form["textboxemail"];
            info.psw = Request.Form["textboxpsw"];
            info.Stato = 1;

            
            string connessione = "Server=DESKTOP-UOEE9EA\\SQLEXPRESS;Database=MCGCorsi;Trusted_Connection=true";
            string strSQL = "INSERT INTO Corsisti (CodiceFiscale, Cognome, Nome, DataNascita, LuogoNascita, Indirizzo, CAP, Citta, Provincia, Nazione, email, psw, Stato) VALUES (@CodiceFiscale, @Cognome, @Nome, @DataNascita, @LuogoNascita, @Indirizzo, @CAP, @Citta, @Provincia, @Nazione, @email, @psw, 1)";
            SqlConnection conn = new SqlConnection(connessione);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = strSQL;
            cmd.Connection = conn;

            cmd.Parameters.AddWithValue("CodiceFiscale", info.CodiceFiscale);
            cmd.Parameters.AddWithValue("Cognome", info.Cognome);
            cmd.Parameters.AddWithValue("Nome", info.Nome);
            cmd.Parameters.AddWithValue("DataNascita", info.DataNascita);
            cmd.Parameters.AddWithValue("LuogoNascita", info.LuogoNascita);
            cmd.Parameters.AddWithValue("Indirizzo", info.Indirizzo);
            cmd.Parameters.AddWithValue("CAP", info.CAP);
            cmd.Parameters.AddWithValue("Citta", info.Citta);
            cmd.Parameters.AddWithValue("Provincia", info.Provincia);
            cmd.Parameters.AddWithValue("Nazione", info.Nazione);
            cmd.Parameters.AddWithValue("email", info.email);
            cmd.Parameters.AddWithValue("psw", info.psw);
            cmd.Parameters.AddWithValue("Stato", 1);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}


using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace MCG_PROJECT.Pages.Utenti
{
    public class CreateModel : PageModel
    {
        public List<Utentiinfo> utentis = new List<Utentiinfo>();
        public Utentiinfo info = new Utentiinfo();

        public void OnGet()
        {
            
            string connessione = "Server=DESKTOP-UOEE9EA\\SQLEXPRESS;Database=MCGCorsi;Trusted_Connection=true";
            string strSQL = "select CodiceFiscale, Cognome, Nome, CONVERT(nvarchar(10),DataNascita, 103) DataNascita, LuogoNascita, Indirizzo, CAP, Citta, Provincia, Nazione, email, psw, Stato from Corsisti";
            SqlConnection con = new SqlConnection(connessione);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = strSQL;
            cmd.Connection = con;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                Utentiinfo info = new Utentiinfo();
                info.CodiceFiscale = reader.GetString(0);
                info.Cognome = reader.GetString(1);
                info.Nome = reader.GetString(2);
                info.DataNascita = reader.GetString(3);
                info.LuogoNascita = reader.GetString(4);
                info.Indirizzo = reader.GetString(5);
                info.CAP = reader.GetString(6);
                info.Citta = reader.GetString(7);
                info.Provincia = reader.GetString(8);
                info.Nazione = reader.GetString(9);
                info.email = reader.GetString(10);
                info.psw = reader.GetString(11);
                utentis.Add(info);
            }
            con.Close();

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
       

            
            string connessione = "Server=DESKTOP-UOEE9EA\\SQLEXPRESS;Database=MCGCorsi;Trusted_Connection=true";
            string strSQL = "UPDATE Corsisti SET Cognome=@Cognome, Nome=@Nome, DataNascita=@DataNascita, LuogoNascita=@LuogoNascita, Indirizzo=@Indirizzo, CAP=@CAP, Citta=@Citta, Provincia=@Provincia, Nazione=@Nazione, email=@email, psw=@psw, Stato=2 WHERE CodiceFiscale=@CodiceFiscale";
            SqlConnection conn = new SqlConnection(connessione);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = strSQL;

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
            cmd.Parameters.AddWithValue("Stato", 2);
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();
            // Response.Redirect("/Utenti");
            conn.Close();
        }
    }
}
    


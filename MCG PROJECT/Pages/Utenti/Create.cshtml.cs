using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace MCG_PROJECT.Pages.Utenti
{
    public class CreateModel : PageModel
    {
        public void OnGet()
        {
        }

        public void OnPost() 
        {
            // tabella Corsisti modificare i campi
            Utentiinfo.Nome;
            Utentiinfo.Cognome;
            Utentiinfo.NomeUtente;
            Utentiinfo.Psw;
            Utentiinfo.Avatar;
            Utentiinfo.Stato = 1;

            string connessione=#;
            string.strSQL=#;
            SqlConnection conn = new SqlConnection(connessione);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = strSQL;
            cmd.Parameters.AddWithValue();
            cmd.Parameters.AddWithValue();
            cmd.Parameters.AddWithValue();
            cmd.Parameters.AddWithValue();
            cmd.Parameters.AddWithValue();
            cmd.Parameters.AddWithValue();
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();
            Response.Redirect("/Utenti");
            conn.Close();
        }
    }
}

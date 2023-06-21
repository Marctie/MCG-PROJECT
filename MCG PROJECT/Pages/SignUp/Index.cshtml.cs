using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace MCG_PROJECT.Pages.SignUp
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
        }

        public void OnPost(string codiceFiscale, string cognome, string nome, DateTime dataDiNascita, string luogoDiNascita, string indirizzo, string codicePostale, string citta, string provincia, string paese, string email, string password)
        {
            string connessione = "Server=DESKTOP-UOEE9EA\\SQLEXPRESS;Database=MCGCorsi;Trusted_Connection=true;";
            SqlConnection con = new SqlConnection(connessione);
            try {
                con.Open();
                string strSQL = "INSERT INTO Users (CodiceFiscale, Cognome, Nome, DataDiNascita, LuogoDiNascita, Indirizzo, CodicePostale, Citta, Provincia, Paese, Email, Password) " +
                               "VALUES (@CodiceFiscale, @Cognome, @Nome, @DataDiNascita, @LuogoDiNascita, @Indirizzo, @CodicePostale, @Citta, @Provincia, @Paese, @Email, @Password)";
                SqlCommand cmd = new SqlCommand(strSQL);
                cmd.Parameters.AddWithValue("@CodiceFiscale", codiceFiscale);
                cmd.Parameters.AddWithValue("@Cognome", cognome);
                cmd.Parameters.AddWithValue("@Nome", nome);
                cmd.Parameters.AddWithValue("@DataDiNascita", dataDiNascita);
                cmd.Parameters.AddWithValue("@LuogoDiNascita", luogoDiNascita);
                cmd.Parameters.AddWithValue("@Indirizzo", indirizzo);
                cmd.Parameters.AddWithValue("@CodicePostale", codicePostale);
                cmd.Parameters.AddWithValue("@Citta", citta);
                cmd.Parameters.AddWithValue("@Provincia", provincia);
                cmd.Parameters.AddWithValue("@Paese", paese);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);

                int righeModificate = cmd.ExecuteNonQuery();

                if (righeModificate > 0) {
                    Response.Redirect("registrazione-successo.aspx");
                }
                else {
                    Response.Redirect("Error.aspx");
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("Si è verificato un errore durante la registrazione: " + ex.Message);
            }
        }
    }
}
 





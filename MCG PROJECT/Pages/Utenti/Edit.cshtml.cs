using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace MCG_PROJECT.Pages.Utenti
{
    public class EditModel : PageModel
    {
        //public List<DocumentiInfo> documentis=new List<DocumentiInfo>();
        public void OnGet()
        {
            string idDocumento = Request.Query["idDocumento"];
            //da modificare appena pronto il db (attendere Marco) 
            string connessione = "DESKTOP-UOEE9EA\\SQLEXPRESS; Database=Cliente MCG - Corsisti;Trusted_Connection=true;";
            SqlConnection con = new SqlConnection(connessione);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            //Query da modificare appena pronto il db (attendere Marco) 
            cmd.CommandText = "SELECT idDocumento,Numero,CONVERT (nvarchar(10),DataDocumento,103) DataDocumento,U.NomeUtente From Documenti D INNER JOIN Utenti U ON D.idSoggetto = U.id WHERE idDocumento=@idDocumento";
            cmd.Parameters.AddWithValue("idDocumento", idDocumento);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                DocumentiInfo documenti = new DocumentiInfo();
                //campi da modificare (attendere Marco) 
                documenti.idDocumento = "" + reader.GetInt32(0);
                documenti.Numero = reader.GetString(1);
                documenti.DataDocumento = reader.GetString(2);
                documenti.NomeUtente = reader.GetString(3);
                documenti.Add(documenti);
            }
            con.Close();
        }
        public void OnPost()
        {

        }
        public class DocumentiInfo
        {
            //Campi da modificare (attendere Marco) 
            public string idDocumento;
            public string DataDocumento;
            public string Numero;
            public string NomeUtente;
        }

    }


}
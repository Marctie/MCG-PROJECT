using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Configuration;
using System.Data.SqlClient;

namespace MCG_PROJECT.Pages.Corsi
{
    public class IndexModel : PageModel
    {
        public List <Corsiinfo> corsiis = new List <Corsiinfo>();
        public void OnGet()
        {
            string connessione = "Server=DESKTOP-UOEE9EA\\SQLEXPRESS;Database=MCGCorsi;Trusted_Connection=true;";
            string strSQL = "select idCorso, Codice, Corso, Area, CONVERT(nvarchar(10),DataInizio, 103) Inizio, CONVERT(nvarchar(10),DataFine, 103) Fine, Ente, Stato from Corsi Order by Corso";
            SqlConnection con = new SqlConnection(connessione);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = strSQL;
            cmd.Connection = con;
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
                corsiis.Add(infocorsi);
            }
            con.Close();
        }
    }
        public class Corsiinfo
        {
            public int idCorso;
            public string Codice;
            public string Corso;
            public string Area;
            public string Inizio;
            public string Fine;
            public string Ente;
            public int Stato;
        }
    }

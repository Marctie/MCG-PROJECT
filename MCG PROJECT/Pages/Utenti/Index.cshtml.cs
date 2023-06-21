using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Configuration;
using System.Data.SqlClient;


namespace MCG_PROJECT.Pages.Utenti
{
    public class IndexModel : PageModel
    {
        //metodo per leggere i dati nel DB 
        public List <Utentiinfo> utentis = new List<Utentiinfo> ();
        public void OnGet()
        {
//la stringa successiva è da cambiare appena pronto il db (attendere Marco)
            string connessione = "Server=DESKTOP-UOEE9EA\\SQLEXPRESS;Database=MCGCorsi;Trusted_Connection=true;";
            string strSQL = "select CodiceFiscale, Cognome, Nome, CONVERT(nvarchar(10),DataNascita, 103) DataNascita, LuogoNascita, Indirizzo, CAP, Citta, Provincia, Nazione, email, psw, Stato from Corsisti";
            SqlConnection con = new SqlConnection(connessione);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = strSQL;
            cmd.Connection = con; 
            SqlDataReader reader= cmd.ExecuteReader();
            while (reader.Read())
            {
                Utentiinfo info = new Utentiinfo();
                //qua vanno inserite le variabili derivate dal database (attendere Marco)
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
                info.Stato = reader.GetInt32(12);
                utentis.Add(info);
            }
            con.Close();


        }

       
    }
    public class Utentiinfo
    {
        //inserire i campi del db (attendere Marco) 
        public string CodiceFiscale;
        public string Cognome;
        public string Nome;
        public string DataNascita;
        public string LuogoNascita;
        public string Indirizzo;
        public string CAP;
        public string Citta;
        public string Provincia;
        public string Nazione;
        public string email;
        public string psw;
        public int Stato;
         

    }
}

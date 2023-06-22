using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System;
using System.Text;

namespace MCG_PROJECT.Pages.Gestione_Documenti
{
    public class Index1Model : PageModel
    {
        //public List<Documentiinfo> documentiis = new List<Documentiinfo>();
        public List<string> columnNames = new List<string>();
         public StringBuilder htmlBuilder = new StringBuilder();
        public void OnGet()
        {
            string idCorso = Request.Query["idCorso"];
            string connessione = "Server=DESKTOP-UOEE9EA\\SQLEXPRESS;Database=MCGCorsi;Trusted_Connection=true;";
            string strSQL = "execute [dbo].[Gestione_Documenti]";
            // Esecuzione della query e lettura dei risultati
            SqlConnection con = new SqlConnection(connessione);
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(strSQL, con);
                SqlDataReader reader = cmd.ExecuteReader();
                cmd.Parameters.AddWithValue("@idCorso", idCorso);
                // Recupera i nomi delle colonne dinamiche
                for (int i = 1; i < reader.FieldCount; i++)
                {



                    string idCorsista = reader.GetName(i);
                    columnNames.Add(idCorsista);
                    string Cognome = reader.GetName(i);
                    columnNames.Add(Cognome);
                    string nome = reader.GetName(i);
                    columnNames.Add(nome);
                    string CartaIdentità = reader.GetName(i);
                    columnNames.Add(CartaIdentità);
                    string CertificatoResidenza = reader.GetName(i);
                    columnNames.Add(CertificatoResidenza);
                    string CF = reader.GetName(i);
                    columnNames.Add(CF);
                    string CV = reader.GetName(i);
                    columnNames.Add(CV);
                    string Diploma = reader.GetName(i);
                    columnNames.Add(Diploma);
                    string Idoneità = reader.GetName(i);
                    columnNames.Add(Idoneità);
                    string PatenteGuida = reader.GetName(i);
                    columnNames.Add(PatenteGuida);
                }
            }

            con.Close();

            //SqlConnection con = new SqlConnection(connessione);
            ////{
            //    con.Open();
            //    SqlCommand cmd = new SqlCommand(strSQL, con);
                
                //SqlDataReader reader = cmd.ExecuteReader();
                //    while (reader.Read())
                //    {
                //        Documentiinfo model = new Documentiinfo();
                //        model.idCorsista = reader.GetString(0);
                //        model.Cognome = reader.GetString(1);
                //        model.Nome = reader.GetString(2);
                //        model.Cartaidentità = reader.GetString(3);
                //        model.CertificatoResidenza = reader.GetString(4);
                //        model.CodiceFiscale = reader.GetString(5);
                //        model.CV = reader.GetString(6);
                //        model.Diploma = reader.GetString(7);
                //        model.Idoneità = reader.GetString(8);
                //        model.PatenteGuida = reader.GetString(9);
                //        documentiis.Add(model);
                //    }
            }
        }

        //public class Documentiinfo
        //{
        //    public string idCorsista;
        //    public string Cognome;
        //    public string Nome;
        //    public string Cartaidentità;
        //    public string CertificatoResidenza;
        //    public string CodiceFiscale; 
        //    public string CV;
        //    public string Diploma;
        //    public string Idoneità;
        //    public string PatenteGuida;
        //}
    }













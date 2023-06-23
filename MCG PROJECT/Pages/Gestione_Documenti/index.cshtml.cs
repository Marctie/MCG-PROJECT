using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System;
using System.Text;

namespace MCG_PROJECT.Pages.Gestione_Documenti
{
    public class Index1Model : PageModel
    {
        public List<Documentiinfo> documentiis = new List<Documentiinfo>();
        public List<string> columnNames = new List<string>();
         
        public void OnGet()
        {
            string idCorso = Request.Query["idCorso"];
            string connessione = "Server=DESKTOP-UOEE9EA\\SQLEXPRESS;Database=MCGCorsi;Trusted_Connection=true;";
            string strSQL = "execute [dbo].[Gestione_Documenti] 2";
            // Esecuzione della query e lettura dei risultati
            SqlConnection con = new SqlConnection(connessione);
            
                con.Open();
                SqlCommand cmd = new SqlCommand(strSQL, con);
                //cmd.Parameters.AddWithValue("idCorso", 2);

                SqlDataReader reader = cmd.ExecuteReader();
                // Recupera i nomi delle colonne dinamiche

                for (int j = 0; j < reader.FieldCount; j++)
                {
                    ColName c = new ColName();
                    c.Name = reader.GetName(j);
                    columnNames.Add(c.Name);
                }
                while (reader.Read())
            {
                string[] terms = new string[reader.FieldCount]; 
                for (int k = 0; k < reader.FieldCount; k++)
                {
                    
                    terms[k] = reader.GetString(k).ToString();
                    
                }
                

            }
                
                


            
            reader.Close();
            con.Close();

            
            }
        }

        public class ColName
    {
        public string Name { get; set; }
    }

    public class Documentiinfo
    {
        public string[] Name;
    }

      
    }













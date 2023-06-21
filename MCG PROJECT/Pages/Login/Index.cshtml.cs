using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Data.SqlClient;
using System.Web;

namespace MCG_PROJECT.Pages.Login
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
        }

    public void OnPost(string UserName, string password)
        {
                string connessione = "Server=DESKTOP-UOEE9EA\\SQLEXPRESS;Database=MCGCorsi;Trusted_Connection=true;";
                try
                {
                    SqlConnection con = new SqlConnection(connessione);
                    {
                        con.Open();
                        string strSQL = "SELECT * FROM Users WHERE UserName = @UserName AND Password = @Password";
                        SqlCommand cmd = new SqlCommand(strSQL, con);
                        cmd.Parameters.AddWithValue("@UserName", UserName);
                        cmd.Parameters.AddWithValue("@Password", password);

                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            //se login ok
                            Response.Redirect("home.aspx"); // poi da  mettere la pagina post login 
                        }
                        else
                        {
                            Response.Redirect("Error.aspx");
                        }
                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine("il programma fa schifo: " + ex.Message);
                }
            }
        }
    }
       



using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
namespace MyCloudStore
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "LoginChk" in both code and config file together.
    public class LoginChk : ILoginChk
    {
        
        public bool Login(string username, string password)
        {
            bool rez = false;
            if(string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return false;
            }
            //string conStr = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            //string conStr = "Server=KORISNIK-PC\\SQLEXPRESS;Trusted_Connection=True;";//treba iz appconfig al me mrzi
            string conStr = Convert.ToString(Properties.Settings.Default.Properties["ConnStringDb"].DefaultValue);

            SqlConnection con = new SqlConnection(conStr);
            try
            {
                SqlCommand com = con.CreateCommand();
                com.CommandText = "SELECT * from [Zastita].[dbo].[User] WHERE username='" + username + "' AND password = '" + password + "';";
                con.Open();
                SqlDataReader rd = com.ExecuteReader();

                if (rd.HasRows)
                // if (username == "tmp1" && password == "pas1")
                {
                    rez = true;
                }
               

                con.Close();
            }
            catch (Exception e)
            {
                rez = false;
            }
            finally
            {
                con.Close();
                
            }
            return rez;
        }
    }
}

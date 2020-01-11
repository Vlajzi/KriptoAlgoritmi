using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCloudStore
{
    class FileServer : IFileServer
    {


        string conStr = "Server=KORISNIK-PC\\SQLEXPRESS;Database=Zastita;Trusted_Connection=True;";
        public void DeleteFile(string virtualPath,string username,string password)
        {
            
            string filePath = Path.Combine("", virtualPath);

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }//odgovor treba
        }

        public byte[] GetFile(string virtualPath, string username, string password)
        {
            int id = -1;
            string basePath = GetUSerDir(username, password, ref id);
            string filePath = Path.Combine(basePath, virtualPath);

            if (!File.Exists(filePath))
                throw new FileNotFoundException("File was not found",
                                                Path.GetFileName(filePath));

            byte[] fajl = File.ReadAllBytes(filePath);

            return fajl;
        }

        public StorageFileInfo[] List( string username, string password)
        {
            int id = -1;
            string basePath = GetUSerDir(username, password, ref id);

            //DirectoryInfo dirInfo = new DirectoryInfo(basePath);
            //FileInfo[] files = dirInfo.GetFiles("*.*", SearchOption.AllDirectories);

            List<StorageFileInfo> rez = new List<StorageFileInfo>();
            SqlConnection con = new SqlConnection(conStr);
            try
            {
                SqlCommand com = con.CreateCommand();
                com.CommandText = "SELECT * from [Zastita].[dbo].[Files] WHERE U_ID= "+id+";";
                con.Open();
                SqlDataReader rd = com.ExecuteReader();
                while(rd.Read())
                {
                    StorageFileInfo tmp = new StorageFileInfo();
                    tmp.hesh = rd["Hesh"].ToString();
                    tmp.VirtualPath = rd["virtualPath"].ToString();
                    string path = Path.Combine(basePath, tmp.VirtualPath);
                    tmp.Size =(new FileInfo(path)).Length;
                    rez.Add(tmp);
                }

            }
            catch (Exception e)
            {

            }
            finally
            {
                con.Close();

            }

            return rez.ToArray();
        }

        public void PutFile(FileUpload file, string username, string password)
        {
            int id = -1;
            string initPath = GetUSerDir(username, password,ref id);
            
            string filePath = Path.Combine(initPath, file.info.VirtualPath);
            string dir = Path.GetDirectoryName(filePath);

            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            File.WriteAllBytes(filePath, file.Data);


            UpdateDB(ref file, id);

        }


        private string GetUSerDir(string username,string password,ref int id)
        {
            string s = string.Empty;

           //treba iz appconfig
            SqlConnection con = new SqlConnection(conStr);
            try
            {
                SqlCommand com = con.CreateCommand();
                com.CommandText = "SELECT * from [Zastita].[dbo].[User] WHERE username='" + username + "' AND password ='" + password + "';";
                con.Open();
                SqlDataReader rd = com.ExecuteReader();
                bool test = rd.Read();
                s = rd["filePath"].ToString();
                id = Convert.ToInt32(rd["id"].ToString());

            }
            catch (Exception e)
            {
                
            }
            finally
            {
                con.Close();

            }

            return s;
        }

        private void UpdateDB(ref FileUpload file,int id)
        {
            string updateString = "INSERT INTO [Zastita].[dbo].[Files] ( virtualPath, Hesh, U_ID )"+ 
                "VALUES ('"+ file.info.VirtualPath+"','"+file.Hesh+"' ,"+id+" )";

            SqlConnection con = new SqlConnection(conStr);
            try
            {
                SqlCommand com = con.CreateCommand();
                com.CommandText = updateString;
                con.Open();
                com.ExecuteNonQuery();

            }
            catch (Exception e)
            {

            }
            finally
            {
                con.Close();

            }

        }
    }
}

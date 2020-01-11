using MyCloudStore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Klijent.Service1;

namespace Klijent
{
    
    public partial class MainForm : Form
    {

        public string userName;
        public string userPassword;

        XXTEA t;
        PCBC p;
        SHA2 sha2;
        Knapsak ks;
        int test;

        //String pathTmp = @"C:\Users\Intel\Desktop\TestFolder";
        string pathBase = @"C:\UserData\";
        string filePathUload;
        Form logScrean;
        public MainForm(Form logScrean)
        {

            this.logScrean = logScrean;
            UInt32[] key = new UInt32[4];
            key[0] = 1;
            key[1] = 2;
            key[2] = 3;
            key[3] = 4;
            string filePathUload = string.Empty;
            UInt32[] initial = { 1232322, 4132244 };


            InitializeComponent();
            t = new XXTEA(key);
            p = new PCBC(ref initial, key);
            sha2 = new SHA2();
            ks = new Knapsak();
            comboBox1.SelectedIndex = 0;


            numb_XXTEA_1.Maximum = UInt32.MaxValue;
            numb_XXTEA_2.Maximum = UInt32.MaxValue;
            numb_XXTEA_3.Maximum = UInt32.MaxValue;
            numb_XXTEA_4.Maximum = UInt32.MaxValue;

            

        }

        private unsafe void button1_Click(object sender, EventArgs e)
        {


            string test = "Mahesh";



            /*textBox1.Text = test;

            t.Encript(ref test);

            textBox1.Text = test;

            t.Decript(ref test);

            textBox1.Text = test;*/

            /* textBox1.Text = test;

              p.Encript(ref test);

              textBox1.Text = test;

              p.Decript(ref test);

              textBox1.Text = test;*/

            

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
          
            if (logScrean != null)
            {
                logScrean.Close();
            }
            
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            GetFiles();
        }



        private void GetFiles()
        {
            List<StorageFileInfo> putanje ;


            FileServerClient fs = new FileServerClient();

            putanje = fs.List(userName,userPassword).ToList();

            listBox1.DataSource = putanje;


        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.listBox1.IndexFromPoint(e.Location);
            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                //getFile the sav the open

                FileServerClient sf = new FileServerClient();

                

                string file = ((StorageFileInfo)listBox1.Items[index]).VirtualPath;
                string hesh = ((StorageFileInfo)listBox1.Items[index]).hesh;

                byte[] data = sf.GetFile(file, userName, userPassword);

                string temPath = Path.GetTempPath();
                string filePath = Path.Combine(temPath, file);
                //treba se proveri
                string metod = GetEncForFile(file);
                bool state = false;
                if (metod == "XXTEA")
                {
                    state = DecriptXXTEA(ref data, hesh, file);
                }
                else if(metod == "PCBC")
                {
                    state = DecriptPCBC(ref data, hesh, file);
                }
                else if(metod == "Knapsak")
                {
                    state = DecriptKnapsak(ref data, hesh, file);
                }
                else if(metod == "SimSub")
                {
                    state = DecriptSimSub(ref data, hesh, file);
                }

                if (state)
                {
                    File.WriteAllBytes(filePath, data);

                    System.Diagnostics.Process.Start(filePath);//tmp path
                }
                
            }
        }



        private string GetEncForFile(string file)
        {
            String put = Path.Combine(pathBase, userName + ".txt");

            string[] linije = File.ReadAllLines(put);
            if (linije != null)
            {
                for (int i = 0; i < linije.Length; i++)
                {
                    string[] tmp = linije[i].Split('|');
                    if (tmp[0] == file)
                    {
                        return tmp[1];
                    }
                    i++;
                }
            }
            return string.Empty;
        }

        private void btn_FileSelect_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filePathUload = openFileDialog1.FileName;
                lab_FileSelect.Text = filePathUload;
                lab_FileSelect.ForeColor = Color.Black;
            }
            else
            {
                filePathUload = string.Empty;
                lab_FileSelect.Text = "\\\\";
            }

        }

        private void btn_Upload_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(filePathUload))
            {
                lab_FileSelect.Text = "No Path";
                lab_FileSelect.ForeColor = Color.Red;
            }
            else
            {
                byte[] ulaz = File.ReadAllBytes(filePathUload);                            
                string hesh = sha2.GetHesh(ref ulaz);
               /* byte[] izlaz = ks.Encript(ref ulaz);

                File.WriteAllBytes(@"C:\Users\Intel\Desktop\TestFolder\Enc.txt", izlaz);
                byte[] dec = ks.Decript(ref izlaz);

                File.WriteAllBytes(@"C:\Users\Intel\Desktop\TestFolder\Dec.txt", dec);*/

                switch (comboBox1.SelectedIndex)
                {
                    case 0: UploadXXTEA(ulaz, hesh, Path.GetFileName(filePathUload)); break;
                    case 1: UploadPCBC(ulaz, hesh, Path.GetFileName(filePathUload)); break;
                    case 2: UploadKnapsak(ulaz, hesh, Path.GetFileName(filePathUload)); break;
                    case 3: UploadSimSub(ulaz, hesh, Path.GetFileName(filePathUload)); break;
                }


            }

            GetFiles();

        }

        private void UploadSimSub(byte[] ulaz, string hesh, string filepath)
        {
            FileServerClient sc = new FileServerClient();
            
            
            String  ALFA = string.Empty;
            String Key = string.Empty;
            
            ALFA = txt_ALFA.Text;
            ALFA.Replace('|', ' ');

            Key = txt_SubKey.Text;
            Key.Replace('|', ' ');

            if(ALFA.Length != Key.Length)
            {
                MessageBox.Show("Alfabet treba da bude iste duzine ko Kljuc --> ALFA: " + ALFA.Length + " Key: " + Key.Length);
                return;
            }
            byte[] test = ASCIIEncoding.ASCII.GetBytes(ALFA);
            SimpleSub tmp = new SimpleSub(Convert.ToUInt64(test.Length), test, ASCIIEncoding.ASCII.GetBytes(Key));

            String put = Path.Combine(pathBase, userName + ".txt");

            string encData = filepath + "|SimSub";
            string stkey = ALFA +'|' + Key;
            encData = encData + "\n" + stkey + '\n';
            File.AppendAllText(put, encData);

            byte[] data = tmp.Encript(ref ulaz);

            StorageFileInfo sf = new StorageFileInfo();
            sf.Size = ulaz.Length;
            sf.VirtualPath = filepath;


            FileUpload f = new FileUpload();

            f.Data = data;
            f.Hesh = hesh;
            f.info = sf;

            sc.PutFile(f, userName, userPassword);
        }

        private bool DecriptSimSub(ref byte[] data, string hesh, string file)
        {
            bool tru = false;


            String ALFA = string.Empty;
            String Key = string.Empty;

            GetSimSubKey(ref ALFA, ref Key,file);
            byte[] test = ASCIIEncoding.ASCII.GetBytes(ALFA);
            SimpleSub tmp = new SimpleSub(Convert.ToUInt64(test.Length),test, ASCIIEncoding.ASCII.GetBytes(Key));


            byte[] dat = tmp.Decript(ref data);

            string h = sha2.GetHesh(ref dat);

            if (String.Equals(h, hesh))
            {
                tru = true;
            }
            data = dat;
            return tru;
        }

        private void GetSimSubKey(ref string ALFA, ref string key,string filePath)
        {
            String put = Path.Combine(pathBase, userName + ".txt");

            string[] linije = File.ReadAllLines(put);
            if (linije != null)
            {
                for (int i = 0; i < linije.Length; i++)
                {

                    if (linije[i].Split('|')[0] == filePath)
                    {
                        string[] tmp = linije[i + 1].Split('|');
                        ALFA = tmp[0];
                        key = tmp[1];
                        return;
                    }
                    i++;
                }
            }
        }

        private void UploadKnapsak(byte[] ulaz, string hesh, string filepath)
        {
            
           

            FileServerClient sc = new FileServerClient();
            Knapsak tmp = new Knapsak();
            UInt16[] PrKey = new UInt16[8];
            UInt16[] PuKey = new UInt16[8];
            UInt16 im = 0;
            UInt32 N = 0;

            tmp.GetKey(ref PuKey, ref PrKey, ref N, ref im);
            String put = Path.Combine(pathBase, userName + ".txt");
            string encData = filepath + "|Knapsak";
            string tmp1 = string.Empty;
            string tmp2 = string.Empty;

            for (int i = 0; i < 8;i++)
            {
                tmp1 += PuKey[i] + "|";
                tmp2 += PrKey[i] + "|";
            }

            string stkey = tmp1 + tmp2 + N + '|' + im;
            encData = encData + "\n" + stkey + '\n';
            File.AppendAllText(put, encData);

            byte[] data = tmp.Encript(ref ulaz);

            StorageFileInfo sf = new StorageFileInfo();
            sf.Size = ulaz.Length;
            sf.VirtualPath = filepath;


            FileUpload f = new FileUpload();

            f.Data = data;
            f.Hesh = hesh;
            f.info = sf;

            sc.PutFile(f, userName, userPassword);
        }

        private bool DecriptKnapsak(ref byte[] data, string hesh, string filepath)
        {
            bool tru = false;

            UInt16[] PrKey = new UInt16[8];
            UInt16[] PuKey = new UInt16[8];
            UInt16 im = 0;
            UInt64 N = 0;


            GetKnapsakKey(ref PuKey, ref PrKey, ref N, ref im,filepath);

            Knapsak tmp = new Knapsak();


            byte[] dat = tmp.Decript(ref data);

            string h = sha2.GetHesh(ref dat);

            if (String.Equals(h, hesh))
            {
                tru = true;
            }
            data = dat;
            return tru;
        }

        private void GetKnapsakKey(ref ushort[] puKey, ref ushort[] prKey, ref ulong n, ref ushort im, string filePath)
        {
            String put = Path.Combine(pathBase, userName + ".txt");

            string[] linije = File.ReadAllLines(put);
            if (linije != null)
            {
                for (int i = 0; i < linije.Length; i++)
                {

                    if (linije[i].Split('|')[0] == filePath)
                    {
                        string[] tmp = linije[i + 1].Split('|');
                        for (int j = 0; j < 8; j++)
                        {
                            puKey[j] = Convert.ToUInt16(tmp[j]); 
                        }
                        for (int j = 0; j < 8; j++)
                        {
                            prKey[j] = Convert.ToUInt16(tmp[8+j]);
                        }
                        n = Convert.ToUInt32(tmp[16]);
                        im = Convert.ToUInt16(tmp[17]);
                        return;
                    }
                    i++;
                }
            }
        }

        private void UploadPCBC(byte[] ulaz, string hesh, string filepath)
        {
            uint[] key = new uint[4];
            key[0] = Convert.ToUInt32((numb_XXTEA_1.Value));
            key[1] = Convert.ToUInt32((numb_XXTEA_2.Value));
            key[2] = Convert.ToUInt32((numb_XXTEA_3.Value));
            key[3] = Convert.ToUInt32((numb_XXTEA_4.Value));
            //komentar

            uint[] a = GenInitial(txt_PCPInitial.Text);

            FileServerClient sc = new FileServerClient();
            PCBC tmp = new PCBC(ref a,key);

            int n = 8 - ulaz.Length%8;
            List<byte> data = ulaz.ToList();


            for (int i = 0; i < n; i++)
            {
                data.Add(0);
            }

            ulaz = data.ToArray();

            hesh = sha2.GetHesh(ref ulaz);

            tmp.Encript(ref ulaz);

            String put = Path.Combine(pathBase, userName + ".txt");
            string encData = filepath + "|PCBC";
            string stkey = key[0] + "|" + key[1] + "|" + key[2] + "|" + key[3] + '|' + txt_PCPInitial.Text;
            encData = encData + "\n" + stkey + '\n';
            File.AppendAllText(put, encData);

            StorageFileInfo sf = new StorageFileInfo();
            sf.Size = ulaz.Length;
            sf.VirtualPath = filepath;


            FileUpload f = new FileUpload();

            f.Data = ulaz;
            f.Hesh = hesh;
            f.info = sf;

            sc.PutFile(f, userName, userPassword);
        }

        private bool DecriptPCBC(ref byte[] data, string hesh, string filepath)
        {
            bool tru = false;
            uint[] key = new uint[4];
            uint[] init = new uint[2];

            GetPCBCKey(ref key,ref init, filepath);


            PCBC tmp = new PCBC(ref init, key);

            tmp.Decript(ref data);

            string h = sha2.GetHesh(ref data);

            if (String.Equals(h, hesh))
            {
                tru = true;
            }

            return tru;

        }

        private void GetPCBCKey(ref uint[] key, ref uint[] init, string filePath)
        {
            String put = Path.Combine(pathBase, userName + ".txt");

            string[] linije = File.ReadAllLines(put);
            if (linije != null)
            {
                for (int i = 0; i < linije.Length; i++)
                {

                    if (linije[i].Split('|')[0] == filePath)
                    {
                        string[] tmp = linije[i + 1].Split('|');
                        key[0] = Convert.ToUInt32(tmp[0]);
                        key[1] = Convert.ToUInt32(tmp[1]);
                        key[2] = Convert.ToUInt32(tmp[2]);
                        key[3] = Convert.ToUInt32(tmp[3]);

                        init = GenInitial(tmp[4]);

                        return;
                    }
                    i++;
                }
            }
        }

        private uint[] GenInitial(string text)
        {
            uint[] rez = new uint[2];
            rez[0] = 10;
            rez[1] = 10;
            char[] str = text.ToArray();
            UInt32 i = 0;
            foreach(char c in str)
            {
                rez[0] += Convert.ToUInt32(c);
                rez[1] += Convert.ToUInt32(c) + i++;
            }

            return rez;
        }

        private void UploadXXTEA(byte[] ulaz,string hesh,string filepath)
        {
            uint[] key = new uint[4];
            key[0] = Convert.ToUInt32((numb_XXTEA_1.Value));
            key[1] = Convert.ToUInt32((numb_XXTEA_2.Value));
            key[2] = Convert.ToUInt32((numb_XXTEA_3.Value));
            key[3] = Convert.ToUInt32((numb_XXTEA_4.Value));

            FileServerClient sc = new FileServerClient();
            XXTEA tmp = new XXTEA(key);

            String put = Path.Combine(pathBase,userName+".txt");
            string encData = filepath+"|XXTEA";
            string stkey = key[0] + "|" + key[1] + "|" + key[2] + "|" + key[3];
            encData = encData + "\n" + stkey + '\n';
            File.AppendAllText(put,encData);

           tmp.Encript(ref ulaz);

            StorageFileInfo sf = new StorageFileInfo();
            sf.Size = ulaz.Length;
            sf.VirtualPath = filepath;
            

            FileUpload f = new FileUpload();

            f.Data = ulaz;
            f.Hesh = hesh;
            f.info = sf;

            sc.PutFile(f, userName, userPassword);

        }

        private bool DecriptXXTEA(ref byte[] data, string hesh, string filepath)
        {
            bool tru = false;
            uint[] key = new uint[4];

            GetXXTEAKey(ref key,filepath);


            XXTEA tmp = new XXTEA(key);

            tmp.Decript(ref data);

            string h = sha2.GetHesh(ref data);

            if(String.Equals(h,hesh))
            {
                tru = true;
            }

            return tru;
            
        }

        private void GetXXTEAKey(ref uint[] key,string filePath)
        {
            String put = Path.Combine(pathBase,userName+".txt");

            string[] linije = File.ReadAllLines(put);
            if (linije != null)
            {
                for (int i = 0; i < linije.Length; i++)
                {

                    if(linije[i].Split('|')[0] == filePath)
                    {
                        string[] tmp = linije[i + 1].Split('|');
                        key[0] = Convert.ToUInt32(tmp[0]);
                        key[1] = Convert.ToUInt32(tmp[1]);
                        key[2] = Convert.ToUInt32(tmp[2]);
                        key[3] = Convert.ToUInt32(tmp[3]);

                        return;
                    }
                    i++;
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            numb_XXTEA_1.ReadOnly = true;
            numb_XXTEA_2.ReadOnly = true;
            numb_XXTEA_3.ReadOnly = true;
            numb_XXTEA_4.ReadOnly = true;
            txt_PCPInitial.ReadOnly = true;
            txt_ALFA.ReadOnly = true;
            txt_SubKey.ReadOnly = true; 

            if (comboBox1.SelectedIndex == 0 || comboBox1.SelectedIndex == 1)
            {
                numb_XXTEA_1.ReadOnly = false;
                numb_XXTEA_2.ReadOnly = false;
                numb_XXTEA_3.ReadOnly = false;
                numb_XXTEA_4.ReadOnly = false;

            }
            if(comboBox1.SelectedIndex == 1)
            {
                txt_PCPInitial.ReadOnly = false;
            }
            if(comboBox1.SelectedIndex == 3)
            {
                txt_ALFA.ReadOnly = false;
                txt_SubKey.ReadOnly = false;
            }
        }
    }
}

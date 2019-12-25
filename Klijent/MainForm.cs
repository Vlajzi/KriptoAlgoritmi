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

        String pathTmp = @"C:\Users\Intel\Desktop\TestFolder";
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

        }



        private void GetFiles()
        {
            List<StorageFileInfo> putanje = new List<StorageFileInfo>();


            string[] paths = Directory.GetFiles(pathTmp);

            foreach(string s in paths)
            {
                StorageFileInfo inf = new StorageFileInfo();
                var stmp = new FileInfo(s);

                inf.Size = stmp.Length;               
                inf.VirtualPath = stmp.Name;

                putanje.Add(inf);
            }

            listBox1.DataSource = putanje;


        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.listBox1.IndexFromPoint(e.Location);
            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                //getFile the sav the open

                string file = ((StorageFileInfo)listBox1.Items[index]).VirtualPath;
                //textBox1.Text = file;
                System.Diagnostics.Process.Start(pathTmp+"\\"+file);//tmp path
            }
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
                    case 1: UploadXXTEA(ulaz, hesh, Path.GetFileName(filePathUload)); break;
                    case 2: UploadXXTEA(ulaz, hesh, Path.GetFileName(filePathUload)); break;
                    case 3: UploadXXTEA(ulaz, hesh, Path.GetFileName(filePathUload)); break;
                }


            }
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            numb_XXTEA_1.ReadOnly = true;
            numb_XXTEA_2.ReadOnly = true;
            numb_XXTEA_3.ReadOnly = true;
            numb_XXTEA_4.ReadOnly = true;
            txt_PCPInitial.ReadOnly = true;

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
        }
    }
}

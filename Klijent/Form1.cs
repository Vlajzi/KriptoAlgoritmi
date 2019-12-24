using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klijent
{
    public partial class Form1 : Form
    {
       XXTEA t;
        PCBC p;
        SHA2 s;

        public Form1()
        {
            UInt32[] key = new UInt32[4];
            key[0] = 1;
            key[1] = 2;
            key[2] = 3;
            key[3] = 4;

            UInt32[] initial = { 1232322, 4132244 };


            InitializeComponent();
            t = new XXTEA(key);
            p = new PCBC(ref initial, key);
            s = new SHA2();
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

            textBox1.Text = s.GetHesh(ref test);//Treba svida butu za byte


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

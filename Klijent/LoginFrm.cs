using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyCloudStore;
namespace Klijent
{
    public partial class LoginFrm : Form
    {
        public LoginFrm()
        {
            InitializeComponent();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            string username = txtBox_UserName.Text;
            string password = txtBox_Password.Text;
            lab_Error.Visible = false;


            LoginChk loginChk = new LoginChk();
            if(loginChk.Login(username,password)) //prover logina
            {
                MainForm f = new MainForm(this);
                f.userName = username;
                f.userPassword = password;
                f.Show();
                this.Hide();    
            }
            else
            {
                lab_Error.Visible = true;
            }
        }

        private void LoginFrm_Load(object sender, EventArgs e)
        {

        }
    }
}

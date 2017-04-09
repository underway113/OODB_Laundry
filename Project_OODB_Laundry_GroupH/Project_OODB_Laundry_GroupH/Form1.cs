using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_OODB_Laundry_GroupH
{
    public partial class FormLogin : Form
    {
        DatabaseLaundryEntities1 db = new DatabaseLaundryEntities1();
        public FormLogin()
        {
            InitializeComponent();
            init_state_login();
            this.ActiveControl = textBoxEmail;
        }

        public void init_state_login()
        {
            textBoxEmail.Text = "";
            textBoxPassword.Text = "";
        }

        private static string _roleGlobal="";
        private static string _passwordGlobal = "";
        private static string _emailGlobal = "";
        private static string _userIDGlobal = "";
        public static string roleGlobal
        {
            get
            {
                return _roleGlobal;
            }
        }
        public static string passwordGlobal
        {
            get
            {
                return _passwordGlobal;
            }
            set
            {
                _passwordGlobal = value;
            }
        }
        public static string emailGlobal
        {
            get
            {
                return _emailGlobal;
            }
        }
        public static string userIDGlobal
        {
            get
            {
                return _userIDGlobal;
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string email = textBoxEmail.Text;
            string pass = textBoxPassword.Text;
            var user = (from x in db.Users
                        where x.UserEmail == email && x.UserPassword == pass
                        select x).FirstOrDefault();
            
            if (textBoxEmail.Text == "")
            {
                MessageBox.Show("Email Must Be Filled!");
            }
            else if(textBoxPassword.Text == "")
            {
                MessageBox.Show("Password Must Be Filled!");
            }
            else {
                if(user == null)
                {
                    MessageBox.Show("No User Found!");
                }
                else
                {
                    _roleGlobal = user.RoleName;
                    _emailGlobal = user.UserEmail;
                    _passwordGlobal = user.UserPassword;
                    _userIDGlobal = user.UserID;
                    Form form = new FormHome();
                    this.Visible = false;
                    form.Visible = true;
                }
            }
        }

        private void linkLabelSignup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form form = new FormRegister();
            this.Visible = false;
            form.Visible = true;
        }

        private void textBoxPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonLogin_Click(this, new EventArgs());
            }
        }
    }
}

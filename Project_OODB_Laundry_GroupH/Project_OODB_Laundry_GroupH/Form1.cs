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
        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
           
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if(textBoxEmail.Text == "")
            {
                MessageBox.Show("Email Must Be Filled!");
            }
            else if(textBoxPassword.Text == "")
            {
                MessageBox.Show("Password Must Be Filled!");
            }
        }

        private void linkLabelSignup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form form = new FormRegister();
            this.Visible = false;
            form.Visible = true;
        }
    }
}

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
    public partial class FormChangePassword : Form
    {
        public FormChangePassword()
        {
            InitializeComponent();
            init_state_ChangePassword();
        }

        public void init_state_ChangePassword()
        {
            textBoxEmail.Text = "";
            textBoxOldPassword.Text = "";
            textBoxNewPassword.Text = "";
            textBoxConfirmPassword.Text = "";
            this.ActiveControl = textBoxEmail;
        }

        private void buttonChangePassword_Click(object sender, EventArgs e)
        {
            if(textBoxEmail.Text == "")
            {
                MessageBox.Show("Email must be filled");
            }
            //BELUM >> If Email is not the same as the user’s email, then show error message “Email is wrong”.
            else if(textBoxOldPassword.Text == "")
            {
                MessageBox.Show("Old Password must be filled");
            }
            //BELUM >> If Old Password is not the same as the user’s password, then show error message “Old Password is wrong”.
            else if(textBoxNewPassword.Text == "")
            {
                MessageBox.Show("New Password must be filled");
            }
            //BELUM >> If Confirm Password is empty, then show error message “Confirm Password must be filled”.
            else if (textBoxConfirmPassword.Text == "")
            {
                MessageBox.Show("Confirm Password must be filled");
            }
            else if (textBoxNewPassword.Text != textBoxConfirmPassword.Text)
            {
                MessageBox.Show("New Password and Confirm Password must be the same");
            }

        }
    }
}

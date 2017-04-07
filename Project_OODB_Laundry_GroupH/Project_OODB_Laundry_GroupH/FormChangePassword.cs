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
        DatabaseLaundryEntities1 db = new DatabaseLaundryEntities1();
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
            if (textBoxEmail.Text == "")
            {
                MessageBox.Show("Email must be filled");
            }
            else if (textBoxEmail.Text != FormLogin.emailGlobal)
            {
                MessageBox.Show("Email is wrong");
            }
            else if (textBoxOldPassword.Text == "")
            {
                MessageBox.Show("Old Password must be filled");
            }
            else if (textBoxOldPassword.Text != FormLogin.passwordGlobal)
            {
                MessageBox.Show("Old Password is wrong");
            }
            else if (textBoxNewPassword.Text == "")
            {
                MessageBox.Show("New Password must be filled");
            }
            else if (textBoxConfirmPassword.Text == "")
            {
                MessageBox.Show("Confirm Password must be filled");
            }
            else if (textBoxNewPassword.Text != textBoxConfirmPassword.Text)
            {
                MessageBox.Show("New Password and Confirm Password must be the same");
            }
            else
            {
                var user = (from x in db.Users
                            where x.UserEmail == FormLogin.emailGlobal && x.UserPassword == FormLogin.passwordGlobal
                            select x).FirstOrDefault();
                user.UserPassword = textBoxNewPassword.Text;
                db.SaveChanges();
                FormLogin.passwordGlobal = textBoxNewPassword.Text;
                MessageBox.Show("Your New Password has been updated");
                this.Visible = false;
            }
        }
    }
}

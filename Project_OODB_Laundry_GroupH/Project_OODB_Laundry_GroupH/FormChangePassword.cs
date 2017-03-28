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
        }

        private void buttonChangePassword_Click(object sender, EventArgs e)
        {

        }
    }
}

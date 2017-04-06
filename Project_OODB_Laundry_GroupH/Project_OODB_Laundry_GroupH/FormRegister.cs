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
    public partial class FormRegister : Form
    {
        public FormRegister()
        {
            InitializeComponent();
            init_state_register();
        }

        public void init_state_register()
        {
            textBoxUsername.Text = "";
            textBoxPassword.Text = "";
            textBoxConfirmPassword.Text = "";
            textBoxEmail.Text = "";
            textBoxPhoneNumber.Text = "";
            richTextBoxAddress.Text = "";
           
        }

        private void FormRegister_Load(object sender, EventArgs e)
        {

        }

        private void linkLabelSignIn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form form = new FormLogin();
            this.Visible = false;
            form.Visible = true;
        }
        public Boolean validateEmail(String email)
        {
            

            int flagAt = 0, flagDot = 0;
            foreach (char c in email)
            {
                if (c == '@')
                {
                    flagAt++;
                }
                if (c == '.')
                {
                    flagDot = 1;
                }
            }
            if(flagAt > 1 || flagDot!=1)
            {
                return false;
            }
            if (email.IndexOf('@')==0 || email.IndexOf('@')==email.Length-1)
            {
                return false;
            }
            if (email.IndexOf('@') - email.IndexOf('.') == 1 || email.IndexOf('@') - email.IndexOf('.') == -1)
            {
                return false;
            }
            return true;
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            int flagUsernameAlphabet = 0;
            int flagNumberPhoneNumeric = 0;
            String flagAddress = "";
            foreach (char c in textBoxUsername.Text)
            {
                if (!Char.IsLetter(c))
                    flagUsernameAlphabet = 1;
            }
            foreach (char c in textBoxPhoneNumber.Text)
            {
                if (!Char.IsDigit(c))
                    flagNumberPhoneNumeric = 1;
            }


            if (textBoxUsername.Text == "")
            {
                MessageBox.Show("Username Must be Filled");
            }
            else if(flagUsernameAlphabet == 1)
            {
                MessageBox.Show("Username Must be alphabet");
            }
            else if (textBoxPassword.Text == "")
            {
                MessageBox.Show("Password Must be Filled");
            }
            else if (textBoxConfirmPassword.Text == "")
            {
                MessageBox.Show("Confirm Password Must be Filled");
            }
            else if (textBoxPassword.Text != textBoxConfirmPassword.Text)
            {
                MessageBox.Show("Password and Confirm Password must be the same");
            }
            else if (textBoxEmail.Text == "")
            {
                MessageBox.Show("Email Must be Filled");
            }
            else if (validateEmail(textBoxEmail.Text) == false)
            {
                MessageBox.Show("Email is not valid");
            }
            else if (textBoxPhoneNumber.Text == "")
            {
                MessageBox.Show("Phone Number Must be Filled");
            }
            else if (flagNumberPhoneNumeric == 1)
            {
                MessageBox.Show("Phone Number must be numeric");
            }
            else if (richTextBoxAddress.Text == "")
            {
                MessageBox.Show("Address Must be Filled");
            }
            else if (richTextBoxAddress.Text.Length<6 ||richTextBoxAddress.Text.ToLower().Substring(richTextBoxAddress.Text.Length-6) != "street")
            {
                MessageBox.Show("Address Must be Ends with 'street'");
            }

        }
    }
}

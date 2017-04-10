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
    public partial class FormManageUser : Form
    {
        DatabaseLaundryEntities1 db = new DatabaseLaundryEntities1();
        public FormManageUser()
        {
            InitializeComponent();
            init_state_ManageUser();
            loadData();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        public void loadData()
        {
            dataGridView1.DataSource = (from x in db.Users select new { x.UserID, x.UserName, x.UserPassword, x.UserEmail, x.UserAddress, x.UserPhoneNumber, x.RoleName }).ToList();
        }
        public void init_state_ManageUser()
        {
            textBoxUserID.Text = "";
            textBoxUsername.Text = "";
            textBoxPassword.Text = "";
            textBoxEmail.Text = "";
            richTextBoxAddress.Text = "";
            textBoxPhoneNumber.Text = "";
            comboBoxRolename.Text = "";

            textBoxUserID.Enabled = false;
            textBoxUsername.Enabled = false;
            textBoxPassword.Enabled = false;
            textBoxEmail.Enabled = false;
            richTextBoxAddress.Enabled = false;
            textBoxPhoneNumber.Enabled = false;
            comboBoxRolename.Enabled = false;

            buttonInsert.Enabled = true;
            buttonUpdate.Enabled = true;
            buttonDelete.Enabled = true;

            buttonSave.Enabled = false;
            buttonCancel.Enabled = false;
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                textBoxUserID.Text = dataGridView1.SelectedRows[0].Cells["UserID"].Value.ToString();
                textBoxUsername.Text = dataGridView1.SelectedRows[0].Cells["UserName"].Value.ToString();
                textBoxPassword.Text = dataGridView1.SelectedRows[0].Cells["UserPassword"].Value.ToString();
                textBoxEmail.Text = dataGridView1.SelectedRows[0].Cells["UserEmail"].Value.ToString();
                richTextBoxAddress.Text = dataGridView1.SelectedRows[0].Cells["UserAddress"].Value.ToString();
                textBoxPhoneNumber.Text = dataGridView1.SelectedRows[0].Cells["UserPhoneNumber"].Value.ToString();
                if (dataGridView1.SelectedRows[0].Cells["RoleName"].Value.ToString() == "Admin")
                {
                    comboBoxRolename.Text = "Admin";
                }
                else if (dataGridView1.SelectedRows[0].Cells["RoleName"].Value.ToString() == "Member")
                {
                    comboBoxRolename.Text = "Member";
                }
            }
        }
        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView1.ClearSelection();
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
            if (flagAt > 1 || flagDot != 1)
            {
                return false;
            }
            if (email.IndexOf('@') == 0 || email.IndexOf('@') == email.Length - 1)
            {
                return false;
            }
            if (email.IndexOf('@') - email.IndexOf('.') == 1 || email.IndexOf('@') - email.IndexOf('.') == -1)
            {
                return false;
            }
            return true;
        }
        public static bool IsAllLetters(string s)
        {
            foreach (char c in s)
            {
                if (!Char.IsLetter(c))
                    return false;
            }
            return true;
        }
        public static bool IsAllDigits(string s)
        {
            foreach (char c in s)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
        }

        string newId = "";
        int flagInsert = 0;
        int flagUpdate = 0;
        private void buttonInsert_Click(object sender, EventArgs e)
        {
            string lastRow = (from x in db.Users
                              orderby x.UserID descending
                              select x.UserID).FirstOrDefault();
            if(lastRow == null)
            {
                newId = "US001";
            }
            else
            {
                int id = Int32.Parse(lastRow.Substring(lastRow.Length - 3)) + 1;
                if (id < 10)
                {
                    newId = "US00" + id;
                }
                else if (id < 100)
                {
                    newId = "US0" + id;
                }
                else
                {
                    newId = "US" + id;
                }
            }
           
            textBoxUserID.Enabled = false;
            textBoxUsername.Enabled = true;
            textBoxPassword.Enabled = true;
            textBoxEmail.Enabled = true;
            richTextBoxAddress.Enabled = true;
            textBoxPhoneNumber.Enabled = true;
            comboBoxRolename.Enabled = true;

            textBoxUserID.Text = newId;
            textBoxUsername.Text = "";
            textBoxPassword.Text = "";
            textBoxEmail.Text = "";
            richTextBoxAddress.Text = "";
            textBoxPhoneNumber.Text = "";
            comboBoxRolename.Text = "";

            buttonInsert.Enabled = false;
            buttonUpdate.Enabled = false;
            buttonDelete.Enabled = false;

            buttonSave.Enabled = true;
            buttonCancel.Enabled = true;

            flagInsert = 1;
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (textBoxUserID.Text == "")
            {
                MessageBox.Show("Select User First");
            }
            else
            {
                textBoxUserID.Enabled = false;
                textBoxUsername.Enabled = true;
                textBoxPassword.Enabled = true;
                textBoxEmail.Enabled = true;
                richTextBoxAddress.Enabled = true;
                textBoxPhoneNumber.Enabled = true;
                comboBoxRolename.Enabled = true;

                buttonInsert.Enabled = false;
                buttonUpdate.Enabled = false;
                buttonDelete.Enabled = false;

                buttonSave.Enabled = true;
                buttonCancel.Enabled = true;
                flagUpdate = 1;
            }

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("Select User First");
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure want to delete this user?", "Confirmation Message", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    var user = (from x in db.Users where x.UserID == textBoxUserID.Text select x).FirstOrDefault();
                    db.Users.Remove(user);
                    db.SaveChanges();
                    MessageBox.Show("Succesfully delete a user");
                }
                else if (dialogResult == DialogResult.No)
                {
                }
                loadData();
                init_state_ManageUser();
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (textBoxUsername.Text == "")
            {
                MessageBox.Show("Username Must be Filled");
            }
            else if (!IsAllLetters(textBoxUsername.Text))
            {
                MessageBox.Show("Username Must be alphabet");
            }
            else if (textBoxPassword.Text == "")
            {
                MessageBox.Show("Password Must be Filled");
            }
            else if (textBoxEmail.Text == "")
            {
                MessageBox.Show("Email Must be Filled");
            }
            else if (validateEmail(textBoxEmail.Text) == false)
            {
                MessageBox.Show("Email is not valid");
            }
            else if (richTextBoxAddress.Text == "")
            {
                MessageBox.Show("Address Must be Filled");
            }
            else if (richTextBoxAddress.Text.Length < 6 || richTextBoxAddress.Text.ToLower().Substring(richTextBoxAddress.Text.Length - 6) != "street")
            {
                MessageBox.Show("Address Must be Ends with 'street'");
            }
            else if (textBoxPhoneNumber.Text == "")
            {
                MessageBox.Show("Phone Number Must be Filled");
            }
            else if (!IsAllDigits(textBoxPhoneNumber.Text))
            {
                MessageBox.Show("Phone Number must be numeric");
            }
            else if (comboBoxRolename.Text == "")
            {
                MessageBox.Show("Please Choose the Role");
            }
            else
            {
                if (flagInsert == 1)
                {
                    Users newUser = new Users();
                    newUser.UserID = newId;
                    newUser.UserName = textBoxUsername.Text;
                    newUser.UserPassword = textBoxPassword.Text;
                    newUser.UserEmail = textBoxEmail.Text;
                    newUser.UserAddress = richTextBoxAddress.Text;
                    newUser.UserPhoneNumber = textBoxPhoneNumber.Text;
                    newUser.RoleName = comboBoxRolename.Text;

                    db.Users.Add(newUser);
                    flagInsert = 0;
                    db.SaveChanges();
                }
                else if (flagUpdate == 1)
                {
                    var users = (from x in db.Users
                                     where x.UserID == textBoxUserID.Text
                                     select x).FirstOrDefault();
                    users.UserName = textBoxUsername.Text;
                    users.UserPassword = textBoxPassword.Text;
                    users.UserEmail = textBoxEmail.Text;
                    users.UserAddress = richTextBoxAddress.Text;
                    users.UserPhoneNumber = textBoxPhoneNumber.Text;
                    users.RoleName = comboBoxRolename.Text;

                    flagUpdate = 0;
                    db.SaveChanges();
                }
                MessageBox.Show("User has been inserted/updated!");
                loadData();
                init_state_ManageUser();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            flagInsert = 0;
            flagUpdate = 0;
            init_state_ManageUser();
            loadData();
        }

        private void textBoxUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonSave_Click(this, new EventArgs());
            }
        }

        private void textBoxPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonSave_Click(this, new EventArgs());
            }
        }

        private void textBoxEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonSave_Click(this, new EventArgs());
            }
        }

        private void richTextBoxAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonSave_Click(this, new EventArgs());
            }
        }

        private void textBoxPhoneNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonSave_Click(this, new EventArgs());
            }
        }
    }
}

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
            dataGridView1.DataSource = (from x in db.Users select x).ToList();
            dataGridView1.DefaultCellStyle.SelectionBackColor = dataGridView1.DefaultCellStyle.BackColor;
            dataGridView1.DefaultCellStyle.SelectionForeColor = dataGridView1.DefaultCellStyle.ForeColor;
        }
        public void init_state_ManageUser()
        {
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
            textBoxUserID.Text = dataGridView1.SelectedRows[0].Cells["UserID"].Value.ToString();
            textBoxUsername.Text = dataGridView1.SelectedRows[0].Cells["UserName"].Value.ToString();
            textBoxPassword.Text = dataGridView1.SelectedRows[0].Cells["UserPassword"].Value.ToString();
            textBoxEmail.Text = dataGridView1.SelectedRows[0].Cells["UserEmail"].Value.ToString();
            richTextBoxAddress.Text = dataGridView1.SelectedRows[0].Cells["UserAddress"].Value.ToString();
            textBoxPhoneNumber.Text = dataGridView1.SelectedRows[0].Cells["UserPhoneNumber"].Value.ToString();
            if (dataGridView1.SelectedRows[0].Cells["RoleName"].Value.ToString()=="Admin")
            {
                comboBoxRolename.Text = "Admin";
            }
            else if (dataGridView1.SelectedRows[0].Cells["RoleName"].Value.ToString() == "Member")
            {
                comboBoxRolename.Text = "Member";
            }
        }

        int flagInsert = 0;
        int flagUpdate = 0;
        private void buttonInsert_Click(object sender, EventArgs e)
        {
            //Belum Auto Generate UserID
            textBoxUserID.Enabled = false;
            textBoxUsername.Enabled = true;
            textBoxPassword.Enabled = true;
            textBoxEmail.Enabled = true;
            richTextBoxAddress.Enabled = true;
            textBoxPhoneNumber.Enabled = true;
            comboBoxRolename.Enabled = true;

            textBoxUserID.Text = "";
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
            if (textBoxUserID.Text == "")
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
            
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            init_state_ManageUser();
            loadData();
        }
    }
}

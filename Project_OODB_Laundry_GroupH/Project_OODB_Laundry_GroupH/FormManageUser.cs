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
        public FormManageUser()
        {
            InitializeComponent();
            init_state_ManageUser();
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

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void FormManageUser_Load(object sender, EventArgs e)
        {

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            init_state_ManageUser();
        }
    }
}

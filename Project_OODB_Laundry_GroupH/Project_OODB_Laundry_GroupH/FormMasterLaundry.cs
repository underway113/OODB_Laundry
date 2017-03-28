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
    public partial class FormMasterLaundry : Form
    {
        public FormMasterLaundry()
        {
            InitializeComponent();
            init_state_MasterLaundryForm();
        }

        public void init_state_MasterLaundryForm()
        {
            textBoxLaundryID.Text = "";
            textBoxLaundryName.Text = "";
            textBoxPrice.Text = "";

            textBoxLaundryID.Enabled = false;
            textBoxLaundryName.Enabled = false;
            textBoxPrice.Enabled = false;

            buttonInsert.Enabled = true;
            buttonUpdate.Enabled = true;
            buttonDelete.Enabled = true;

            buttonSave.Enabled = false;
            buttonCancel.Enabled = false;
        }

        private void FormMasterLaundry_Load(object sender, EventArgs e)
        {

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            init_state_MasterLaundryForm();

        }
    }
}

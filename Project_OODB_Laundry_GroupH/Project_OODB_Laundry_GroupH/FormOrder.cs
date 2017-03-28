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
    public partial class FormOrder : Form
    {
        public FormOrder()
        {
            InitializeComponent();
            init_state_order();
        }

        public void init_state_order()
        {
            textBoxTransactionID.Enabled = false;
            textBoxUserID.Enabled = false;
            textBoxLaundryID.Enabled = false;
            textBoxLaundryName.Enabled = false;
            textBoxPrice.Enabled = false;
            textBoxPrice.Enabled = false;
            numericUpDownQuantityListLaundry.Enabled = true;
            textBoxProductID.Enabled = false;
            textBoxQuantityCart.Enabled = false;
            textBoxGrandTotal.Enabled = false;

            
        }

        private void FormOrder_Load(object sender, EventArgs e)
        {

        }
    }
}

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
    public partial class FormViewTransaction : Form
    {
        public FormViewTransaction()
        {
            InitializeComponent();
            init_state_ViewTransaction();
        }

        public void init_state_ViewTransaction()
        {
            textBoxTotalQuantity.Enabled = false;
            textBoxGrandTotal.Enabled = false;
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FormViewTransaction_Load(object sender, EventArgs e)
        {

        }
    }
}

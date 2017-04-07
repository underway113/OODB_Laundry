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
        DatabaseLaundryEntities1 db = new DatabaseLaundryEntities1();
        public FormViewTransaction()
        {
            InitializeComponent();
            init_state_ViewTransaction();
            loadData();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        public void loadData()
        {
            if(FormLogin.roleGlobal == "Admin") { 
                dataGridView1.DataSource = (from x in db.HeaderTransaction select new { x.TransactionID, x.UserID, x.Status }).ToList();
            }
            else if (FormLogin.roleGlobal == "Member")
            {
                dataGridView1.DataSource = (from x in db.HeaderTransaction where x.UserID == FormLogin.userIDGlobal select new { x.TransactionID, x.Status }).ToList();
              
            }
            dataGridView1.DefaultCellStyle.SelectionBackColor = dataGridView1.DefaultCellStyle.BackColor;
            dataGridView1.DefaultCellStyle.SelectionForeColor = dataGridView1.DefaultCellStyle.ForeColor;
            dataGridView2.DefaultCellStyle.SelectionBackColor = dataGridView1.DefaultCellStyle.BackColor;
            dataGridView2.DefaultCellStyle.SelectionForeColor = dataGridView1.DefaultCellStyle.ForeColor;
        }
        public void init_state_ViewTransaction()
        {
            textBoxTotalQuantity.Enabled = false;
            textBoxGrandTotal.Enabled = false;
            if (FormLogin.roleGlobal == "Admin")
            {
                buttonUpdateStatus.Visible = true;
            }
            else if (FormLogin.roleGlobal == "Member")
            {
                buttonUpdateStatus.Visible = false;
            }
        }
        
        private void buttonUpdateStatus_Click(object sender, EventArgs e)
        {

        }
    }
}

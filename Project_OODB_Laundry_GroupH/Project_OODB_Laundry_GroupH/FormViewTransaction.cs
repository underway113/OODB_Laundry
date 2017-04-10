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
            dataGridView2.DataSource = null;
        }
        public void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (dataGridView1.DataSource != null)
                {
                    string selected = dataGridView1.SelectedRows[0].Cells["TransactionID"].Value.ToString();
                    var query = (from dt in db.DetailTransaction 
                                 join p in db.PriceList on dt.ProductID equals p.ProductID
                                 where selected == dt.TransactionID
                                 select new { p.ProductName, dt.Quantity, dt.Price }).ToList();
                    dataGridView2.DataSource = query;
                    int quantityTotal = 0;
                    int grandTotal = 0;
                    for (int i = 0; i < query.Count(); i++)
                    {
                        quantityTotal += query[i].Quantity.Value;
                        grandTotal += query[i].Price.Value;
                    }
                    textBoxTotalQuantity.Text = quantityTotal.ToString();
                    textBoxGrandTotal.Text = grandTotal.ToString();
                }
            }
        }
        public void init_state_ViewTransaction()
        {
            textBoxTotalQuantity.Enabled = false;
            textBoxGrandTotal.Enabled = false;
            dataGridView2.Enabled = false;
            textBoxTotalQuantity.Text = "";
            textBoxGrandTotal.Text = "";
            if (FormLogin.roleGlobal == "Admin")
            {
                buttonUpdateStatus.Visible = true;
            }
            else if (FormLogin.roleGlobal == "Member")
            {
                buttonUpdateStatus.Visible = false;
            }
        }
        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView1.ClearSelection();
        }
        private void dataGridView2_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView2.ClearSelection();
        }
        private void buttonUpdateStatus_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("Please Choose Transaction Header Data First");
            }
            else
            {
                string selected = dataGridView1.SelectedRows[0].Cells["TransactionID"].Value.ToString();
                var checkStat = (from ht in db.HeaderTransaction where selected == ht.TransactionID select ht).FirstOrDefault();
                if(checkStat.Status == "Waiting")
                {
                    checkStat.Status = "Washing";
                    db.SaveChanges();
                }
                else if(checkStat.Status == "Washing")
                {
                    checkStat.Status = "Finished";
                    db.SaveChanges();
                }
                loadData();
                init_state_ViewTransaction();
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonUpdateStatus_Click(this, new EventArgs());
            }
        }
    }
}

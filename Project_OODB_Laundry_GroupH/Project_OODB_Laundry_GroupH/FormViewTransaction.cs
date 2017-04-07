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
        }
        public void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string selected = dataGridView1.SelectedRows[0].Cells["TransactionID"].Value.ToString();
            var query = (from u in db.Users
                         join ht in db.HeaderTransaction on u.UserID equals ht.UserID
                         join dt in db.DetailTransaction on ht.TransactionID equals dt.TransactionID
                         join p in db.PriceList on dt.ProductID equals p.ProductID
                         where selected == dt.TransactionID
                         select new { p.ProductName, dt.Quantity, dt.Price });
            dataGridView2.DataSource = query.ToList();

            textBoxTotalQuantity.Text = dataGridView2.SelectedRows[0].Cells["Quantity"].Value.ToString();
            textBoxGrandTotal.Text = dataGridView2.SelectedRows[0].Cells["Price"].Value.ToString();
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
            if (textBoxTotalQuantity.Text == "")
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
    }
}

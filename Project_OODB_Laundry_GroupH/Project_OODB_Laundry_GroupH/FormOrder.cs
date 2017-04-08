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
        DatabaseLaundryEntities1 db = new DatabaseLaundryEntities1();
        public FormOrder()
        {
            InitializeComponent();
            loadData();
            init_state_order();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        string newId = "";
        public void loadData()
        {
            dataGridView1.DataSource = (from x in db.PriceList select new { x.ProductID, x.ProductName, x.ProductPrice }).ToList();
            var query = (from ht in db.HeaderTransaction 
                         join dt in db.DetailTransaction on ht.TransactionID equals dt.TransactionID
                         join p in db.PriceList on dt.ProductID equals p.ProductID
                         where ht.UserID == textBoxUserID.Text && ht.Status == "Pending"
                         select new { dt.ProductID, p.ProductName, dt.Quantity, TotalPrice = dt.Price });
            dataGridView2.DataSource = query.ToList();

            string lastRow = (from ht in db.HeaderTransaction
                              orderby ht.TransactionID descending
                              select ht.TransactionID).First();
            int id = Int32.Parse(lastRow.Substring(lastRow.Length - 3)) + 1;

            if (id < 10)
            {
                newId = "HT00" + id;
            }
            else if (id < 100)
            {
                newId = "HT0" + id;
            }
            else
            {
                newId = "HT" + id;
            }
            textBoxTransactionID.Text = newId;
            
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
            textBoxUserID.Text = FormLogin.userIDGlobal;
            textBoxQuantityCart.Text = "0";
            textBoxGrandTotal.Text = "0";

        }
        public void refresh()
        {
            dataGridView1.DataSource = (from x in db.PriceList select new { x.ProductID, x.ProductName, x.ProductPrice }).ToList();
            var query = (from ht in db.HeaderTransaction
                         join dt in db.DetailTransaction on ht.TransactionID equals dt.TransactionID
                         join p in db.PriceList on dt.ProductID equals p.ProductID
                         where ht.UserID == textBoxUserID.Text && ht.Status == "Pending"
                         select new { dt.ProductID, p.ProductName, dt.Quantity, TotalPrice = dt.Price });
            dataGridView2.DataSource = query.ToList();
        }
        private void buttonAddToCart_Click(object sender, EventArgs e)
        {

            if (textBoxLaundryID.Text == "")
            {
                MessageBox.Show("Please Choose Laundry First");
            }
            else if (numericUpDownQuantityListLaundry.Text == "0")
            {
                MessageBox.Show("Please Fill the Quantity More Than 0");
            }
            //If user have pending transactions in HeaderTransaction table 
            //(status is “Pending”):
            
            else 
            {
                string selected = dataGridView1.SelectedRows[0].Cells["ProductID"].Value.ToString();
                var checkPending = (from ht in db.HeaderTransaction
                                    join dt in db.DetailTransaction on ht.TransactionID equals dt.TransactionID
                                          where ht.UserID == textBoxUserID.Text && ht.Status == "Pending" && selected == dt.ProductID
                                          select dt ).FirstOrDefault();
                
                if (checkPending != null)
                {
                    checkPending.Quantity += int.Parse(numericUpDownQuantityListLaundry.Text);
                    checkPending.Price = checkPending.Quantity*(int.Parse(textBoxPrice.Text));
                    db.SaveChanges();
                    refresh();
                }
                else
                {
                    //still error
                    HeaderTransaction newHeaderTrans = new HeaderTransaction();
                    DetailTransaction newDetailTrans = new DetailTransaction();
                    newHeaderTrans.TransactionID = newId;
                    newHeaderTrans.UserID = textBoxUserID.Text;
                    newHeaderTrans.Status = "Pending";
                    newDetailTrans.TransactionID = newId;
                    newDetailTrans.ProductID = textBoxLaundryID.Text;
                    newDetailTrans.Quantity = Int32.Parse(numericUpDownQuantityListLaundry.Text);
                    newDetailTrans.Price = Int32.Parse(numericUpDownQuantityListLaundry.Text)*Int32.Parse(textBoxPrice.Text);

                    db.HeaderTransaction.Add(newHeaderTrans);
                    db.DetailTransaction.Add(newDetailTrans);
                    db.SaveChanges();
                    refresh();
                }
               
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {

        }

        private void buttonCheckOut_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxLaundryID.Text = dataGridView1.SelectedRows[0].Cells["ProductID"].Value.ToString();
            textBoxLaundryName.Text = dataGridView1.SelectedRows[0].Cells["ProductName"].Value.ToString();
            textBoxPrice.Text = dataGridView1.SelectedRows[0].Cells["ProductPrice"].Value.ToString();
        }
    }
}

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
        }
        string newId = "";
        public void loadData()
        {
            dataGridView1.DataSource = (from x in db.PriceList select new { x.ProductID, x.ProductName, x.ProductPrice }).ToList();
            var query = (from ht in db.HeaderTransaction 
                         join dt in db.DetailTransaction on ht.TransactionID equals dt.TransactionID
                         join p in db.PriceList on dt.ProductID equals p.ProductID
                         where ht.UserID == textBoxUserID.Text && ht.Status == "Pending" && ht.TransactionID == textBoxTransactionID.Text
                         select new { dt.ProductID, p.ProductName, dt.Quantity, TotalPrice = dt.Price });
            dataGridView2.DataSource = query.ToList();

            string lastRow = (from ht in db.HeaderTransaction
                              orderby ht.TransactionID descending
                              select ht.TransactionID).FirstOrDefault();
            if(lastRow == null)
            {
                newId = "HT001";
            }
            else
            {
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
            textBoxLaundryID.Text = "";
            textBoxLaundryName.Text = "";
            textBoxPrice.Text = "";
            textBoxQuantityCart.Text = "0";
            textBoxGrandTotal.Text = "0";
            textBoxQuantityCart.Text = "0";
            textBoxGrandTotal.Text = "0";
            textBoxProductID.Text = "";
            numericUpDownQuantityListLaundry.Value = 0;
        }
        public void refresh()
        {
            dataGridView1.DataSource = (from x in db.PriceList select new { x.ProductID, x.ProductName, x.ProductPrice }).ToList();
            var query = (from ht in db.HeaderTransaction
                         join dt in db.DetailTransaction on ht.TransactionID equals dt.TransactionID
                         join p in db.PriceList on dt.ProductID equals p.ProductID
                         where ht.UserID == textBoxUserID.Text && ht.Status == "Pending" && ht.TransactionID == textBoxTransactionID.Text
                         select new { dt.ProductID, p.ProductName, dt.Quantity, TotalPrice = dt.Price });
            dataGridView2.DataSource = query.ToList(); 
            textBoxProductID.Text = "";
        }
        public void calculate()
        {
            var query = (from dt in db.DetailTransaction
                         join p in db.PriceList on dt.ProductID equals p.ProductID
                         where textBoxTransactionID.Text == dt.TransactionID
                         select new { dt.ProductID, p.ProductName, dt.Quantity, TotalPrice = dt.Price }).ToList();
            int quantityTotal = 0;
            int grandTotal = 0;
            for (int i = 0; i < query.Count(); i++)
            {
                quantityTotal += query[i].Quantity.Value;
                grandTotal += query[i].TotalPrice.Value;
            }
            textBoxQuantityCart.Text = quantityTotal.ToString();
            textBoxGrandTotal.Text = grandTotal.ToString();
        }
        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView1.ClearSelection();
        }
        private void dataGridView2_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView2.ClearSelection();
        }
        private void buttonAddToCart_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("Please Choose Laundry First");
            }
            else if (numericUpDownQuantityListLaundry.Text == "0")
            {
                MessageBox.Show("Please Fill the Quantity More Than 0");
            }
            else 
            {
                string selected = dataGridView1.SelectedRows[0].Cells["ProductID"].Value.ToString();
                var checkPending = (from ht in db.HeaderTransaction
                                    join dt in db.DetailTransaction on ht.TransactionID equals dt.TransactionID
                                          where ht.UserID == textBoxUserID.Text && ht.Status == "Pending" && selected == dt.ProductID && ht.TransactionID == textBoxTransactionID.Text
                                          select dt ).FirstOrDefault();
           
                if (checkPending != null)
                {
                    checkPending.Quantity += Convert.ToInt32(numericUpDownQuantityListLaundry.Value);
                    checkPending.Price = checkPending.Quantity*(Int32.Parse(textBoxPrice.Text));
                    db.SaveChanges();
                    
                }
                else
                {
                    string lastRow = (from ht in db.HeaderTransaction
                                      orderby ht.TransactionID descending
                                      select ht.TransactionID).FirstOrDefault();
                    if (textBoxTransactionID.Text != lastRow)
                    {
                        HeaderTransaction newHeaderTrans = new HeaderTransaction();
                        newHeaderTrans.TransactionID = newId;
                        newHeaderTrans.UserID = textBoxUserID.Text;
                        newHeaderTrans.Status = "Pending";
                        db.HeaderTransaction.Add(newHeaderTrans);
                        db.SaveChanges();

                        DetailTransaction newDetailTrans = new DetailTransaction();
                        newDetailTrans.TransactionID = newId;
                        newDetailTrans.ProductID = textBoxLaundryID.Text;
                        newDetailTrans.Quantity = Convert.ToInt32(numericUpDownQuantityListLaundry.Value);
                        int a = Convert.ToInt32(numericUpDownQuantityListLaundry.Value);
                        int b = Int32.Parse(textBoxPrice.Text);
                        newDetailTrans.Price = a * b;
                        db.DetailTransaction.Add(newDetailTrans);
                        db.SaveChanges();
                    }
                    else
                    {
                        DetailTransaction newDetailTrans = new DetailTransaction();
                        newDetailTrans.TransactionID = newId;
                        newDetailTrans.ProductID = textBoxLaundryID.Text;
                        newDetailTrans.Quantity = Convert.ToInt32(numericUpDownQuantityListLaundry.Value);
                        int a = Convert.ToInt32(numericUpDownQuantityListLaundry.Value);
                        int b = Int32.Parse(textBoxPrice.Text);
                        newDetailTrans.Price = a * b;
                        db.DetailTransaction.Add(newDetailTrans);
                        db.SaveChanges();
                    }
                }
                init_state_order();
                refresh();
                calculate();
            }
        }
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count != 1)
            {
                MessageBox.Show("Please Choose the Cart to be Deleted First!");
            }
            else
            {
                var checkdt = (from ht in db.HeaderTransaction
                               join dt in db.DetailTransaction on ht.TransactionID equals dt.TransactionID
                               where ht.UserID == textBoxUserID.Text && ht.Status == "Pending" && textBoxProductID.Text == dt.ProductID
                               select dt).FirstOrDefault();
                MessageBox.Show("Deleted from Cart");
                db.DetailTransaction.Remove(checkdt);
                db.SaveChanges();
                refresh();
                calculate();
            }
        }

        private void buttonCheckOut_Click(object sender, EventArgs e)
        {
            var checkStat = (from ht in db.HeaderTransaction
                             join dt in db.DetailTransaction on ht.TransactionID equals dt.TransactionID
                             where ht.UserID == textBoxUserID.Text && ht.Status == "Pending" && ht.TransactionID == textBoxTransactionID.Text
                           select ht).ToList(); 
            checkStat.Select(c => 
                                {
                                    c.Status = "Waiting"; return c;
                                }).ToList();
            db.SaveChanges();
            MessageBox.Show("All of your Items have been Checked Out");
            loadData();
            init_state_order();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                textBoxLaundryID.Text = dataGridView1.SelectedRows[0].Cells["ProductID"].Value.ToString();
                textBoxLaundryName.Text = dataGridView1.SelectedRows[0].Cells["ProductName"].Value.ToString();
                textBoxPrice.Text = dataGridView1.SelectedRows[0].Cells["ProductPrice"].Value.ToString();
            }
        }
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                textBoxProductID.Text = dataGridView2.SelectedRows[0].Cells["ProductID"].Value.ToString();
            }
        }
    }
}

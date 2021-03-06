﻿using System;
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
        DatabaseLaundryEntities1 db = new DatabaseLaundryEntities1();
        public FormMasterLaundry()
        {
            InitializeComponent();
            init_state_MasterLaundryForm();
            loadData();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        public void loadData()
        {
            dataGridView1.DataSource = (from x in db.PriceList select new { x.ProductID ,x.ProductName,x.ProductPrice}).ToList();
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
        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView1.ClearSelection();
        }
        public static bool IsAllLetters(string s)
        {
            foreach (char c in s)
            {
                if (!Char.IsLetter(c))
                    return false;
            }
            return true;
        }
        public static bool IsAllDigits(string s)
        {
            foreach (char c in s)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            flagInsert = 0;
            flagUpdate = 0;
            init_state_MasterLaundryForm();
            loadData();
        }
        string newId = "";
        int flagInsert = 0;
        int flagUpdate = 0;
        private void buttonInsert_Click(object sender, EventArgs e)
        {
            string lastRow =  (from x in db.PriceList
                              orderby x.ProductID descending
                             select x.ProductID).FirstOrDefault();
            if(lastRow == null)
            {
                newId = "PD001";
            }
            else
            {
                int id = Int32.Parse(lastRow.Substring(lastRow.Length - 3)) + 1;
                if (id < 10)
                {
                    newId = "PD00" + id;
                }
                else if (id < 100)
                {
                    newId = "PD0" + id;
                }
                else
                {
                    newId = "PD" + id;
                }
            }
            
            textBoxLaundryID.Enabled = false;
            textBoxLaundryName.Enabled = true;
            textBoxPrice.Enabled = true;
            textBoxLaundryID.Text = newId;
            textBoxLaundryName.Text = "";
            textBoxPrice.Text = "";
            buttonInsert.Enabled = false;
            buttonUpdate.Enabled = false;
            buttonDelete.Enabled = false;
            buttonSave.Enabled = true;
            buttonCancel.Enabled = true;
            this.ActiveControl = textBoxLaundryName;
            flagInsert = 1;
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
        
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (textBoxLaundryName.Text == "")
            {
                MessageBox.Show("Please Fill the Laundry Name Field");
            }
            else if (!IsAllLetters(textBoxLaundryName.Text))
            {
                MessageBox.Show("Laundry Name must be alphabet only");
            }
            else if (textBoxPrice.Text == "")
            {
                MessageBox.Show("Please Fill the Laundry Price Field");
            }
            else if (!IsAllDigits(textBoxPrice.Text))
            {
                MessageBox.Show("Laundry Price must be numeric");
            }
            else
            {
                if (flagInsert == 1)
                {
                    PriceList newPriceList = new PriceList();
                    newPriceList.ProductID = newId;
                    newPriceList.ProductName = textBoxLaundryName.Text;
                    newPriceList.ProductPrice = Int32.Parse(textBoxPrice.Text);

                    db.PriceList.Add(newPriceList);
                    db.SaveChanges();
                    flagInsert = 0;
                }
                else if (flagUpdate == 1)
                {
                    var priceList = (from x in db.PriceList
                                    where x.ProductID == textBoxLaundryID.Text
                                    select x).FirstOrDefault();
                    priceList.ProductName = textBoxLaundryName.Text;
                    priceList.ProductPrice = int.Parse(textBoxPrice.Text);
                    flagUpdate = 0;
                    db.SaveChanges();
                }
                MessageBox.Show("Laundry has been inserted/updated!");
                loadData();
                init_state_MasterLaundryForm();
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("Select Product First");
            }
            else
            {
                textBoxLaundryID.Enabled = false;
                textBoxLaundryName.Enabled = true;
                textBoxPrice.Enabled = true;

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
            if(dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("Select Product First");
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure want to delete this product?", "Confirmation Message", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    var priceList = (from x in db.PriceList where x.ProductID == textBoxLaundryID.Text select x).FirstOrDefault();
                    try
                    {
                        db.PriceList.Remove(priceList);
                        db.SaveChanges();
                        MessageBox.Show("Succesfully delete a product");
                        var headerTrans = (from ht in db.HeaderTransaction
                                           select ht).ToList();
                        for(int i = 0; i < headerTrans.Count(); i++)
                        {
                            if (headerTrans[i].DetailTransaction.Any() == false)
                            {
                                db.HeaderTransaction.Remove(headerTrans[i]);
                                db.SaveChanges();
                            }
                        }
                        
                    }
                    catch (System.Data.Entity.Infrastructure.DbUpdateException)
                    {
                        MessageBox.Show("Sorry, You can't delete this Item.\nPlease contact your support!","Error Message!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                }
                loadData();
                init_state_MasterLaundryForm();
            }
        }

        private void textBoxPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonSave_Click(this, new EventArgs());
            }
        }

        private void textBoxLaundryName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonSave_Click(this, new EventArgs());
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonUpdate_Click(this, new EventArgs());
            }
        }

        private void FormMasterLaundry_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonInsert_Click(this, new EventArgs());
            }
        }
    }
}

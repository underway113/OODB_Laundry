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
    public partial class FormReview : Form
    {
        DatabaseLaundryEntities1 db = new DatabaseLaundryEntities1();
        public FormReview()
        {
            InitializeComponent();
            init_state_review();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            loadData();
        }
        public void init_state_review()
        {
            dataGridView1.ClearSelection();
            richTextBoxNewReview.Enabled = false;
            richTextBoxNewReview.Text = "";
            textBoxReviewID.Enabled = false;
            textBoxReviewID.Text = "";
            dataGridView2.DataSource = null;
        }
        string newId = "";
        public void loadData()
        {
            dataGridView1.DataSource = (from x in db.PriceList select new { x.ProductID, x.ProductName, x.ProductPrice }).ToList();
            string lastRow = (from r in db.Review
                              orderby r.ReviewID descending
                              select r.ReviewID).FirstOrDefault();
            if(lastRow == null)
            {
                newId = "RV001";
            }
            else
            {
                int id = Int32.Parse(lastRow.Substring(lastRow.Length - 3)) + 1;

                if (id < 10)
                {
                    newId = "RV00" + id;
                }
                else if (id < 100)
                {
                    newId = "RV0" + id;
                }
                else
                {
                    newId = "RV" + id;
                }
            }
           
            textBoxReviewID.Text = newId;
        }
        public void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                string selected = dataGridView1.SelectedRows[0].Cells["ProductID"].Value.ToString();
                var query = (from u in db.Users
                             join r in db.Review on u.UserID equals r.UserID
                             join p in db.PriceList on r.ProductID equals p.ProductID
                             where selected == r.ProductID && u.UserID == FormLogin.userIDGlobal
                             select new { r.ReviewID, Review = r.Review1 });
                dataGridView2.DataSource = query.ToList();
                richTextBoxNewReview.Enabled = true;
            }
        }
        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView1.ClearSelection();
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("Please Choose Product First");
            }
            else if(richTextBoxNewReview.Text == "")
            {
                MessageBox.Show("New Review Must be Filled");
            }
            else
            {
                string selected = dataGridView1.SelectedRows[0].Cells["ProductID"].Value.ToString();
                Review newReview = new Review();
                newReview.ReviewID = newId;
                newReview.Review1 = richTextBoxNewReview.Text;
                newReview.ProductID = selected;
                newReview.UserID = FormLogin.userIDGlobal;
                db.Review.Add(newReview);
                db.SaveChanges();
                init_state_review();
                loadData();
            }
        }

        private void richTextBoxNewReview_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonAdd_Click(this, new EventArgs());
            }
        }
    }
}

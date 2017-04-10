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
    public partial class FormHome : Form
    {
        DatabaseLaundryEntities1 db = new DatabaseLaundryEntities1();
        public FormHome()
        {
            InitializeComponent();
            if (FormLogin.roleGlobal == "Admin")
            {
                orderToolStripMenuItem.Visible = false;
                giveReviewToolStripMenuItem.Visible = false;
                manageProductToolStripMenuItem.Visible = true;
                transactionToolStripMenuItem.Visible = true;
                manageUserToolStripMenuItem.Visible = true;
                changePasswordToolStripMenuItem.Visible = true;
                logOutToolStripMenuItem.Visible = true;

            }
            else if (FormLogin.roleGlobal == "Member")
            {
                orderToolStripMenuItem.Visible = true;
                giveReviewToolStripMenuItem.Visible = true;
                manageProductToolStripMenuItem.Visible = false;
                transactionToolStripMenuItem.Visible = true;
                manageUserToolStripMenuItem.Visible = false;
                changePasswordToolStripMenuItem.Visible = true;
                logOutToolStripMenuItem.Visible = true;
            }
            WindowState = FormWindowState.Maximized;
            this.MaximizeBox = true;
            this.Text = "Home | Welcome, " + FormLogin.userNamelobal;
        }

        FormMasterLaundry formMasterLaundry;
        FormManageUser formManageUser;
        FormViewTransaction formViewTransaction;
        FormChangePassword formChangePassword;
        FormOrder formOrder;
        FormReview formReview;
        private void manageProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(formMasterLaundry == null)
            {
                formMasterLaundry = new FormMasterLaundry();
                formMasterLaundry.MdiParent = this;
                formMasterLaundry.FormClosed += FormMasterLaundry_FormClosed;
                formMasterLaundry.Show();
            }
            else
            {
                formMasterLaundry.Activate();
            }
        }
        private void FormMasterLaundry_FormClosed(object sender, FormClosedEventArgs e)
        {
            formMasterLaundry = null;
            //throw new NotImplementedException();
        }

        private void manageUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (formManageUser == null)
            {
                formManageUser = new FormManageUser();
                formManageUser.MdiParent = this;
                formManageUser.FormClosed += FormManageUser_FormClosed;
                formManageUser.Show();
            }
            else
            {
                formManageUser.Activate();
            }
        }

        private void FormManageUser_FormClosed(object sender, FormClosedEventArgs e)
        {
            formManageUser = null;
            //throw new NotImplementedException();
        }

        private void transactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var checkNullDatabase = (from ht in db.HeaderTransaction
                                     select ht).FirstOrDefault();
            if(checkNullDatabase != null)
            {
                if (formViewTransaction == null)
                {
                    formViewTransaction = new FormViewTransaction();
                    formViewTransaction.MdiParent = this;
                    formViewTransaction.FormClosed += FormViewTransaction_FormClosed;
                    formViewTransaction.Show();
                }
                else
                {
                    formViewTransaction.Activate();
                }
            }
            else
            {
                MessageBox.Show("No Transaction !", "Warning Message!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void FormViewTransaction_FormClosed(object sender, FormClosedEventArgs e)
        {
            formViewTransaction = null;
            //throw new NotImplementedException();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (formChangePassword == null)
            {
                formChangePassword = new FormChangePassword();
                formChangePassword.MdiParent = this;
                formChangePassword.FormClosed += FormChangePassword_FormClosed;
                formChangePassword.Show();
            }
            else
            {
                formChangePassword.Activate();
            }
        }

        private void FormChangePassword_FormClosed(object sender, FormClosedEventArgs e)
        {
            formChangePassword = null;
            //throw new NotImplementedException();
        }

        private void orderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var checkNullDatabase = (from p in db.PriceList
                                      select p).FirstOrDefault();
            if (checkNullDatabase != null)
            {
                if (formOrder == null)
                {
                    formOrder = new FormOrder();
                    formOrder.MdiParent = this;
                    formOrder.FormClosed += FormOrder_FormClosed;
                    formOrder.Show();
                }
                else
                {
                    formOrder.Activate();
                }
            }
            else
            {
                MessageBox.Show("Admin Must Add Laundry Product First !", "Warning Message!" , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void FormOrder_FormClosed(object sender, FormClosedEventArgs e)
        {
            formOrder = null;
            //throw new NotImplementedException();
        }

        private void giveReviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var checkNullDatabase = (from ht in db.HeaderTransaction
                                     select ht).FirstOrDefault();
            if (checkNullDatabase != null) {
                if (formReview == null)
                {
                    formReview = new FormReview();
                    formReview.MdiParent = this;
                    formReview.FormClosed += FormReview_FormClosed;
                    formReview.Show();
                }
                else
                {
                    formReview.Activate();
                }
            }
            else
            {
                MessageBox.Show("You must do the Laundry First!", "Warning Message!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void FormReview_FormClosed(object sender, FormClosedEventArgs e)
        {
            formReview = null;
            //throw new NotImplementedException();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new FormLogin();
            this.Visible = false;
            form.Visible = true;
        }

        private void FormHome_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult DialogResult = MessageBox.Show("Do you really want to exit?", "Confirmation",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
            if (DialogResult == DialogResult.Yes)
            {
                System.Environment.Exit(1);
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}

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
        }

        private void FormHome_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            this.MaximizeBox = false;
            //manageProductToolStripMenuItem.Visible = false; buat hide di role user atau admin nanti
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

        private void FormOrder_FormClosed(object sender, FormClosedEventArgs e)
        {
            formOrder = null;
            //throw new NotImplementedException();
        }

        private void giveReviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
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
    }
}

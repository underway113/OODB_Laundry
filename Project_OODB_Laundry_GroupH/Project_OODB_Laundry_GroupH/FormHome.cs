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
        }

        private void FormHome_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            this.MaximizeBox = false;
            //manageProductToolStripMenuItem.Visible = false; buat hide di role user atau admin nanti
        }

        private void manageProductToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new FormLogin();
            this.Visible = false;
            form.Visible = true;
        }
    }
}

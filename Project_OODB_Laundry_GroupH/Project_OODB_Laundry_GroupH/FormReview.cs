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
        public FormReview()
        {
            InitializeComponent();
        }

        public void init_state_review()
        {
            textBoxReviewID.Enabled = true;
            textBoxReviewID.Text = "";
        }

        private void FormReview_Load(object sender, EventArgs e)
        {

        }
    }
}

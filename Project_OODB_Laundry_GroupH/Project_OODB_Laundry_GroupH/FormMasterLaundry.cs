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
        public FormMasterLaundry()
        {
            InitializeComponent();
            buttonSave.Enabled = false;
            buttonCancel.Enabled = false;
        }

        private void FormMasterLaundry_Load(object sender, EventArgs e)
        {

        }
    }
}
